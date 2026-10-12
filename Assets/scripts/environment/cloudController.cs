using UnityEngine;

public class cloudController : MonoBehaviour
{
    float speed;
    void Start()
    {
        speed = Random.Range(0.2f, 2.25f);
    }
    void Update()
    {
        transform.position -= new Vector3(1f * speed * Time.deltaTime, 0, 0);
        if (transform.position.x <= -10)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
