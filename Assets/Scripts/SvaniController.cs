using UnityEngine;
using UnityEngine.SceneManagement;

public class SvaniController : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpForce = 10.0f;
    private Rigidbody2D rb;
    private int jumpCount;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 8)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }

        if (transform.position.y < -10)
        {
            LoseGame();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            int sceneIndex = Random.Range(0, 3); 
            if (sceneIndex == 0)
            {
            SceneManager.LoadScene("SampleScene");
            }
            else if (sceneIndex == 1)
            {
            SceneManager.LoadScene("sichume");
            }
            else
            {
            SceneManager.LoadScene("umaglesi");
            }
        }
        else if (collision.gameObject.CompareTag("Antivirusi") || 
                 collision.gameObject.CompareTag("Obstacle") || 
                 collision.gameObject.CompareTag("Obstacle"))
        {
            LoseGame();
        }
    }

    private void LoseGame()
    {
        Debug.Log("Lost the game!");
        Time.timeScale = 0; 
        SceneManager.LoadScene("menu");
    }
}
