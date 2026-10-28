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
            player.moveSpeed += 4;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("JumpPower"))
        {
            player.jumpForce += 3;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("BigPower"))
        {
            player.ChangeHealth(1);
            collision.gameObject.SetActive(false);
        }
    }
}
















