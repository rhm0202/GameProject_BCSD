using UnityEngine;

public class Flower_StateBattle : IState
{
    private Enemy_Flower enemy;


    public Flower_StateBattle(Enemy_Flower enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.EnterBattle();
        enemy.ChangeAnimation("Walk");
        enemy.ChangeAnimationSpeed(1.5f);
    }

    public void Update()
    {
        if(enemy.DistanceToPlayer() > enemy.DetectionRange)
        {
            enemy.stateMachine.TransitionTo(enemy.stateMachine.statePatrol);
        }
        if (enemy.DistanceToPlayer() > enemy.AttackRange)
        {
            enemy.Chase();
        }
        else if (enemy.DistanceToPlayer() < 12f)
        {
            enemy.Away();
        }
        else
        {
            enemy.stateMachine.TransitionTo(enemy.stateMachine.stateAttack);
        }
    }

    public void Exit()
    {
        enemy.ChangeAnimationSpeed(1f);
    }

}
