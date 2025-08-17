using UnityEngine;

public class FlowerSM : EnemySM
{
    public Flower_StateAttack stateAttack;
    public Flower_StateBattle stateBattle;
    public new Flower_StateIdle stateIdle;
    public new Flower_StatePatrol statePatrol;

    public FlowerSM(Enemy_Flower enemy) : base(enemy)
    {
        stateIdle = new Flower_StateIdle(enemy);
        stateAttack = new Flower_StateAttack(enemy);
        stateBattle = new Flower_StateBattle(enemy);
        statePatrol = new Flower_StatePatrol(enemy);

        CurrentState = stateIdle;
        CurrentState.Enter();
    }
}
