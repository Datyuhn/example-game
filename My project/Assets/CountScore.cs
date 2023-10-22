using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Mechanics.isDead)
        {
            FindObjectOfType<Score>().addScore();
            FindObjectOfType<AudioManager>().Play("get score");
        }
    }
}
