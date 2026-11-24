using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

public class Particles : MonoBehaviour
{
    public IObjectPool<Particles> Pool { get; set; }
  

    private void OnEnable()
    {

    }

    private void ReturnToPool()
    {
        Pool.Release(this);
    }


}
