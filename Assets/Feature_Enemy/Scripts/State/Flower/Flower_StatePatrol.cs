using UnityEngine;

public class Flower_StatePatrol : IState
{
    private Enemy_Flower enemy;

    float timer = 0f;
    int waitingTime;
    public Flower_StatePatrol(Enemy_Flower enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        timer = 0f;
        waitingTime = Random.Range(2, 5);
        enemy.ChangeAnimation("Walk");
        enemy.player = null;
    }

    public void Update()
    {
        if (!enemy.DetectPlayer())
        {
            enemy.Patrol();
            timer += Time.deltaTime;
            if (timer >= waitingTime)
            {
                enemy.stateMachine.TransitionTo(enemy.stateMachine.stateIdle);
            }
        }
        else
        {
            enemy.stateMachine.TransitionTo(enemy.stateMachine.stateBattle);
        }
    }

    public void Exit()
    {

    }
}
