using UnityEngine;
using UnityEngine.Pool;

public class ParticleObjectPoolALL : MonoBehaviour
{
    //CODE IS PARTIALLY FROM : https://docs.unity.com/en-us/engine/6000.6/script-reference/unityengine/pool/objectpool1

    public GameObject normalP;
    public GameObject redP;
    public GameObject greenP;
    public GameObject blueP;

    public Transform playerT;

    //Normal Pool
    public IObjectPool<ParticlesALL> normalPool
    {
        get
        {
            if (normalpool == null)
            {
                normalpool =
                new ObjectPool<ParticlesALL>(
                      CreatedItemNormal,
                         OnTakeFromPool,
                       OnReturnedToPool,
                    OnDestroyPoolObject,
                                   true,
                    defaultCapacity: 1,
                            maxSize: 1 
                        );
            }
            return normalpool;
        }
    }
    private IObjectPool<ParticlesALL> normalpool;
   
//Red Pool
    public IObjectPool<ParticlesALL> redPool
    {
        get
        {
            if (redpool == null)
            {
                redpool =
                new ObjectPool<ParticlesALL>(
                         CreatedItemRed,
                         OnTakeFromPool,
                       OnReturnedToPool,
                    OnDestroyPoolObject,
                                   true,
                    defaultCapacity: 1,
                            maxSize: 1
                        );
            }
            return redpool;
        }
    }
    private IObjectPool<ParticlesALL> redpool;


//Green Pool
    public IObjectPool<ParticlesALL> greenPool
    {
        get
        {
            if (greenpool == null)
            {
                greenpool =
                new ObjectPool<ParticlesALL>(
                       CreatedItemGreen,
                         OnTakeFromPool,
                       OnReturnedToPool,
                    OnDestroyPoolObject,
                                   true,
                    defaultCapacity: 1,
                            maxSize: 1
                        );
            }
            return greenpool;
        }
    }
    private IObjectPool<ParticlesALL> greenpool;


    //Blue Pool
    public IObjectPool<ParticlesALL> bluePool
    {
        get
        {
            if (bluepool == null)
            {
                bluepool =
                new ObjectPool<ParticlesALL>(
                        CreatedItemBlue,
                         OnTakeFromPool,
                       OnReturnedToPool,
                    OnDestroyPoolObject,
                                   true,
                    defaultCapacity: 1,
                            maxSize: 1
                        );
            }
            return bluepool;
        }
    }
    private IObjectPool<ParticlesALL> bluepool;

   // currentP.transform.SetParent(pTransform);
            //     currentP.transform.localScale = Vector3.one;

    private ParticlesALL CreatedItemNormal()
    {
        GameObject p = Instantiate(normalP, playerT);
        p.transform.SetParent(playerT);
        p.transform.localScale = Vector3.one;

        ParticlesALL particles = p.GetComponent<ParticlesALL>();

        p.name = "Normal Particle";
        particles.Pool = normalPool;

        return particles;

    }

    private ParticlesALL CreatedItemRed()
    {

        GameObject p = Instantiate(redP, playerT);
        p.transform.SetParent(playerT);
        p.transform.localScale = Vector3.one;

        ParticlesALL particles = p.GetComponent<ParticlesALL>();

        p.name = "Red Particle";
        particles.Pool = redPool;

        return particles;

    }

    private ParticlesALL CreatedItemBlue()
    {

        GameObject p = Instantiate(blueP, playerT);
        p.transform.SetParent(playerT);
        p.transform.localScale = Vector3.one;

        ParticlesALL particles = p.GetComponent<ParticlesALL>();

        p.name = "Blue Particle";
        particles.Pool = bluePool;

        return particles;

    }

    private ParticlesALL CreatedItemGreen()
    {

        GameObject p = Instantiate(greenP, playerT);
        p.transform.SetParent(playerT);
        p.transform.localScale = Vector3.one;

        ParticlesALL particles = p.GetComponent<ParticlesALL>();

        p.name = "Green Particle";
        particles.Pool = greenPool;

        return particles;

    }


    private void OnReturnedToPool(ParticlesALL p) //On Release
    {
        p.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(ParticlesALL p)
    {
        Destroy(p.gameObject);
    }
    
    private void OnTakeFromPool(ParticlesALL p) //On Get
    {
        p.gameObject.SetActive(true);
    }

    public ParticlesALL SpawnNormal()
    {
        ParticlesALL part = normalPool.Get();
        StartCoroutine(ReturnAfterNormal(part, 5f));
        return part;

    }

    public ParticlesALL SpawnRed()
    {

        ParticlesALL part = redPool.Get();
        StartCoroutine(ReturnAfterRed(part, 5f));
        return part;

    }

    public ParticlesALL SpawnBlue()
    {

        ParticlesALL part = bluePool.Get();
        StartCoroutine(ReturnAfterBlue(part, 5f));
        return part;

    }

    public ParticlesALL SpawnGreen()
    {

        ParticlesALL part = greenPool.Get();
        StartCoroutine(ReturnAfterGreen(part, 5f));
        return part;

    }

    private System.Collections.IEnumerator ReturnAfterNormal(ParticlesALL pooledObject, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        // Give it back to the pool.
        normalpool.Release(pooledObject);
    }

    private System.Collections.IEnumerator ReturnAfterRed(ParticlesALL pooledObject, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        // Give it back to the pool.
        redpool.Release(pooledObject);
    }
    private System.Collections.IEnumerator ReturnAfterBlue(ParticlesALL pooledObject, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        // Give it back to the pool.
        bluepool.Release(pooledObject);
    }
    private System.Collections.IEnumerator ReturnAfterGreen(ParticlesALL pooledObject, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        // Give it back to the pool.
        greenpool.Release(pooledObject);
    }


}
