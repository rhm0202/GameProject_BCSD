using UnityEngine;

public class Flower_StateAttack : IState
{
    private Enemy_Flower enemy;

    public Flower_StateAttack(Enemy_Flower enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.ChangeAnimation("Attack");
        enemy.isAttacking = true;
        enemy.Attack();
    }
    public void Update()
    {
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

}
