using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using extensions;

public class cloudSpawnerController : MonoBehaviour
{
    // creates List with all variations of cloud
    public List<GameObject> clouds;
    
    //Gets called once on awake
    void Start()
    {
        //calls spaenCloud once every 4-13 seconds
        InvokeRepeating("spawnCloud", 0, Random.Range(4f, 13f));
    }

    //spawns cloud
    void spawnCloud()
    {
        //decides random y value for cloud
        float randY = Random.Range(3f, 4.5f);

        //chooses a random variation of the cloud
        GameObject cloud = clouds.RandomElement<GameObject>();
        //instantiates that cloud
        GameObject spawned = GameObject.Instantiate(cloud);

        //sets position to spawner position x and random y
        spawned.transform.position = new Vector3(transform.position.x, randY, 0);
    }
}
