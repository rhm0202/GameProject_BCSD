using UnityEngine;

public class Boss1_StateChasing : IState
{
    Boss_Stage1 boss1;
    public Boss1_StateChasing(Boss_Stage1 boss)
    {
        this.boss1 = boss;
    }

    public void Enter()
    {
        boss1.ChangeAnimation("Walk");

    }
    public void Update()
    {
        boss1.Chase();
    }

    public void Exit()
    {
    }

}
