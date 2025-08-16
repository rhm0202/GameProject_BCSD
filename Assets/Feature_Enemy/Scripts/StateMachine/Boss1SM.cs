using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Boss1SM : EnemySM
{
    public Boss1_StateNAttack stateNAttack;
    public Boss1_StateJAttack stateJAttack;
    public new Boss1_StateChasing stateChasing;
    public Boss1_StateReady stateReady;
    public Boss1_StateRest stateRest;

    public Boss1SM(Boss_Stage1 enemy) : base(enemy)
    {
        stateDead = new Enemy_StateDead(enemy);
        stateNAttack = new Boss1_StateNAttack(enemy);
        stateJAttack = new Boss1_StateJAttack(enemy);
        stateChasing = new Boss1_StateChasing(enemy);
        stateReady = new Boss1_StateReady(enemy);
        stateRest = new Boss1_StateRest(enemy);

        CurrentState = stateReady; // 초기 상태 설정
    }
}
