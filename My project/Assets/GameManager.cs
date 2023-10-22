using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverObject;
    public GameObject timerObject;
    public GameObject scoreObject;
    public GameObject startObject;
    private bool isPlayed;
    void Start()
    {
        Time.timeScale = 1.0f;
        gameOverObject.SetActive(false);
        timerObject.SetActive(false);
        scoreObject.SetActive(false);
        isPlayed = false;
    }

    public void StartGame()
    {
        timerObject.SetActive(true);
        scoreObject.SetActive(true);
        startObject.SetActive(false);

    }
    public void GameOver()
    {
        //Time.timeScale = 0;
        gameOverObject.SetActive(true);
        if (!isPlayed)
        {
            FindObjectOfType<AudioManager>().Play("dead");
            isPlayed = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
