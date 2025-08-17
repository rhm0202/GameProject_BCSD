using UnityEngine;

public class Boss1_StateReady : IState
{
    private Boss boss1;

    public Boss1_StateReady(Boss boss)
    {
        this.boss1 = boss;
    }

    public void Enter()
    {
        boss1.ChangeAnimation("Idle");
        boss1.ChangeAnimationSpeed(0f);
    }
    public void Update()
    {
        if (boss1.DetectPlayer())
        {
            boss1.stateMachine.TransitionTo(boss1.stateMachine.stateChasing);
        }
    }

    public void Exit()
    {
        boss1.ChangeAnimationSpeed(1f);
        boss1.StartBossFight();
    }
}
