using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineT<TState, TOwner> where TOwner : Monster
{
    /* ���� �ӽ� */

    [SerializeField] TOwner owner;
    private Dictionary<TState, IState> states;
    private IState currentState;

    public void Update()
    {
        currentState.Update();
    }

    // ù ����
    public void SetInitState(TState type)
    {
        currentState = states[type];
        currentState.Enter();
    }

    // ���� ��ȯ
    public void ChangeState(TState type)
    {
        currentState.Exit();            // ���� ���� ������
        currentState = states[type];    // ���¸� �ٲ�
        currentState.Enter();           // �ٲ� ���¿� ����
    }

    // ���� State �߰��ϱ�
    public void AddState(TState type, IState state)
    {
        states.Add(type, state);
    }
}
