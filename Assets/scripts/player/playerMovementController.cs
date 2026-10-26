using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementController : MonoBehaviour
{
    //create and set movement variables (constant throughout runtime) for player
    [SerializeField] float speed = 250f;
    [SerializeField] float jumpForce = 7f;

    //create variables needed to check whether player is allowed to jump
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);
    [SerializeField] LayerMask groundLayer;

    //create changing variables for player movement
    Rigidbody2D rb;
    float moveInput;
    bool jumpRequested;
    bool grounded;

    //create variable to control gameOverScreen
    [SerializeField] GameObject gameOverScreen;

    //create changing combat variables
    int health;

    //control playerCollision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check whether collision is with enemy or enemyProjectile
        if(collision.gameObject.tag == "enemy" || collision.gameObject.tag == "enemyProjectile")
        {
            //get direction from player to collision object
            Vector3 dir = -((transform.position - collision.gameObject.transform.position).normalized);

            //calls function to handle collision with dir as input
            handleEnemyCollision(dir);
        }
    }

    //called on Awake
    void Start()
    {
        //asigns value to empty variables
        rb = GetComponent<Rigidbody2D>();

        //sets starting health to 3
        health = 3;

        //sets gameOverScreen to asleep
        gameOverScreen.SetActive(false);
    }

    //called every frame
    private void Update()
    {
        //checks whether player wants to jump
        if (Input.GetKeyDown(KeyCode.Space))
            jumpRequested = true;

        //checks input
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    //called every tick
    void FixedUpdate()
    {
        //checks whether player is touching the ground
        grounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer) != null;

        //sets player velocity to fit input
        rb.linearVelocity = new Vector2(moveInput * speed * Time.deltaTime, rb.linearVelocity.y);

        //if player is trying to jump and is on the ground, lets player jump
        if (jumpRequested && grounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        //stops jumpRequest
        jumpRequested = false;

        //handles Death
        handleDeath();
    }

    //handle PlayerDeath
    void handleDeath()
    {
        //if health is 0 or less, or y coordinate is below -15
        if (health <= 0 || transform.position.y <= -15)
        {
            // stops time
            Time.timeScale = 0;

            //activates gameOverScreen
            gameOverScreen.SetActive(true);
        }
    }

    //name is self explanatory
    void handleEnemyCollision(Vector3 dir)
    {
        //stops any movement
        rb.linearVelocity = Vector2.zero;

        //lowers health by 1
        health -= 1;

        //sets kmockback to dir
        rb.linearVelocity = dir;
    }
} 