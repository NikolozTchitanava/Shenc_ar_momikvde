using System.Collections;

using UnityEngine;


public class SichumeFall : MonoBehaviour
{
    public float fallSpeed = 5.0f;
    public float respawnTime = 0.5f;

    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(FallAndRespawn());
    }

    IEnumerator FallAndRespawn()
    {
        while (true)
        {
            transform.position += new Vector3(0, -fallSpeed * Time.deltaTime, 0);
            if (transform.position.y < -screenBounds.y)
            {
                Respawn();
                yield return new WaitForSeconds(respawnTime);
            }
            else
            {
                yield return null;
            }
        }
    }

    void Respawn()
    {
        float randomX = Random.Range(-screenBounds.x, screenBounds.x);
        transform.position = new Vector2(randomX, screenBounds.y);
    }
}