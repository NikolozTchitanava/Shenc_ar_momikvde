using System.Collections;
using UnityEngine;

public class AntivirusMovement : MonoBehaviour
{
    public float moveSpeed = 10000000.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(StartMoving());
    }

    IEnumerator StartMoving()
    {
       
        yield return new WaitForSeconds(1f);

       
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }
}
