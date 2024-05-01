/**
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pkayercontroller : MonoBehaviour
{



    public float moveSpeed = 5f;        // Speed of the player's movement
    public float jumpForce = 5f;        // Jumping force
    private Rigidbody2D rb;             // Reference to the Rigidbody2D component
    private bool isGrounded=true;            // Check if the player is on the ground

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
    }



   /** // Start is called before the first frame update
    void Start()
    {
        
    }
   **/

// Update is called once per frame
/**   
void Update()
    {
        Move();
        
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            
            Jump();
            

        }
    }

    // Handles player movement using Rigidbody2D
    private void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");  // Get raw input for immediate response
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
    }

    // Handles player jumping
    private void Jump()
    {
  
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // Apply a vertical force for jumping
    }

    // Check if the player is on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log(" you are touching the ground");
        }
        else if (collision.gameObject.CompareTag("portal"))
        {
            Debug.Log("Yes you have won");
            gameWon();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log(" You are not touching the ground");
        }
    }

    void gameWon()
    {
        // Load the next scene. Ensure your scenes are added in the build settings and named correctly.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    void gameOver()
    {
        if(isGrounded==false airTime>5.0f)
        {

        }
    }
}
**/
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        // Speed of the player's movement
    public float jumpForce = 5f;        // Jumping force
    public float maxAirTime = 5f;       // Maximum time the player can be in the air
    private Rigidbody2D rb;             // Reference to the Rigidbody2D component
    private bool isGrounded = true;     // Check if the player is on the ground
    private float airTime = 0f;         // Time the player has been in the air

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    // Handles player movement using Rigidbody2D
    private void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");  // Get raw input for immediate response
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

        if (!isGrounded)
        {
            airTime += Time.deltaTime;
            if (airTime >= maxAirTime)
            {
                EndGame(); // Call game over function if player is in the air for too long
            }
        }
        else
        {
            airTime = 0f; // Reset air time when player is grounded
        }
    }

    // Handles player jumping
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // Apply a vertical force for jumping
        isGrounded = false; // Player is not on the ground after jumping
    }

    // Check if the player collides with the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("portal"))
        {
            gameWon();
        }
    }

    // Check if the player leaves the ground
 


    void gameWon()
    {
        // Load the next scene. Ensure your scenes are added in the build settings and named correctly.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }


    // Game over function
    private void EndGame()
    {
        // Implement game over logic here, such as loading a game over scene
        Debug.Log("Game Over");
        SceneManager.LoadScene(1); // Replace "GameOverScene" with your actual game over scene name
    }
}
