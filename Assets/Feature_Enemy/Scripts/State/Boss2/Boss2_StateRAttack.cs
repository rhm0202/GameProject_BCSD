using UnityEngine;

public class Boss2_StateRAttack : IState
{
    private Boss_Stage2 boss;
    public Boss2_StateRAttack(Boss_Stage2 boss)
    {
        this.boss = boss;
    }

    public void Enter()
    {
        boss.isAttacking = true;
        boss.applyedSpeed = 0f;
        boss.RangedAttack();
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
        boss.restTime = 2f;
        boss.isAttacking = false;
    }

}
