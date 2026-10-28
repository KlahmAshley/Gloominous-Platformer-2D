using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    public float moveSpeed = 5f;
    public EnemyType enemyType;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {

    }
    protected virtual void Die()
    {
        if (gameObject.transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
