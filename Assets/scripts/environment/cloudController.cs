using UnityEngine;

public class cloudController : MonoBehaviour
{
    //creates variable for cloud speed
    float speed;

    //gets called on awaken
    void Start()
    {
        //sets speed to random value in range
        speed = Random.Range(0.2f, 2.25f);
    }

    //called once per frame
    void Update()
    {
        //moves cloud to the left
        transform.position -= new Vector3(1f * speed * Time.deltaTime, 0, 0);

        //if cloud is too far left
        if (transform.position.x <= -10)
        {
            //destroys cloud
            GameObject.Destroy(gameObject);
        }
    }
}
