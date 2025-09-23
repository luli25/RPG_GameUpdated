using UnityEngine;

public class Player_FallState : EntityState
{
    public Player_FallState(Player _player, StateMachine _stateMachine, string _animBoolName) 
        : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();
        
        // If player detects ground, if yes... go to IdleState
    }
}
