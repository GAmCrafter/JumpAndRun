using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using extensions;

public class cloudSpawnerController : MonoBehaviour
{
    
    public List<GameObject> clouds;

    void Start()
    {
        InvokeRepeating("spawnCloud", 0, Random.Range(4f, 13f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnCloud()
    {
        float randY = Random.Range(3f, 4.5f);
        GameObject cloud = clouds.RandomElement<GameObject>();
        GameObject spawned = GameObject.Instantiate(cloud);
        spawned.transform.position = new Vector3(transform.position.x, randY, 0);
    }
}
