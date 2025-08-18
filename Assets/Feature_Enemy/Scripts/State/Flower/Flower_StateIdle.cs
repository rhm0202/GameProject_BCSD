using UnityEngine;

public class Flower_StateIdle : IState
{
    private Enemy_Flower enemy;

    float timer = 0f;
    int waitingTime;

    public Flower_StateIdle(Enemy_Flower enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        timer = 0f;
        waitingTime = Random.Range(1, 3);
        enemy.ChangeAnimation("Idle");
        enemy.player = null;
        enemy.applyedSpeed = 0f;
    }

    public void Update()
    {
        if (!enemy.DetectPlayer())
        {
            timer += Time.deltaTime;
            if (timer >= waitingTime)
            {
                enemy.stateMachine.TransitionTo(enemy.stateMachine.statePatrol);
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
