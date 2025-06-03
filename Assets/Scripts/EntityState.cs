using UnityEngine;

public class EntityState
{
    protected StateMachine stateMachine;

    public EntityState(StateMachine _stateMachine)
    {
        this.stateMachine = _stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }
}
