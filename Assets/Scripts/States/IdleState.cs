using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Serializable : 직렬화 가능
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
            //owner.ChangeState("Trace");  // 상태 변경
        }
    }

    public void Exit()
    {
        Debug.Log("Idle Exit");
    }
}
