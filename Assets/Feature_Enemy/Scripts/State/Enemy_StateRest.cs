using UnityEngine;

public class Enemy_StateRest : IState
{
    private Enemy enemy;

    public Enemy_StateRest(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }
    public void Update()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

}
