using UnityEngine;

public class Player_IdleState : EntityState
{
    public Player_IdleState(Player _player, StateMachine _stateMachine, string _stateName) : base(_player, _stateMachine, _stateName)
    {
    }

    public override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.W))
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
