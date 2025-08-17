using UnityEngine;

public class Boss2SM : EnemySM
{
    public Boss1_StateReady stateReady;
    public Boss2_StateBattle stateBattle;
    public Boss1_StateNAttack stateNAttack;

    public Boss2SM(Boss_Stage2 enemy) : base(enemy)
    {
        stateReady = new Boss1_StateReady(enemy);
        stateBattle = new Boss2_StateBattle(enemy);
        stateNAttack = new Boss1_StateNAttack(enemy);

        CurrentState = stateReady;
        CurrentState.Enter();
    }
}
