using UnityEngine;

public class ZachEnemy : Enemy
{
    public Transform player;
    public GameObject projectile;
    public Transform projectileSpawnPoint;

    public float stopRange = 5f;
    public float retreatRange = 2f;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public LayerMask groundLayer;

    RaycastHit2D hitLeft;
    RaycastHit2D hitRight;
    public float fireRate = 1.5f;
    protected override void Awake()
    {
        base.Awake();
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }
    void Update()
    {
        Move();
        CheckDistance();
        FacePlayer();
    }
    protected override void Move()
    {

    }
    private void CheckDistance()
    {
        //hitLeft = Physics2D.Raycast(groundCheckLeft.position, Vector2.down, 0.2f, groundLayer);
        //hitRight = Physics2D.Raycast(groundCheckRight.position, Vector2.down, 0.2f, groundLayer);
        //Debug.Log("right is: " + hitRight.collider + " Left is: " + hitLeft.collider);
        //float distanceToPlayer = Mathf.Abs(transform.position.x - player.position.x);

        //Vector2 target = new Vector2(player.position.x, transform.position.y);
        //if (distanceToPlayer > stopRange && hitRight.collider != null)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        //}
        //else if (distanceToPlayer < retreatRange && hitLeft.collider != null)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, target, -moveSpeed * Time.deltaTime);
        //}
        //else
        //{
            if (Time.time >= fireRate)
            {
                Shoot();
                fireRate = Time.time + 1.5f;
            }
        //}
    }
    public void FacePlayer()
    {
        if (player != null)

        {
            Vector3 direction = player.position - transform.position;
            if (direction.x > 0)
            {
                // Player is to the right
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1); // Face right
            }
            else if (direction.x < 0)
            {
                // Player is to the left
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1); // Face left
            }
        }
    }
    void Shoot()
    {
        if (projectile != null && projectileSpawnPoint != null)
        {
            Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
        }
    }
    override protected void Die()
    {
        base.Die();
    }
}
