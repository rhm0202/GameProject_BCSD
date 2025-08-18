using UnityEngine;

public interface IState
{
    void Enter();
    void Update();
    void Exit();
}

public class EnemySM
{
    public IState CurrentState { get; protected set; }

    public Enemy_StateIdle stateIdle;
    public Enemy_StateChasing stateChasing;
    public Enemy_StatePatrol statePatrol;
    public Enemy_StateDead stateDead;

    public EnemySM(Enemy enemy)
    {
        stateIdle = new Enemy_StateIdle(enemy);
        stateChasing = new Enemy_StateChasing(enemy);
        statePatrol = new Enemy_StatePatrol(enemy);
        stateDead = new Enemy_StateDead(enemy);
        CurrentState = stateIdle;
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        CurrentState.Enter();
    }

    public void Update()
    {
        CurrentState.Update();
    }
}
