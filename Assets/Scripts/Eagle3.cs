using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle3 : Monster
{
    /*
    public Transform playerTransform;
    public Vector3 startPos;

    [Header("FSM")]
    public enum State { Idle, Trace, Return, Die }
    private StateMachineT<State, Eagle3> fsm;

    [SerializeField] IdleState<Eagle3> idleState;

    private void Awake()
    {
        fsm = new StateMachineT<State, Eagle3>();

        fsm.AddState(State.Idle, idleState);
        fsm.AddState(State.Trace, traceState);
        fsm.AddState(State.Return, returnState);
    }

    private void Start()
    {
        fsm.SetInitState(State.Idle);
        startPos = transform.position;
    }

    private void Update()
    {
        fsm.Update();

        if ()
        {
            fsm.ChangeState(State.Trace);
        }
    }

    public void ChangeState(string stateName)
    {
        switch (stateName)
        {
            case "Idle":
                fsm.ChangeState(idleState);
                break;
            case "Trace":
                fsm.ChangeState(traceState);
                break;
            case "Return":
                fsm.ChangeState(returnState);
                break;
        }
    }*/


    /* Idle */
    public class IdleState : IState
    {
        private Eagle3 owner;
        private Transform playerTransform;
        private float findRange = 5;

        public IdleState(Eagle3 owner)
        {
            this.owner = owner;
        }

        // 초기화 작업
        public void Enter()
        {
            Debug.Log("Idle Enter");
            playerTransform = GameObject.FindWithTag("Player").transform;
        }

        // 진행 중 작업
        public void Update()
        {
            Debug.Log("Idle Update");
            if (Vector2.Distance(playerTransform.position, owner.transform.position) < findRange)
            {
                //owner.ChangeState("Trace");  // 상태 변경
            }
        }

        // 나갈 때 작업  
        public void Exit()
        {
            Debug.Log("Idle Exit");
        }
    }


    /* Trace */
    public class TraceState : IState
    {
        private Eagle3 owner;
        private Transform playerTransform;
        private float findRange = 5;
        private float moveSpeed = 2;

        public TraceState(Eagle3 owner)
        {
            this.owner = owner;
        }

        public void Enter()
        {
            Debug.Log("Trace Enter");
            playerTransform = GameObject.FindWithTag("Player").transform;
        }

        public void Update()
        {
            Debug.Log("Trace Update");
            Vector3 dir = (playerTransform.position - owner.transform.position).normalized;
            owner.transform.Translate(dir * moveSpeed * Time.deltaTime);

            if (Vector2.Distance(playerTransform.position, owner.transform.position) > findRange)
            {
                //owner.ChangeState("Return");  // 상태 변경
            }
        }

        public void Exit()
        {
            Debug.Log("Trace Exit");
        }
    }


    /* Return */
    private class ReturnState : IState
    {
        private Eagle3 owner;
        private Transform playerTransform;
        private float findRange = 5;
        private float moveSpeed = 2;
        private float returnSpeed = 10;

        public ReturnState(Eagle3 owner)
        {
            this.owner = owner;
        }

        public void Enter()
        {
            Debug.Log("Return Enter");
            playerTransform = GameObject.FindWithTag("Player").transform;
        }

        public void Update()
        {
            Debug.Log("Return Update");
            /*
            Vector3 dir = (owner.startPos - owner.transform.position).normalized;
            owner.transform.Translate(dir * moveSpeed * Time.deltaTime);

            if (Vector2.Distance(owner.transform.position, owner.startPos) < 0.01f)
            {
                owner.ChangeState("Idle");
            }
            if (Vector2.Distance(owner.transform.position, playerTransform.position) < findRange)
            {
                owner.ChangeState("Trace");
            }*/
        }

        public void Exit()
        {
            Debug.Log("Return Exit");
        }
    }
}

public class Orc : Monster
{
    [SerializeField] IdleState<Orc> idleState;
}
