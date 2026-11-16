using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectPrefab;
    private Queue<GameObject> objectPool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (objectPool.Count > 0)
        {
            GameObject obj = objectPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return Instantiate(objectPrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }
}
