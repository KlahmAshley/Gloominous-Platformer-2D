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

    //Ashley Changes: Adding my Audio references and calls, I am going to create a seoerate script to handle orb counter + scene changing for cleaner code!
    public AudioSource deathSound;
    public AudioSource jumpSound;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        AudioManager audioManager = Object.FindFirstObjectByType<AudioManager>().GetComponent<AudioManager>();
        deathSound = audioManager.deathSound;
        jumpSound = audioManager.jumpSound;
    }

    void Update()
    {
        //if (inputReader.inputData.jumpPressed)
        //{
        //    ExecuteJump();
        //}
        if (transform.position.y < deathBarrierY)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        ExecuteWalk(horizontalInput);
    }

    void ExecuteWalk(float moveDir)
    {
        if (moveDir != 0)
        {
            GetComponent<SpriteRenderer>().flipX = moveDir > 0;
        }
        Vector2 velocity = rb.linearVelocity;
        velocity.x = moveDir * moveSpeed;
        rb.linearVelocity = velocity;
    }
    public void SetHorizontal(float dir)
    {
        horizontalInput = dir;
    }
    public void ExecuteJump()
    {
        if (IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
            AudioManager.Instance.PlaySound(jumpSound);

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
            if (hp <= 0)
            {
                Die();
            }
            GetComponent<Transform>().localScale = Vector3.one * (hp*2 + 3.5f);
        }
    }

    public void Die()
    {
        Object.FindFirstObjectByType<SceneChanger>().GetComponent<SceneChanger>().LoadReplayScene();
        AudioManager.Instance.PlaySound(deathSound);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ChangeHealth(-1);
        }
    }
}