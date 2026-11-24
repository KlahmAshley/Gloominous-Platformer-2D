using UnityEngine;
using UnityEngine.Pool;
using System.Collections;


public class ParticlesALL : MonoBehaviour
{
    public IObjectPool<ParticlesALL> Pool { get; set; }

    private void ReturnToPool()
    {
        Pool.Release(this);
    }


}
