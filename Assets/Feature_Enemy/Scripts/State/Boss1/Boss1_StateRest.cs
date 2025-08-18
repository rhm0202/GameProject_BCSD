using UnityEngine;

public class Boss1_StateRest : IState
{
    private Boss_Stage1 boss;

    float timer;
    int waitingTime = 3;
    public Boss1_StateRest(Boss_Stage1 boss)
    {
        this.boss = boss;
    }

    public void Enter()
    {
        boss.ChangeAnimation("Idle");
        boss.ChangeAnimationSpeed(0.75f);
        boss.isResting = true;
        timer = 0f;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            boss.stateMachine.TransitionTo(boss.stateMachine.stateBattle);
        }
    }
    public void Exit()
    {
        boss.ChangeAnimationSpeed(1f);
        boss.isResting = false;
    }
}
