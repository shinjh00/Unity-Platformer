using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Monster
{
    public enum State
    {
        Idle,       // 가만히
        Trace,      // 추적
        Return,     // 자기자리로 돌아옴
        Die         // 죽음
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
        // Update에서 Find~쓰지말고 Start에서 해주기
        // 변경되지 않을 자료들은 미리 계산해놓고 사용하기?
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

        //Vector3 dir = (playerPos - transform.position).normalized;  // normalized : 방향
        //float scale = (playerPos - transform.position).magnitude;  // magnitude : 크기
    }

    // 대상이 어떤 상태일 때 해야할 행동만 정의



    /* 가만히있기 */
    // 
    private void IdleUpdate()
    {
        // 벡터 연산 : 도착지 - 출발지
        // Distance(Vector2 a, Vector2 b) : a - b
        if (Vector2.Distance(playerTransform.position, transform.position) < findRange)
        {
            // 벡터값이 Range 이하가 되면 추적
            currentState = State.Trace;
        }
    }

    /* 추적하기 */
    // 지금 위치 --> player 위치
    private void TraceUpdate()
    {
        Vector3 dir = (playerTransform.position - transform.position).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime);

        if (Vector2.Distance(playerTransform.position, transform.position) > findRange)
        {
            currentState = State.Return;
        }
    }

    /* 돌아가기 */
    // 지금 위치 --> startPos
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

    /* 몬스터 죽음 */
    private void DieUpdate()
    {

    }
}
