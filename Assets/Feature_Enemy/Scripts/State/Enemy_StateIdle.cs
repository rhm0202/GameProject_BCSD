using UnityEngine;

public class Enemy_StateIdle : IState
{
    private Enemy enemy;

    public Enemy_StateIdle(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.ChangeAnimation("Idle");
    }

    public void Update()
    {
        if (enemy.DetectPlayer() && enemy.isChasingPlayer)
        {
            enemy.stateMachine.TransitionTo(enemy.stateMachine.stateChasing);
        }
    } 
    public void Exit()
    {
        
    }
}
