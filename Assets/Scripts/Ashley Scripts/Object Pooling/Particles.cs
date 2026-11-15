using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

public class Particles : MonoBehaviour
{
    public IObjectPool<Particles> Pool { get; set; }
    private float waitTime = 2.0f;

    private void OnEnable()
    {
        Debug.Log("Enabled!");

    }

    private void ReturnToPool()
    {
        Pool.Release(this);
    }


}
