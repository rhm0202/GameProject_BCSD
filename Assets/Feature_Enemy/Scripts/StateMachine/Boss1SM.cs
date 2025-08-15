using UnityEngine;

public class Boss1SM : EnemySM
{
    public Boss1_StateNAttack stateNAttack;
    public new Boss1_StateChasing stateChasing;

    public Boss1SM(Boss_Stage1 enemy) : base(enemy)
    {
        stateIdle = new Enemy_StateIdle(enemy);
        statePatrol = new Enemy_StatePatrol(enemy);
        stateDead = new Enemy_StateDead(enemy);
        stateNAttack = new Boss1_StateNAttack(enemy);
        stateChasing = new Boss1_StateChasing(enemy);
        CurrentState = stateIdle; // 초기 상태 설정
    }
}
