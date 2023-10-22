using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timer;
    private string str = "Time:";
    void Start()
    {
        timerText.text = str + "0";
        StartCoroutine(CountTime());
    }   

    IEnumerator CountTime()
    {
        while (true)
        {
            yield return new WaitUntil(() => Mechanics.ready == true);
            if (Mechanics.ready && !Mechanics.isDead)
            {
                timer++;
                yield return new WaitForSeconds(1);
            }
            timerText.text = str + timer.ToString();
        }
    }
}
