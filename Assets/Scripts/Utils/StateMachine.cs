using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    /* ���� �ӽ� */

    private IState currentState;

    public void Update()
    {
        currentState.Update();
    }

    // ù ����
    public void SetInitState(IState initState)
    {
        currentState = initState;
        currentState.Enter();
    }

    // ���� ��ȯ
    public void ChangeState(IState nextState)
    {
        currentState.Exit();        // ���� ���� ������
        currentState = nextState;   // ���¸� �ٲ�
        currentState.Enter();       // �ٲ� ���¿� ����
    }
}

