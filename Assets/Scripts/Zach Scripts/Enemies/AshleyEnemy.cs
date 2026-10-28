using UnityEngine;

public class AshleyEnemy : Enemy
{
    public int moveDirection = 1;
    public Transform groundCheck;
    public LayerMask groundLayer;

    RaycastHit2D hit;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        Move();
        PatrolCheck();
    }
    protected override void Move()
    {
        transform.Translate(Vector2.right * moveDirection * moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.layer != groundLayer)
        {
            FlipDirection();
        }
    }
    public void FlipDirection()
    {
        moveDirection *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void PatrolCheck()
    {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayer);
        if (hit.collider == null)
        {
            FlipDirection();
        }
    }
    override protected void Die()
    {
        base.Die();
    }
}
