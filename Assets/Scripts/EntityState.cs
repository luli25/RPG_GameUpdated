using UnityEngine;

public abstract class EntityState
{
    protected Player player;
    protected StateMachine stateMachine;
    protected string stateName;

    public EntityState(Player _player, StateMachine _stateMachine, string _stateName)
    {
        this.player = _player;
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
