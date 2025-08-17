using UnityEngine;

public class Boss1_StateChasing : IState
{
    Boss_Stage1 boss1;

    float timer;
    int waitingTime;
    public Boss1_StateChasing(Boss_Stage1 boss)
    {
        this.boss1 = boss;
    }

    public void Enter()
    {
        boss1.ChangeAnimation("Walk");
        timer = 0f;
        waitingTime = Random.Range(2, 5);
    }
    public void Update()
    {
        boss1.Chase();
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            int nextState = Random.Range(0, 2); // 0: Normal Attack, 1: Jump Attack
            boss1.stateMachine.TransitionTo(nextState == 0 ? boss1.stateMachine.stateNAttack : boss1.stateMachine.stateJAttack);
        }
    }

    public void Exit()
    {
    }

}
