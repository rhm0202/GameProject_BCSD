using UnityEngine;

public class Enemy_StatePatrol : IState
{
    private Enemy enemy;

    float timer;
    float waitingTime;

    public Enemy_StatePatrol(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.ChangeAnimation("Walk");
        timer = 0f;
        waitingTime = Random.Range(1f, 4f); // Random patrol time between 1 and 3 seconds
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitingTime)
        {
            enemy.stateMachine.TransitionTo(enemy.stateMachine.stateIdle);
        }
        enemy.Patrol();
        if (enemy.DetectPlayer() && enemy.isChasingPlayer)
        {
            enemy.stateMachine.TransitionTo(enemy.stateMachine.stateChasing);
        }
    }
    public void Exit()
    {

    }
}
