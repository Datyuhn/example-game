using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mechanics : MonoBehaviour
{
    Rigidbody2D rg;
    public GameObject gameOverObject;

    public float speed;
    public static Boolean ready;

    void Start()
    {
        Time.timeScale = 1.0f;
        ready = false;
        rg = GetComponent<Rigidbody2D>();
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }
    void Update()
    {
        if (!ready) 
        {
            rg.gravityScale = 0;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rg.gravityScale = 1;
            rg.AddForce(Vector2.up * speed);
            ready = true;
        }

    }
}
