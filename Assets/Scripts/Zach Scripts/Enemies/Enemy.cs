using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

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
}
