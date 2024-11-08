using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MimtaniMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float rotationForce = 3f;
    private float counteractForce = 1.5f;
    public float moveSpeed = 0.52f;
    private bool shouldMove = true;
    public Transform magida;
    private bool isPositiveRotation = true;

    public GameObject mogeba;
    public GameObject wageba;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(RandomRotation());
        mogeba.SetActive(false);
        wageba.SetActive(false);
    }

    void FixedUpdate()
    {
        if (shouldMove)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(counteractForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-counteractForce);
        }

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            Lose();
        }
    }

    IEnumerator RandomRotation()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            float rotation = isPositiveRotation ? Random.Range(75, 80) : Random.Range(-80, -75);
            isPositiveRotation = !isPositiveRotation;
            rb.AddTorque(rotation);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == magida.gameObject)
        {
            shouldMove = false;
            rb.velocity = Vector2.zero;
            StopCoroutine(RandomRotation());
            Win();
        }
    }

    void Win()
    {
        mogeba.SetActive(true);
        StartCoroutine(LoadWinScene());
    }

    IEnumerator LoadWinScene()
    {
        yield return new WaitForSeconds(2); 

        int sceneIndex = Random.Range(0, 4); 
        if (sceneIndex == 0)
        {
           SceneManager.LoadScene("svaniinternetshi");
        }
        else if (sceneIndex == 1)
        {
           SceneManager.LoadScene("sichume");
        }
        else if (sceneIndex == 2)
        {
           SceneManager.LoadScene("SampleScene");
        }
        else
        {
           SceneManager.LoadScene("umaglesi");
        }
    }

    void Lose()
    {
        shouldMove = false;
        rb.velocity = Vector2.zero;
        wageba.SetActive(true);
        StopCoroutine(RandomRotation());
        StartCoroutine(LoadLoseScene());
    }

    IEnumerator LoadLoseScene()
    {
        yield return new WaitForSeconds(2); 
        SceneManager.LoadScene("menu");
    }
}
