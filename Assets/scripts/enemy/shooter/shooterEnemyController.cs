using UnityEngine;
using extensions;
public class shooterEnemyController : MonoBehaviour
{
    //creates variable for player
    GameObject player;

    //creates variable for projectile and lets it be assigned in inspector
    [SerializeField] GameObject projectile;

    //creates variable for end of cannon barrel and lets it be assigned in inspector
    [SerializeField] Transform firePoint;

    //calls once on awake
    void Start()
    {
        //assigns player variable
        player = GameObject.FindWithTag("Player");

        //makes enemy shoot every 2.5s
        InvokeRepeating("shoot", 0, 2.5f);
    }

    //calles once per tick
    private void FixedUpdate()
    {
        // looks at player
        transform.lookAt2D(player.transform, -90f, -65f, 65f);
    }

    //shoots
    void shoot()
    {
        //gets distance between self and player
        float playerdistance = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));

        // when player is closer than 8 units
        if(playerdistance < 8f)
        {
            //figures out where to spawn bullet
            Vector3 pos = firePoint.position + (firePoint.transform.position - transform.position);

            //spawns bullet at calculated point with same rotation as enemy
            GameObject shotPro = Instantiate(projectile, pos, transform.rotation);
        }
    }
}
