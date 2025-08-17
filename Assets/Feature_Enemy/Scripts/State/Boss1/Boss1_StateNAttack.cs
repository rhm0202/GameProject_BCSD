using UnityEngine;

public class Boss1_StateNAttack : IState
{
    private Boss boss;

    public Boss1_StateNAttack(Boss boss)
    {
        this.boss = boss;
    }

    public void Enter()
    {
        boss.ChangeAnimation("Attack");
        boss.isAttacking = true;
        boss.NormalAttack();
    }
    public void Update()
    {
        if (!boss.isAttacking)
        {
            boss.stateMachine.TransitionTo(boss.stateMachine.stateRest);
        }
    }

    public void Exit()
    {
    }
}
