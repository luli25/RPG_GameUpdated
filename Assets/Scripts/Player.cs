using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator {  get; private set; }

    public Rigidbody2D rb { get; private set; }

    public Player_IdleState idleState { get; private set; }
    public Player_MoveState moveState { get; private set; }
    public Vector2 moveInput { get; private set; }

    public PlayerInputSet playerInput { get; private set; }

    private StateMachine stateMachine;

    [Header("Movement details")]
    public float moveSpeed;

    private bool facingRight = true;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        stateMachine = new StateMachine();
        playerInput = new PlayerInputSet();

        idleState = new Player_IdleState(this, stateMachine, "isIdle");
        moveState = new Player_MoveState(this, stateMachine, "isRunning");
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
        HandleFlip(xVelocity);
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

    private void HandleFlip(float xVelocity)
    {
        if(xVelocity > 0 && facingRight == false)
        {
            Flip();

        } else if(xVelocity < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }
}
