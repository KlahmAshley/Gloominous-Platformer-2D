using System.Collections;
using TMPro;
using UnityEngine;

public class OrbCollisionOLD : MonoBehaviour
{
    private ParticleSpawner particleSpawner;
    private OrbFactory orbFactory;

    public SpriteRenderer PlayerSprite;
    public Sprite redPlayer;
    public Sprite greenPlayer;
    public Sprite bluePlayer;

    public TMP_Text orbCounter;
    public int remainingOrbs = 8;
    public int collected = 0;

    public AudioSource orbPickupSound;

    public ParticleSystem normalP;
    public ParticleSystem redP;
    public ParticleSystem greenP;
    public ParticleSystem blueP;
    public ParticleSystem currentP;

    public Transform pTransform;

    public Color red = Color.red;
    public Color green = Color.green;
    public Color blue = Color.blue;


    void Awake()
    {
        AudioManager audioManager = Object.FindFirstObjectByType<AudioManager>().GetComponent<AudioManager>();
        orbPickupSound = audioManager.orbPickupSound;

        particleSpawner = GetComponent<ParticleSpawner>();

        currentP = Instantiate(normalP, pTransform.position, pTransform.rotation);
        currentP.transform.SetParent(pTransform);
        currentP.transform.localScale = Vector3.one;
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

            IOrb orb = orbFactory.ChangeOrb(red);

            orb.Collect(PlayerSprite, red);

            isOrb = true;

            currentP = particleSpawner.spawnParticle(redP, pTransform, currentP);
            currentP.transform.SetParent(pTransform);
            currentP.transform.localScale = Vector3.one;

            StartCoroutine(ColourTime(5));

        }

        else if (collision.CompareTag("BlueOrb"))
        {
            orbFactory = new BlueOrbFactory();

            IOrb orb = orbFactory.ChangeOrb(blue);

            orb.Collect(PlayerSprite, blue);

            isOrb = true;

            currentP = particleSpawner.spawnParticle(blueP, pTransform, currentP);
            currentP.transform.SetParent(pTransform);
            currentP.transform.localScale = Vector3.one;

            StartCoroutine(ColourTime(5));
        }

        else if (collision.CompareTag("GreenOrb"))
        {
            orbFactory = new GreenOrbFactory();

            IOrb orb = orbFactory.ChangeOrb(green);

            orb.Collect(PlayerSprite, green);

            isOrb = true;

            currentP = particleSpawner.spawnParticle(greenP, pTransform, currentP);
            currentP.transform.SetParent(pTransform);
            currentP.transform.localScale = Vector3.one;

            StartCoroutine(ColourTime(5));
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

    private IEnumerator ColourTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        currentP = particleSpawner.spawnParticle(normalP, pTransform, currentP);
        currentP.transform.SetParent(pTransform);
        currentP.transform.localScale = Vector3.one;

    }
}
