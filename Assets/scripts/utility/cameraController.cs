using UnityEngine;

public class cameraController : MonoBehaviour
{
    //create variable for player transform to be saved in
    Transform target;

    //called on awake
    void Start()
    {
        //assigns value to transform variable
        target = GameObject.FindWithTag("Player").transform;
    }

    //called every tick
    void FixedUpdate()
    {
        //makes camera follow player transform with slight delay
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y + 2, transform.position.z), 5f * Time.deltaTime);
    }
}
