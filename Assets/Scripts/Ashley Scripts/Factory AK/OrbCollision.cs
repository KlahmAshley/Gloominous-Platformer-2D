using System.Collections;
using TMPro;
using UnityEngine;
using System;

public class OrbCollision : MonoBehaviour
{
   // private ParticleSpawner particleSpawner;
    private OrbFactory orbFactory;

    private ParticleObjectPoolALL particlePoolAll;

    public static event Action LevelOver;

    public SpriteRenderer PlayerSprite;

    public Color red = Color.red;
    public Color green = Color.green;   
    public Color blue = Color.blue; 

    public TMP_Text orbCounter;
    public int remainingOrbs = 8;
    public int collected = 0;

    public AudioSource orbPickupSound;

    public ParticleSystem normalP;
    public ParticleSystem redP;
    public ParticleSystem greenP;
    public ParticleSystem blueP;
    public GameObject currentP;

    public Transform pTransform;


    void Awake()
    {
        AudioManager audioManager = UnityEngine.Object.FindFirstObjectByType<AudioManager>().GetComponent<AudioManager>();
        orbPickupSound = audioManager.orbPickupSound;

        particlePoolAll = GetComponentInChildren<ParticleObjectPoolALL>();

        ParticlesALL currentP = particlePoolAll.SpawnNormal();
        currentP.transform.SetParent(pTransform);
        currentP.transform.localScale = Vector3.one;

        //  particleSpawner = GetComponent<ParticleSpawner>();

        //    currentP = Instantiate(normalP, pTransform.position, pTransform.rotation);
        //    currentP.transform.SetParent(pTransform);
        //   currentP.transform.localScale = Vector3.one;
    }

    void Start()
    {
        orbCounter.text = collected + "/" + remainingOrbs;
        
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

            //      currentP = particleSpawner.spawnParticle(redP, pTransform, currentP);
            //     currentP.transform.SetParent(pTransform);
            //     currentP.transform.localScale = Vector3.one;

            ParticlesALL currentP = particlePoolAll.SpawnRed();
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

            //      currentP = particleSpawner.spawnParticle(blueP, pTransform, currentP);
            //      currentP.transform.SetParent(pTransform);
            //      currentP.transform.localScale = Vector3.one;

           
            ParticlesALL currentP = particlePoolAll.SpawnBlue();
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

            //     currentP = particleSpawner.spawnParticle(greenP, pTransform, currentP);
            //    currentP.transform.SetParent(pTransform);
            //   currentP.transform.localScale = Vector3.one;

            ParticlesALL currentP = particlePoolAll.SpawnGreen();
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

            UnityEngine.Object.FindFirstObjectByType<GameManager>().GetComponent<GameManager>().OrbCollected();
        }



        if (remainingOrbs == collected)
        {
            LevelOver?.Invoke();
            SceneChanger.Instance.SetSceneByName("Scene2");
        }


    }



    private IEnumerator ColourTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        particlePoolAll.SpawnNormal();
        //   currentP = particleSpawner.spawnParticle(normalP, pTransform, currentP);
        //  currentP.transform.SetParent(pTransform);
        //  currentP.transform.localScale = Vector3.one;

    }
}




