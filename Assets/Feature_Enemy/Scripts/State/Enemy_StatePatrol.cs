using UnityEngine;

public class Enemy_StatePatrol : IState
{
    private Enemy enemy;

    public Enemy_StatePatrol(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.ChangeAnimation("Walk");
    }

    public void Update()
    {
        enemy.Patrol();
        if (enemy.DetectPlayer())
        {
            enemy.stateMachine.TransitionTo(enemy.stateMachine.stateChasing);
        }
    }
    public void Exit()
    {

    }
}
