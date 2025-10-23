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

        if (player.groundDetected)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
