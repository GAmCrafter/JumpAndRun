using extensions;
using UnityEngine;
using UnityEngine.Animations;

public class meleeEnemyController : MonoBehaviour
{
    //creates variable for player
    GameObject player;

    //called on awake
    void Start()
    {
        //assigns player variable
        player = GameObject.FindWithTag("Player");
    }

    //called once per tick
    void FixedUpdate()
    {
        //looks at player
        transform.lookAt2D(player.transform, -90f, -85f, 85f);
    }
}
