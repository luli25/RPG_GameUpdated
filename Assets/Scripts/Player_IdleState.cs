using UnityEngine;

public class Player_IdleState : Player_GroundedState
{
    public Player_IdleState(Player _player, StateMachine _stateMachine, string _stateName) : base(_player, _stateMachine, _stateName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (player.moveInput.x != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }

        
    }
}
