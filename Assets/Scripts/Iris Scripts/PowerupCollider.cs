using UnityEngine;

public class PowerupCollider : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    public AudioSource powerUpSound;

    void Awake()
    {
        if (player == null)
        {
            player = GetComponent<PlayerMovement>();
        }

        AudioManager audioManager = Object.FindFirstObjectByType<AudioManager>().GetComponent<AudioManager>();
        powerUpSound = audioManager.powerUpSound;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedPower"))
        {
            AudioManager.Instance.PlaySound(powerUpSound);
            player.moveSpeed += 4;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("JumpPower"))
        {
            AudioManager.Instance.PlaySound(powerUpSound);
            player.jumpForce += 3;
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("BigPower"))
        {
            AudioManager.Instance.PlaySound(powerUpSound);
            player.ChangeHealth(1);
            collision.gameObject.SetActive(false);
        }
    }
}
















