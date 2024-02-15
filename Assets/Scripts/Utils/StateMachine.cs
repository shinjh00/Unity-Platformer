using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    /* 상태 머신 */

    private IState currentState;

    public void Update()
    {
        currentState.Update();
    }

    // 첫 상태
    public void SetInitState(IState initState)
    {
        currentState = initState;
        currentState.Enter();
    }

    // 상태 전환
    public void ChangeState(IState nextState)
    {
        currentState.Exit();        // 현재 상태 마무리
        currentState = nextState;   // 상태를 바꿈
        currentState.Enter();       // 바뀐 상태에 진입
    }
}

