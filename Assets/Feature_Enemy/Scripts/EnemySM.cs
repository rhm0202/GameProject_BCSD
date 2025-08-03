using UnityEngine;

public interface IState
{
    void Enter();
    void Update();
    void Exit();
}

public class EnemySM
{
    public IState CurrentState { get; private set; }

    public Enemy_StateIdle stateIdle;
    public Enemy_StateChasing stateChasing;
    public Enemy_StatePatrol statePatrol;

    public EnemySM(Enemy enemy)
    {
        stateIdle = new Enemy_StateIdle(enemy);
        stateChasing = new Enemy_StateChasing(enemy);
        statePatrol = new Enemy_StatePatrol(enemy);
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
