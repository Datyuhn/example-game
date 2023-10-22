using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mechanics : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject gameOverObject;
    public GameObject timerObject;
    public GameObject scoreObject;
    public GameObject startObject;

    public float speed;
    public float rotationSpeed;
    public static Boolean ready, isDead;

    private void Start()
    {
        Time.timeScale = 1.0f;
        ready = false;
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        gameOverObject.SetActive(false);
        timerObject.SetActive(false);
        scoreObject.SetActive(false);
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
                StartGame();
            }
            Flap();
        }
        
        transform.rotation = Quaternion.Euler(0,0,rb.velocity.y*rotationSpeed);
    }
    
    private void StartGame()
    {
        rb.gravityScale = 1f;
        Flap();
        ready = true;
        timerObject.SetActive(true);
        scoreObject.SetActive(true);
        startObject.SetActive(false);
        if (!isDead)
        {
            FindObjectOfType<AudioManager>().Play("wing sound");
        }
    }

    private void Flap()
    {
        rb.velocity = Vector2.up * speed;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverObject.SetActive(true);
        isDead = true;
        FindObjectOfType<AudioManager>().Play("dead");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
