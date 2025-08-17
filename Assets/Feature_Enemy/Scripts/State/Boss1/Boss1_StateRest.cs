using UnityEngine;

public class Boss1_StateRest : IState
{
    private Boss_Stage1 boss1;

    float timer;
    int waitingTime = 3;
    public Boss1_StateRest(Boss_Stage1 boss)
    {
        this.boss1 = boss;
    }

    public void Enter()
    {
        boss1.ChangeAnimation("Idle");
        boss1.ChangeAnimationSpeed(0.75f);
        boss1.isResting = true;
        timer = 0f;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            boss1.stateMachine.TransitionTo(boss1.stateMachine.stateChasing);
        }
    }
    public void Exit()
    {
        boss1.ChangeAnimationSpeed(1f);
        boss1.isResting = false;
    }
}
