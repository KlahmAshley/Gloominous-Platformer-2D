using TMPro;
using UnityEngine;

public class OrbCollision : MonoBehaviour
{
    private OrbFactory orbFactory;

    public SpriteRenderer PlayerSprite;
    public Sprite redPlayer;
    public Sprite greenPlayer;
    public Sprite bluePlayer;

    public TMP_Text orbCounter;
    public int remainingOrbs = 8;
    public int collected = 0;

    public AudioSource orbPickupSound;

    void Awake()
    {
        AudioManager audioManager = Object.FindFirstObjectByType<AudioManager>().GetComponent<AudioManager>();
        orbPickupSound = audioManager.orbPickupSound;
    }
    void Start()
    {
        orbCounter.text = collected + "/" + remainingOrbs;
        
    }

    private void Update()
    {
        SceneSwitch();

    }

    void SceneSwitch()
    {
        if (remainingOrbs == collected)
        {
            SceneChanger.Instance.SetSceneByName("Scene2");
        }
    }
 
private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isOrb = false;
        if (collision.CompareTag("RedOrb"))
        {
            orbFactory = new RedOrbFactory();

            IOrb orb = orbFactory.ChangeOrb(redPlayer);

            orb.Collect(PlayerSprite, redPlayer);

            isOrb = true;

        }

        else if (collision.CompareTag("BlueOrb"))
        {
            orbFactory = new BlueOrbFactory();

            IOrb orb = orbFactory.ChangeOrb(bluePlayer);

            orb.Collect(PlayerSprite, bluePlayer);

            isOrb = true;
        }

        else if (collision.CompareTag("GreenOrb"))
        {
            orbFactory = new GreenOrbFactory();

            IOrb orb = orbFactory.ChangeOrb(greenPlayer);

            orb.Collect(PlayerSprite, greenPlayer);

            isOrb = true;
        }

        if (isOrb)
        {
            collision.gameObject.SetActive(false);

            AudioManager.Instance.PlaySound(orbPickupSound);

            collected++;

            orbCounter.text = collected + "/" + remainingOrbs;

            Object.FindFirstObjectByType<GameManager>().GetComponent<GameManager>().OrbCollected();
        }
    }
}




