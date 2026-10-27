using UnityEngine;

public class OrbCollisionTester : MonoBehaviour
{
    private OrbFactory orbFactory;

    public SpriteRenderer PlayerSprite;
    public Sprite redPlayer;
    public Sprite greenPlayer;
    public Sprite bluePlayer;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RedOrb"))
        {
            orbFactory = new RedOrbFactory();

            IOrb orb = orbFactory.DestoryandChangeOrb(redPlayer);

            orb.Collect(PlayerSprite, redPlayer);

            collision.gameObject.SetActive(false);
        }

        else if (collision.CompareTag("BlueOrb"))
        {
            orbFactory = new BlueOrbFactory();

            IOrb orb = orbFactory.DestoryandChangeOrb(bluePlayer);

            orb.Collect(PlayerSprite, bluePlayer);

            collision.gameObject.SetActive(false);
        }

        else if (collision.CompareTag("GreenOrb"))
        {
            orbFactory = new GreenOrbFactory();

            IOrb orb = orbFactory.DestoryandChangeOrb(greenPlayer);

            orb.Collect(PlayerSprite, greenPlayer);

            collision.gameObject.SetActive(false);
        }

        else
        {
            Debug.Log("Not Triggering an Orb");
        }

    }
}
















