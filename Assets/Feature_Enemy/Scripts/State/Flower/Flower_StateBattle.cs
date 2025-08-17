using UnityEngine;

public class Flower_StateBattle : IState
{
    private Enemy_Flower enemy;

    float timer = 0f;

    public Flower_StateBattle(Enemy_Flower enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        enemy.EnterBattle();
        timer = 0f;
        enemy.ChangeAnimation("Walk");
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        enemy.player = null;
    }

}
