using UnityEngine;

public class PowerupCollider : MonoBehaviour
{
    [SerializeField] PlayerMovement player;

    void Awake()
    {
        if (player == null)
        {
            player = GetComponent<PlayerMovement>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedPower"))
        {
            player.moveSpeed += 2;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("JumpPower"))
        {
            player.jumpForce += 2;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("BigPower"))
        {
            player.ChangeHealth(1);
            collision.gameObject.SetActive(false);
        }
    }
}
















