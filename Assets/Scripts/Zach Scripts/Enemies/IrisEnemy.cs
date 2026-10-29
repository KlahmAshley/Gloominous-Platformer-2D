using System.Threading;
using UnityEngine;

public class IrisEnemy : Enemy
{
    [SerializeField] LayerMask ignoreLayers;
    [SerializeField] private float boostForce = 5f;
    [SerializeField] private float horizontal = 3f;
    [SerializeField] private float boostInterval = 2f;
    private float interval;
    [SerializeField] private float fallingGrav = 0.2f;
    [SerializeField] private float normalGrav = 0.5f;
    [SerializeField] private float maxFallSpeed = 1f;

    [SerializeField] Transform target;

    private float boostTimer;
    private bool isBoosting;
    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        boostTimer = boostInterval;
        interval = boostInterval;

        if (target == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                target = playerObj.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        boostTimer -= Time.deltaTime;
        if (boostTimer < 0)
        {
            Move();
            boostTimer = boostInterval;
        }
        if (isBoosting && rb.linearVelocity.y <= 0)
        {
            isBoosting = false;
            rb.gravityScale = fallingGrav;
        }
    }
    private void FixedUpdate()
    {
        if (!isBoosting && rb.linearVelocity.y < -maxFallSpeed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -maxFallSpeed);
        }
        if (target.position.y > transform.position.y)
        {
            boostInterval /= 2;
        }
        else
        {
            boostInterval = interval;
        }
    }
    protected override void Move()
    {
        if (target == null) return;

        isBoosting = true;
        rb.gravityScale = normalGrav;

        float directionX = Mathf.Sign(target.position.x - transform.position.x);
        rb.linearVelocity = new Vector2(directionX * horizontal, boostForce);
    }
    override protected void Die()
    {
        base.Die();
    }
    void Sink()
    {

    }
}
