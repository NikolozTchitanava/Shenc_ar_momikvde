using UnityEngine;
using UnityEngine.SceneManagement;

public class mcocavi : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(-1, 1, 0).normalized;
        Debug.Log(moveDirection);
        transform.Translate(moveDirection * moveInput * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
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
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("You Lost!");
            SceneManager.LoadScene("menu");
        }
    }
}
