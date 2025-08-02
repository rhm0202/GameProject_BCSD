using UnityEngine;

public class Enemy_StatePatrol
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
        enemy.Move();
    }
    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}
