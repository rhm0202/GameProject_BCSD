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
        enemy.ChangeAnimation("Walk");
        Debug.Log("Chasing Player");
    }

    public void Update()
    {
        enemy.Chase();
    }
    public void Exit()
    {
        enemy.player = null;
    }
}
