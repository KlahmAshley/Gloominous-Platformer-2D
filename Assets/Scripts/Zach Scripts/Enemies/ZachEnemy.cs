using System.Collections;
using UnityEngine;

public class ZachEnemy : Enemy
{
    public Transform player;
    public GameObject projectile;
    public Transform projectileSpawnPoint;
    public ObjectPool bulletPool;

    public float stopRange = 5f;
    public float retreatRange = 2f;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public LayerMask groundLayer;

    RaycastHit2D hitLeft;
    RaycastHit2D hitRight;
    public float fireRate = 1.5f;
    private float nextFireTime = 0f;
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
        nextFireTime += Time.deltaTime;
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
            if (nextFireTime >= fireRate)
            {
                Shoot();
                nextFireTime = 0f;
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
        if (bulletPool != null && projectileSpawnPoint != null)
        {
            GameObject bullet = bulletPool.GetObject();
            bullet.transform.position = projectileSpawnPoint.position;
            bullet.transform.rotation = Quaternion.identity;

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Projectile component = bullet.GetComponent<Projectile>();

            if (rb != null && player != null)
            {
                Vector2 direction = (player.position - projectileSpawnPoint.position).normalized;
                rb.linearVelocity = direction * component.bulletSpeed;
                StartCoroutine(DisableAfterTime(bullet, component.lifeTime));
            }
        }
    }
    override protected void Die()
    {
        base.Die();
    }
    IEnumerator DisableAfterTime(GameObject bullet, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        bulletPool.ReturnObject(bullet);
    }
}
