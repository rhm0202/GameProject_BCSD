using UnityEngine;

public class Boss2_StateChasing : IState
{
    private Boss_Stage2 boss;

    public Boss2_StateChasing(Boss_Stage2 boss)
    {
        this.boss = boss;
    }

    public void Enter()
    {
        boss.ChangeAnimation("Walk");
        boss.ChangeAnimationSpeed(1.5f);
        boss.Chase();
    }

    public void Update()
    {
        if(!boss.isMovingTowardsTarget())
        {
            boss.stateMachine.TransitionTo(boss.stateMachine.stateBattle);
        }
    }

    public void Exit()
    {
        boss.ChangeAnimationSpeed(1f);
        boss.applyedSpeed = 0f;
        boss.isMoving = false;
        boss.restTime = 0f;
    }
}
