using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineT<TState, TOwner> where TOwner : Monster
{
    /* 상태 머신 */

    [SerializeField] TOwner owner;
    private Dictionary<TState, IState> states;
    private IState currentState;

    public void Update()
    {
        currentState.Update();
    }

    // 첫 상태
    public void SetInitState(TState type)
    {
        currentState = states[type];
        currentState.Enter();
    }

    // 상태 전환
    public void ChangeState(TState type)
    {
        currentState.Exit();            // 현재 상태 마무리
        currentState = states[type];    // 상태를 바꿈
        currentState.Enter();           // 바뀐 상태에 진입
    }

    // 여러 State 추가하기
    public void AddState(TState type, IState state)
    {
        states.Add(type, state);
    }
}
