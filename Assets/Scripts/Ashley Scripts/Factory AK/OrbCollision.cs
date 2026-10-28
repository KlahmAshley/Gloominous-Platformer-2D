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
        if (collision.CompareTag("RedOrb"))
        {
            orbFactory = new RedOrbFactory();

            IOrb orb = orbFactory.DestoryandChangeOrb(redPlayer);

            orb.Collect(PlayerSprite, redPlayer);

            collision.gameObject.SetActive(false);

            collected++;

            orbCounter.text = collected + "/" + remainingOrbs;
        }

        else if (collision.CompareTag("BlueOrb"))
        {
            orbFactory = new BlueOrbFactory();

            IOrb orb = orbFactory.DestoryandChangeOrb(bluePlayer);

            orb.Collect(PlayerSprite, bluePlayer);

            collision.gameObject.SetActive(false);

            collected++;

            orbCounter.text = collected + "/" + remainingOrbs;
        }

        else if (collision.CompareTag("GreenOrb"))
        {
            orbFactory = new GreenOrbFactory();

            IOrb orb = orbFactory.DestoryandChangeOrb(greenPlayer);

            orb.Collect(PlayerSprite, greenPlayer);

            collision.gameObject.SetActive(false);

            collected++;

            orbCounter.text = collected + "/" + remainingOrbs;
        }

        else
        {
            Debug.Log("Not Triggering an Orb");
        }

    }
}




