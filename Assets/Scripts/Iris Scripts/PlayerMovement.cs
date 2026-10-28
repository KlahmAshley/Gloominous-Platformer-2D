using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 12f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.12f;
    [SerializeField] InputReader inputReader;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float deathBarrierY = -6f;
    Rigidbody2D rb;
    float horizontalInput;
    int hp = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (inputReader.inputData.jumpPressed)
        {
            ExecuteJump();
        }
        if (transform.position.y < deathBarrierY)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        ExecuteWalk(inputReader.inputData.walkInput);
    }

    void ExecuteWalk(float moveDir)
    {
        if (inputReader.inputData.walkInput != 0)
        {
            GetComponent<SpriteRenderer>().flipX = moveDir > 0;
        }
        Vector2 velocity = rb.linearVelocity;
        velocity.x = moveDir * moveSpeed;
        rb.linearVelocity = velocity;
    }

    void ExecuteJump()
    {
        if (IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) != null;
    }

    public void ChangeHealth(int change)
    {
        if (hp <= 0)
        {
            Die();
        }
        else
        {
            hp += change;
            GetComponent<Transform>().localScale = Vector3.one * (2+hp);
        }
    }

    void Die()
    {
        Object.FindFirstObjectByType<SceneChanger>().GetComponent<SceneChanger>().ReloadScene();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ChangeHealth(-1);
        }
    }
}