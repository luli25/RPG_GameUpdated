using UnityEngine;

public class Player_GroundedState : EntityState
{
    public Player_GroundedState(Player _player, StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if(input.Player.Jump.WasPressedThisFrame())
        {
            Debug.Log("Jump!");
        }
    }
}
