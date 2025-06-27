using UnityEngine;

public class Player : MonoBehaviour
{
    public StateMachine stateMachine {  get; private set; }

    public Player_IdleState idleState { get; private set; }
    public Player_MoveState moveState { get; private set; }
    public Vector2 moveInput { get; private set; }

    private PlayerInputSet playerInput;

    private void Awake()
    {
        stateMachine = new StateMachine();
        playerInput = new PlayerInputSet();

        idleState = new Player_IdleState(this, stateMachine, "idle");
        moveState = new Player_MoveState(this, stateMachine, "move");
    }

    private void OnEnable()
    {
        playerInput.Enable();

        playerInput.Player.Movement.performed += context => moveInput = context.ReadValue<Vector2>();
        playerInput.Player.Movement.canceled += context => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        playerInput.Disable();
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
