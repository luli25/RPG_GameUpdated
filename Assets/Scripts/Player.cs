using UnityEngine;

public class Player : MonoBehaviour
{
    public StateMachine stateMachine {  get; private set; }

    private Player_IdleState idleState;

    private void Awake()
    {
        stateMachine = new StateMachine();

        idleState = new Player_IdleState(stateMachine, "idle");
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
}
