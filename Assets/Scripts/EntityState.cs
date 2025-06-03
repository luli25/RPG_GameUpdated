using UnityEngine;


public class EntityState
{
    protected StateMachine stateMachine;
    protected string stateName;

    public EntityState(StateMachine _stateMachine, string _stateName)
    {
        this.stateMachine = _stateMachine;
        this.stateName = _stateName;
    }

    public virtual void Enter()
    {
        Debug.Log("I enter " + stateName);
    }

    public virtual void Update()
    {
        Debug.Log("Updating " + stateName);
    }

    public virtual void Exit()
    {
        Debug.Log("I exit " + stateName);
    }
}
