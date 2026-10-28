using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float lifeTime = 5f;
    Rigidbody2D rb;
    Transform player;
    private Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
                direction = (player.position - transform.position);
                rb.linearVelocity = direction * bulletSpeed;
                transform.rotation = Quaternion.LookRotation(Vector3.zero, direction);
            }
        }
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().ChangeHealth(-1);
        }
        else if (!collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
