using UnityEngine;

public class Enemy_StateChasing : IState
{
    private Enemy enemy;

    public Enemy_StateChasing(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.isChasingPlayer = true;
        enemy.ChangeAnimation("Walk");
        Debug.Log("Chasing Player");
        enemy.ChangeAnimationSpeed(1.2f);
    }

    public void Update()
    {
        enemy.Chase();
        if (enemy.isChasingPlayer == false)
        {
            enemy.stateMachine.TransitionTo(enemy.stateMachine.statePatrol);
        }
    }
    public void Exit()
    {
        enemy.player = null;
        enemy.ChangeAnimationSpeed(1f);
    }
}
