using UnityEngine;

public class Boss2_StateRest : IState
{
    private Boss_Stage2 boss;

    float timer;
    float waitingTime = 1;
    public Boss2_StateRest(Boss_Stage2 boss)
    {
        this.boss = boss;
    }

    public void Enter()
    {
        boss.ChangeAnimation("Idle");
        boss.ChangeAnimationSpeed(0.55f);
        boss.isResting = true;
        timer = 0f;
        waitingTime = boss.restTime;
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
