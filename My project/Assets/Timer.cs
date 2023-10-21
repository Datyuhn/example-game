using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timer;
    private string str = "Time: ";
    void Start()
    {
        timerText.text = str + "0";
        StartCoroutine(CountTime());
    }

    IEnumerator CountTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (Mechanics.ready)
            {
                timer++;
            }
            timerText.text = str + timer.ToString();
        }
        
    }
}
