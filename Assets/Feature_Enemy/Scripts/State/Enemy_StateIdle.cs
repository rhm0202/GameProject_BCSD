using UnityEngine;

public class Enemy_StateIdle : IState
{
    private Enemy enemy;

    float timer;
    float waitingTime;

    public Enemy_StateIdle(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.ChangeAnimation("Idle");
        timer = 0f;
        waitingTime = Random.Range(0.5f, 2f); // Random idle time between 1 and 3 seconds
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitingTime)
        {
            enemy.stateMachine.TransitionTo(enemy.stateMachine.statePatrol);
        }

        if (enemy.DetectPlayer() && enemy.isChasingPlayer)
        {
            enemy.stateMachine.TransitionTo(enemy.stateMachine.stateChasing);
        }
    } 
    public void Exit()
    {
        bool nextdirection = Random.Range(0, 2) == 0;
        if (nextdirection)
        {
            enemy.Flip();
        }
        else
        {
            enemy.Flip();
        }
    }
}
