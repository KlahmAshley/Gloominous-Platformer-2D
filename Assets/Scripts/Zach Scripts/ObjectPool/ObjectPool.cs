using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private ProjectileFactory projectileFactory;
    public GameObject projectilePrefab;
    private Queue<GameObject> objectPool = new Queue<GameObject>();
    bool isBad = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBad = !isBad;
            Debug.Log("using bad mode: " + isBad);
        }
    }
    public GameObject GetObject()
    {
        if (objectPool.Count > 0)
        {
            GameObject obj = objectPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        if (!isBad)
        {
            return projectileFactory.Create();
        }
        else
        {
            return Instantiate(projectilePrefab);
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }
}
