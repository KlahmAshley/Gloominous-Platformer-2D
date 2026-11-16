using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float lifeTime = 5f;
    public ObjectPool bulletPool;
    Transform player;
    private Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (bulletPool == null)
        {
            GameObject poolObj = GameObject.Find("BulletPool");
            if (poolObj != null)
            {
                bulletPool = poolObj.GetComponent<ObjectPool>();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().ChangeHealth(-1);
        }
        else if (!collision.CompareTag("Enemy"))
        {
            bulletPool.ReturnObject(gameObject);
        }
    }
    
}
