using UnityEngine;

public class Boss2_StateBattle : IState
{
    private Boss_Stage2 boss;

    float timer;
    int waitingTime = 1;
    public Boss2_StateBattle(Boss_Stage2 boss)
    {
        this.boss = boss;
    }

    public void Enter()
    {
        boss.ChangeAnimation("Idle");
        timer = 0f;
        waitingTime = Random.Range(0, 2);
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            int nextState = Random.Range(0, 3);
            Debug.Log("Battle -> Next State: " + nextState);

            switch (nextState)
            {
                case 0:
                    boss.stateMachine.TransitionTo(boss.stateMachine.stateNAttack);
                    break;
                case 1:
                    boss.stateMachine.TransitionTo(boss.stateMachine.stateRAttack);
                    break;
                case 2:
                    boss.stateMachine.TransitionTo(boss.stateMachine.stateChasing);
                    break;
            }

        }
    }

    public void Exit()
    {

    }

}
