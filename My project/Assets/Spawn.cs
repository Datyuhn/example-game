using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pipe;
    public float maxTime, height, distance;
    float timer = 0;
    private Queue<GameObject> pipeQueue = new Queue<GameObject>();

    void Start()
    {
        timer = maxTime;
        pipeQueue.Clear();
    }
    void Update()
    {
        if (timer > maxTime)
        {
            if (!Mechanics.isDead)
            {
                GameObject tmp = Instantiate(pipe, new Vector3(transform.position.x + Random.Range(-distance * 0.5f, distance * 0.5f), transform.position.y + Random.Range(-height, height), 0), Quaternion.identity);
                pipeQueue.Enqueue(tmp);

                if (pipeQueue.Count > 7)
                {
                    Destroy(pipeQueue.Dequeue(), 5f);
                }
            }
            timer = 0;
        }

        if (Mechanics.ready) 
        {
            timer += Time.deltaTime;
        }
    }
}
