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

    [SerializeField] LayerMask groundCheckLayer;

    private Vector2 moveDir;
    private bool isGround;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // 가속할 때 최고속도 제한두기위해
        if (moveDir.x < 0 && rigid.velocity.x > -maxXSpeed)
        {
            // 왼쪽(-) 입력 && -최대속도보다 클 때
            rigid.AddForce(Vector2.right * moveDir.x * movePower);
        }
        else if (moveDir.x > 0 && rigid.velocity.x < maxXSpeed)
        {
            // 오른쪽(+) 입력 && 최대속도보다 작을 때
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

        // 떨어지는 속도 제한
        if (rigid.velocity.y < -maxYSpeed)
        {
            Vector2 velocity = rigid.velocity;
            velocity.y = -maxYSpeed;
            rigid.velocity = velocity;
        }

        // Fall 애니메이션
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
            render.flipX = true;  // 향하는 방향을 바라보도록
            animator.SetBool("Run", true);  // 누르면 뛰고 안누르면 안뛰도록
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

    // 복합충돌체 구현 시에는
    //private int groundCount;
    // 실행코드에서 groundCount++; groundCount--; 사용

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (groundCheckLayer.Contain(collision.gameObject.layer))
        {
            // 트리거가 되면 true로
            isGround = true;
            animator.SetBool("IsGround", isGround);
            Debug.Log("땅 밟음");

            int layerNum = collision.gameObject.layer;
            Debug.Log(layerNum);
            Debug.Log(groundCheckLayer);
            int layerMaskNum = (1 << layerNum) & groundCheckLayer;




        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (groundCheckLayer.Contain(collision.gameObject.layer))
        {
            // 트리거에서 나가면 false로
            isGround = false;
            animator.SetBool("IsGround", isGround);
            Debug.Log("땅에서 벗어남");
        }
    }
}
