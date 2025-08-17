using System.Collections;
using UnityEngine;

public class Boss_Stage2 : Boss
{
    private int direction = 1;


    public new Boss2SM stateMachine;

    public override void Chase()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        direction = isFacingRight ? 1 : -1;
        rigid.linearVelocityX = applyedSpeed * direction;
    }


    protected override void Awake()
    {
        base.Awake();
        stateMachine = new Boss2SM(this);
    }
    protected override void Dead()
    {
        base.Dead();
        stateMachine.TransitionTo(stateMachine.stateDead);
    }

    private void Update()
    {
        stateMachine.Update();
    }
    private void FixedUpdate()
    {
        Move();
    }
}
