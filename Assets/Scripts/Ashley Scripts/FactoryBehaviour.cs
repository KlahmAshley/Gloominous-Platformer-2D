using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FactoryBehaviour : MonoBehaviour //comedian behaviour
{

   [SerializeField] private Factory factory;

    public Vector3 spawnPoint = Vector3.zero;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            SpawnProduct();
        }
    }

  private void SpawnProduct()
    {
        IProduct product = factory.GetProduct(spawnPoint);
    }


}
