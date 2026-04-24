using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator {  get; private set; }

    public Rigidbody2D rb { get; private set; }

    public Player_IdleState idleState { get; private set; }
    public Player_MoveState moveState { get; private set; }
    public Player_JumpState jumpState { get; private set; }
    public Player_FallState fallState { get; private set; }
    public Vector2 moveInput { get; private set; }

    public PlayerInputSet playerInput { get; private set; }

    private StateMachine stateMachine;

    [Header("Movement details")]
    public float moveSpeed;
    public float jumpForce = 5f;
    
    [Range(0, 1)]
    public float inAirMoveSpeed = 0.7f; // Should be from 0 to 1

    private bool facingRight = true;

    [Header("Collision detection")] 
    [SerializeField]
    private float groundCheckDistance;
    
    [SerializeField]
    private LayerMask whatIsGround;

    public bool groundDetected { get; private set; }


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        stateMachine = new StateMachine();
        playerInput = new PlayerInputSet();

        idleState = new Player_IdleState(this, stateMachine, "isIdle");
        moveState = new Player_MoveState(this, stateMachine, "isRunning");
        jumpState = new Player_JumpState(this, stateMachine, "jumpFall");
        fallState = new Player_FallState(this, stateMachine, "jumpFall");
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
        HandleGroundDetection();
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

    private void HandleGroundDetection()
    {
        groundDetected = Physics2D.Raycast(transform.position, Vector2.down
            , groundCheckDistance, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, - groundCheckDistance));
    }
}
