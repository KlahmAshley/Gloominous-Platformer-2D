using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.ParticleSystem;

public class ParticleObjectPool : MonoBehaviour
{
    //CODE IS PARTIALLY FROM : https://docs.unity.com/en-us/engine/6000.6/script-reference/unityengine/pool/objectpool1

    public GameObject twinkle;


    
    public IObjectPool<Particles> Pool
    {
        get
        {
            if (pool == null)
                pool =
                new ObjectPool<Particles>(
                    CreatedItem,
                      OnTakeFromPool,
                     OnReturnedToPool,
                     OnDestroyPoolObject,
                                 true,
                  defaultCapacity: 10,
                          maxSize :10
                      );
            return pool;
        }

    }

    
    private IObjectPool<Particles> pool;


 
    void Update()
    {
        // Press Space to spawn one pooled object for 1 second.
        if (Input.GetKeyDown(KeyCode.T))
        {
            Spawn();

        }

    }

    private Particles CreatedItem()
    {
       
        GameObject p = Instantiate(twinkle);
        Particles particle = p.GetComponent<Particles>();
        particle.transform.SetParent(transform);

        p.name = "Twinkle";
        particle.Pool = Pool;

        return particle;

    }

    private void OnReturnedToPool(Particles p) //On Release
    {
        p.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Particles p)
    {
        Destroy(p.gameObject);
    }

    private void OnTakeFromPool(Particles p) //On Get
    {
        p.gameObject.SetActive(true);
    }

    public void Spawn()
    {

        Particles part = Pool.Get();

        part.transform.position =
        Random.insideUnitSphere * 10;

        StartCoroutine(ReturnAfter(part, 1f));

    }
    private System.Collections.IEnumerator ReturnAfter(Particles pooledObject, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        // Give it back to the pool.
        pool.Release(pooledObject);
    }

}


//private void Awake()
// {
//      CurrentParticle = basicP;
//     var basicp = Pool.Get();
//  }


/*private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("RedOrb"))
    {
        checker.ischanged();
        CurrentParticle = redP;
        var redp = Pool.Get();

      //  redp.transform.position =
      //  Random.insideUnitSphere * 10;
    }
    else if (collision.CompareTag("BlueOrb"))
    {
        checker.ischanged();
        CurrentParticle = blueP;
        var bluep = Pool.Get();

       // bluep.transform.position =
       // Random.insideUnitSphere * 10;
    }
    else if (collision.CompareTag("GreenOrb"))
    {
        checker.ischanged();
        CurrentParticle = greenP;
        var greenp = Pool.Get();

        // greenp.transform.position =
        // Random.insideUnitSphere * 10;
    }


}*/

//}
