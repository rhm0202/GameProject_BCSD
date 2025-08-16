using UnityEngine;

public class Boss1_StateJAttack : IState
{
    private Boss_Stage1 boss1;

    public Boss1_StateJAttack(Boss_Stage1 boss)
    {
        this.boss1 = boss;
    }

    public void Enter()
    {
        boss1.isAttacking = true;
        boss1.JumpAttack();
    }
    public void Update()
    {
        if(!boss1.isAttacking)
        {
            boss1.stateMachine.TransitionTo(boss1.stateMachine.stateRest);
        }
    }

    public void Exit()
    {
        boss1.isAttacking = false;
    }
}
