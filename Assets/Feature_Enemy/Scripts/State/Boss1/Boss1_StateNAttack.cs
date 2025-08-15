using UnityEngine;

public class Boss1_StateNAttack : IState
{
    private Boss_Stage1 boss1;

    public Boss1_StateNAttack(Boss_Stage1 boss)
    {
        this.boss1 = boss;
    }

    public void Enter()
    {
        boss1.ChangeAnimation("Attack");
        boss1.isAttacking = true;
        boss1.NormalAttack();
    }
    public void Update()
    {
        
    }

    public void Exit()
    {
        boss1.isAttacking = false;
        boss1.ChangeAnimation("Idle");
    }    
}
