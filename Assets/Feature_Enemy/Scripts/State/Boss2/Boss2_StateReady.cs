using UnityEngine;

public class Boss2_StateReady : IState
{
    private Boss_Stage2 boss;

    public Boss2_StateReady(Boss_Stage2 boss)
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
