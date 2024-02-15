using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Serializable : ����ȭ ����
[Serializable]

public class IdleState<T> : IState where T : Monster
{
    [SerializeField] T owner;
    [SerializeField] float findRange = 5;

    private Transform playerTransform;

    public void Enter()
    {
        Debug.Log("Idle Enter");
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    public void Update()
    {
        Debug.Log("Idle Update");
        if (Vector2.Distance(playerTransform.position, owner.transform.position) < findRange)
        {
            //owner.ChangeState("Trace");  // ���� ����
        }
    }

    public void Exit()
    {
        Debug.Log("Idle Exit");
    }
}
