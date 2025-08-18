using UnityEngine;

public class Boss1_StateReady : IState
{
    private Boss_Stage1 boss;

    public Boss1_StateReady(Boss_Stage1 boss)
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

        Debug.Log(boss.stateMachine);
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
