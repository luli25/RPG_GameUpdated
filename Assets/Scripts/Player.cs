using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator {  get; private set; }

    public Player_IdleState idleState { get; private set; }
    public Player_MoveState moveState { get; private set; }
    public Vector2 moveInput { get; private set; }

    private PlayerInputSet playerInput;
    private StateMachine stateMachine;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        stateMachine = new StateMachine();
        playerInput = new PlayerInputSet();

        idleState = new Player_IdleState(this, stateMachine, "isIdle");
        moveState = new Player_MoveState(this, stateMachine, "isRunning");
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
