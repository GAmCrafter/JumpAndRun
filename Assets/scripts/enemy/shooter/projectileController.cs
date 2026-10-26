using extensions;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    //creates variable for speed of projectile
    public float speed = 1f;
    
    //creates variable for projectile's rigidbody
    Rigidbody2D rb;

    //gets called on collision with another game object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //self destructs
        GameObject.Destroy(gameObject);
    }

    //gets called once on awake
    void Start()
    {
        //assigns rigidbody variable
        rb = GetComponent<Rigidbody2D>();
    }

    //called once per tick
    void FixedUpdate()
    {
        //makes projectile move forwards
        rb.linearVelocity = transform.up * speed;
    }

    //if the projectile leaves the screen
    private void OnBecameInvisible()
    {
        //self destructs
        Destroy(gameObject);
    }
}
