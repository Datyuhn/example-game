using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mechanics : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float rotationSpeed;
    public float limitOffset;

    [HideInInspector]
    public static bool ready, isDead;

    private float minX, maxX, minY, maxY;
    private void Start()
    {
        ready = false;
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + limitOffset;
        maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - limitOffset;
        minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + limitOffset;
        maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - limitOffset;
    }

    private void Update()
    {
        if (!ready)
        {
            rb.gravityScale = 0;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!ready)
            {
                FindObjectOfType<GameManager>().StartGame();
                ready = true;
                rb.gravityScale = 2f;
            }
            if (!isDead)
            {
                Flap();
                FindObjectOfType<AudioManager>().Play("wing sound");
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);

        float limitPosX = Mathf.Clamp(transform.position.x, minX, maxX);
        float limitPosY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(limitPosX, limitPosY, transform.position.z);
    }

    private void Flap()
    {
        rb.velocity = Vector2.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameManager>().GameOver();
        isDead = true;
    }
}
