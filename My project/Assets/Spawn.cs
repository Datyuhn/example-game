using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pipe;
    public float maxTime, height;
    float timer = 0;

    void Start()
    {
        timer = maxTime;
    }
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject tmp = Instantiate(pipe, new Vector3(transform.position.x, transform.position.y + Random.Range(-height, height), 0), Quaternion.identity);
            Destroy(tmp, 7f);
            timer = 0;
        }

        if (Mechanics.ready) 
        {
            timer += Time.deltaTime;
        }
    }
}
