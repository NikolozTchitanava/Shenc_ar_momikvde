using UnityEngine;

public class BookFalling : MonoBehaviour
{
    public GameObject bookPrefab;
    public Transform player;
    public float spawnInterval = 2f;
    public float horizontalOffset = 2f;
    public float destroyHeight = -10f;

    private void Start()
    {
        InvokeRepeating("SpawnBook", spawnInterval, spawnInterval);
    }

    private void SpawnBook()
    {
        float randomOffset = Random.Range(-horizontalOffset, horizontalOffset);
        Vector3 spawnPosition = player.position + new Vector3(randomOffset, 10f, 0);
        GameObject book = Instantiate(bookPrefab, spawnPosition, Quaternion.identity);
        book.tag = "Obstacle"; 
        Destroy(book, 5f);
    }

    private void Update()
    {
        foreach (GameObject book in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            if (book.transform.position.y < destroyHeight)
            {
                Destroy(book);
            }
        }
    }
}

