using UnityEngine;

public class cameraController : MonoBehaviour
{
    Transform target;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), 1f * Time.deltaTime);
    }
}
