using UnityEngine;

public class Flower_StateIdle : IState
{
    private Enemy_Flower enemy;

    float timer = 0f;

    public Flower_StateIdle(Enemy_Flower enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {

        enemy.ChangeAnimation("Idle");
    }

    public void Update()
    {
        if (!enemy.IsPlayerInRange())
        {
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                timer = 0f;
                enemy.stateMachine.TransitionTo(enemy.stateMachine.statePatrol);
            }
        }
        else
        {
            enemy.stateMachine.TransitionTo(enemy.stateMachine.stateAttack);
        }
    }

    public void Exit()
    {
        enemy.player = null;
    }
}
