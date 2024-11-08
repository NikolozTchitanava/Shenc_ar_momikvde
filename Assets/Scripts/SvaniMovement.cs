using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SvaniMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private SpriteRenderer spriteRenderer;
    public GameObject winText;
    public GameObject loseText;
    public GameObject sichume;
    private float survivalTime = 10f;
    private bool hasCollided = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (winText)
            winText.SetActive(false);
        if (loseText)
            loseText.SetActive(false);
        StartCoroutine(CheckWinCondition());
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * speed * Time.deltaTime;

        if (move < 0)
            spriteRenderer.flipX = false;
        else if (move > 0)
            spriteRenderer.flipX = true;

        survivalTime -= Time.deltaTime;
        if (survivalTime <= 0 && !hasCollided)
            Win();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sichume")
        {
            hasCollided = true;
            Lose();
        }
    }

    IEnumerator CheckWinCondition()
    {
        yield return new WaitForSeconds(survivalTime);
        if (!hasCollided)
            Win();
    }

    void Win()
    {
        winText.SetActive(true);
        StartCoroutine(LoadSampleScene());
    }

    void Lose()
    {
        loseText.SetActive(true);
        StartCoroutine(LoadSampleScene());
    }

    IEnumerator LoadSampleScene()
    {
        yield return new WaitForSeconds(2); 

        int sceneIndex = Random.Range(0, 4);
        if (sceneIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.GetSceneByName("SampleScene").buildIndex);
        }
        else if (sceneIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetSceneByName("sichume").buildIndex);
        }
        else if (sceneIndex == 2)
        {
           SceneManager.LoadScene("svaniinternetshi");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetSceneByName("umaglesi").buildIndex);
        }
    }
}
