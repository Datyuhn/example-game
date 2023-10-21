using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score;
    private string str = "Score:";

    void Start()
    {
        scoreText.text = str + "0";
    }

    public void addScore()
    {
        score++;
        scoreText.text = str + score.ToString();
    }
}
