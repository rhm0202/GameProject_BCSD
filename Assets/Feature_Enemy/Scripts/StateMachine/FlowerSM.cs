using UnityEngine;

public class FlowerSM : EnemySM
{
    public Flower_StateAttack stateAttack;

    public FlowerSM(Enemy_Flower enemy) : base(enemy)
    {
        stateAttack = new Flower_StateAttack(enemy);

        CurrentState = stateIdle;
    }
}
