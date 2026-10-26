using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 12f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.12f;
    [SerializeField] InputReader inputReader;
    [SerializeField] LayerMask groundLayer;
    Rigidbody2D rb;
    float horizontalInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (inputReader.inputData.jumpPressed && IsGrounded())
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        float moveDir = inputReader.inputData.walkInput;
        if (moveDir != 0)
        {
            GetComponent<SpriteRenderer>().flipX = moveDir > 0;
        }
        Vector2 velocity = rb.linearVelocity;
        velocity.x = moveDir * moveSpeed;
        rb.linearVelocity = velocity;
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) != null;
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}