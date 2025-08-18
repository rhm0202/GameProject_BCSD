using UnityEngine;

public class Boss2_StateNAttack : IState
{
    private Boss_Stage2 boss;

    public Boss2_StateNAttack(Boss_Stage2 boss)
    {
        this.boss = boss;
    }

    public void Enter()
    {
        boss.ChangeAnimationSpeed(1.5f);
        boss.ChangeAnimation("Attack");
        boss.isAttacking = true;
        boss.NormalAttack();
        boss.applyedSpeed = 0f;
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
        boss.restTime = 1f;
        boss.ChangeAnimationSpeed(1f); 
    }
}
