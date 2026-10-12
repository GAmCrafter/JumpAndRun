using UnityEngine;
using extensions;
public class shooterEnemyController : MonoBehaviour
{
    GameObject player;
    public GameObject projectile;

    public Transform firePoint;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        InvokeRepeating("shoot", 0, 2.5f);
    }

    private void FixedUpdate()
    {
        transform.lookAt2D(player.transform, -90f, -65f, 65f);
    }

    void shoot()
    {
        float playerdistance = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
        if(playerdistance < 8f)
        {
            Vector3 pos = firePoint.position + (firePoint.transform.position - transform.position);
            GameObject shotPro = Instantiate(projectile, pos, transform.rotation);
        }
    }
}
