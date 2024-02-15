using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Monster
{
    public enum State
    {
        Idle,       // ������
        Trace,      // ����
        Return,     // �ڱ��ڸ��� ���ƿ�
        Die         // ����
    }

    [SerializeField] float moveSpeed;
    [SerializeField] float findRange;

    private State currentState;
    private Transform playerTransform;
    private Vector3 startPos;

    private void Start()
    {
        currentState = State.Idle;
        playerTransform = GameObject.FindWithTag("Player").transform;
        // Update���� Find~�������� Start���� ���ֱ�
        // ������� ���� �ڷ���� �̸� ����س��� ����ϱ�?
        startPos = transform.position;
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                IdleUpdate();
                break;
            case State.Trace:
                TraceUpdate();
                break;
            case State.Return:
                ReturnUpdate();
                break;
            case State.Die:
                break;
        }

        //Vector3 dir = (playerPos - transform.position).normalized;  // normalized : ����
        //float scale = (playerPos - transform.position).magnitude;  // magnitude : ũ��
    }

    // ����� � ������ �� �ؾ��� �ൿ�� ����



    /* �������ֱ� */
    // 
    private void IdleUpdate()
    {
        // ���� ���� : ������ - �����
        // Distance(Vector2 a, Vector2 b) : a - b
        if (Vector2.Distance(playerTransform.position, transform.position) < findRange)
        {
            // ���Ͱ��� Range ���ϰ� �Ǹ� ����
            currentState = State.Trace;
        }
    }

    /* �����ϱ� */
    // ���� ��ġ --> player ��ġ
    private void TraceUpdate()
    {
        Vector3 dir = (playerTransform.position - transform.position).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime);

        if (Vector2.Distance(playerTransform.position, transform.position) > findRange)
        {
            currentState = State.Return;
        }
    }

    /* ���ư��� */
    // ���� ��ġ --> startPos
    private void ReturnUpdate()
    {
        Vector3 dir = (startPos - transform.position).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, startPos) < 0.01f)
        {
            currentState = State.Idle;
        }
        if (Vector2.Distance(transform.position, playerTransform.position) < findRange)
        {
            currentState = State.Trace;
        }
    }

    /* ���� ���� */
    private void DieUpdate()
    {

    }
}
