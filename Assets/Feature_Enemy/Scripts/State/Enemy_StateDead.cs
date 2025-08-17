using UnityEngine;

public class Enemy_StateDead : IState
{
    private Enemy enemy;

    public Enemy_StateDead(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.ChangeAnimation("Dead");
        enemy.applyedSpeed = 0f;
        enemy.GetComponent<Collider2D>().enabled = false;
        enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    }

    public void Update()
    {

    }
    public void Exit()
    {

    }
}
