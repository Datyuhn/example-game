using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mechanics : MonoBehaviour
{
    Rigidbody2D rg;
    public GameObject gameOverObject;
    public GameObject timerObject;
    public GameObject scoreObject;
    public GameObject startObject;

    public float speed;
    public static Boolean ready;

    void Start()
    {
        Time.timeScale = 1.0f;
        ready = false;
        rg = GetComponent<Rigidbody2D>();
        rg.gravityScale = -0.001f;
        gameOverObject.SetActive(false);
        timerObject.SetActive(false);
        scoreObject.SetActive(false);
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
            rg.gravityScale = -0.001f;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rg.gravityScale = 1;
            rg.AddForce(Vector2.up * speed);
            ready = true;
            timerObject.SetActive(true);
            scoreObject.SetActive(true);
            startObject.SetActive(false);
        }

    }
}
