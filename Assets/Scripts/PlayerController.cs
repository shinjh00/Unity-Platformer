using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] SpriteRenderer render;
    [SerializeField] Animator animator;

    [Header("Property")]
    [SerializeField] float movePower;
    [SerializeField] float brakePower;
    [SerializeField] float maxXSpeed;
    [SerializeField] float maxYSpeed;

    [SerializeField] float jumpSpeed;

    private Vector2 moveDir;
    private bool isGround;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // ������ �� �ְ��ӵ� ���ѵα�����
        if (moveDir.x < 0 && rigid.velocity.x > -maxXSpeed)
        {
            // ����(-) �Է� && -�ִ�ӵ����� Ŭ ��
            rigid.AddForce(Vector2.right * moveDir.x * movePower);
        }
        else if (moveDir.x > 0 && rigid.velocity.x < maxXSpeed)
        {
            // ������(+) �Է� && �ִ�ӵ����� ���� ��
            rigid.AddForce(Vector2.right * moveDir.x * movePower);
        }
        else if (moveDir.x == 0 && rigid.velocity.x > 0.1f)
        {
            rigid.AddForce(Vector2.left * brakePower);
        }
        else if (moveDir.x == 0 && rigid.velocity.x < -0.1f)
        {
            rigid.AddForce(Vector2.right * brakePower);
        }

        // �������� �ӵ� ����
        if (rigid.velocity.y < -maxYSpeed)
        {
            Vector2 velocity = rigid.velocity;
            velocity.y = -maxYSpeed;
            rigid.velocity = velocity;
        }

        // Fall �ִϸ��̼�
        animator.SetFloat("YSpeed", rigid.velocity.y);
    }

    private void Jump()
    {
        Vector2 velocity = rigid.velocity;
        velocity.y = jumpSpeed;
        rigid.velocity = velocity;
    }

    private void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();

        if (moveDir.x < 0)
        {
            render.flipX = true;  // ���ϴ� ������ �ٶ󺸵���
            animator.SetBool("Run", true);  // ������ �ٰ� �ȴ����� �ȶٵ���
        }
        else if (moveDir.x > 0)
        {
            render.flipX = false;
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && isGround)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;  // �ε����� �Ϳ� ����������
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;  // �ε����� �Ϳ��� ����������
    }
}