using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementController : MonoBehaviour
{
    
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 7f;

    
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);
    [SerializeField] LayerMask groundLayer;

    Rigidbody2D rb;
    float moveInput;
    bool jumpRequested;
    bool grounded;

    int health = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy" || collision.gameObject.tag == "enemyProjectile")
        {
            Vector3 dir = (transform.position - collision.gameObject.transform.position).normalized;
            handleEnemyCollision(dir);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            jumpRequested = true;
    }


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer) != null;

        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (jumpRequested && grounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        jumpRequested = false;

        handleDeath();
    }

    void handleDeath()
    {
        if (health <= 0 || transform.position.y <= -15)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void handleEnemyCollision(Vector3 dir)
    {
        rb.linearVelocity = Vector2.zero;
        Vector3 dirForce = dir * 500;
        health -= 1;
        rb.AddForce(dirForce);
    }
}