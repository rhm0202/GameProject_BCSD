using UnityEngine;

public class Boss2SM : EnemySM
{
    public Boss2_StateReady stateReady;
    public new Boss2_StateChasing stateChasing;
    public Boss2_StateBattle stateBattle;
    public Boss2_StateNAttack stateNAttack;
    public Boss2_StateRAttack stateRAttack;
    public Boss2_StateRest stateRest;

    public Boss2SM(Boss_Stage2 enemy) : base(enemy)
    {
        stateReady = new Boss2_StateReady(enemy);
        stateChasing = new Boss2_StateChasing(enemy);
        stateBattle = new Boss2_StateBattle(enemy);
        stateNAttack = new Boss2_StateNAttack(enemy);
        stateRAttack = new Boss2_StateRAttack(enemy);
        stateRest = new Boss2_StateRest(enemy);

        CurrentState = stateReady;
        CurrentState.Enter();
    }
}
