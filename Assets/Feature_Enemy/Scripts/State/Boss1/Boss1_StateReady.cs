using UnityEngine;

public class Boss1_StateReady : IState
{
    private Boss boss;

    public Boss1_StateReady(Boss boss)
    {
        this.boss = boss;
    }

    public void Enter()
    {
        boss.ChangeAnimation("Idle");
        boss.ChangeAnimationSpeed(0f);
    }
    public void Update()
    {
        if (boss.DetectPlayer())
        {
            boss.stateMachine.TransitionTo(boss.stateMachine.stateBattle);
        }
    }

    public void Exit()
    {
        boss.ChangeAnimationSpeed(1f);
        boss.StartBossFight();
    }
}
