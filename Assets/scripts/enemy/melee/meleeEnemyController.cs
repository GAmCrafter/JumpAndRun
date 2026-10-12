using extensions;
using UnityEngine;

public class meleeEnemyController : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        transform.lookAt2D(player.transform, -90f, -85f, 85f);
    }
}
