using UnityEngine;

public class Player_InAirState : EntityState
{
    public Player_InAirState(Player _player, StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.moveInput.x != 0)
        {
            player.SetVelocity(player.moveInput.x * (player.moveSpeed * player.inAirMoveSpeed), rb.linearVelocity.y);
        }
    }
}
