using UnityEngine;
using System.Collections;


public class ObjectPoolAKManager : MonoBehaviour
{
    private Particles checker;
    [SerializeField] private ParticleObjectPool pool;


    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.T))
            {
            pool.Spawn();
        }
    }

}
