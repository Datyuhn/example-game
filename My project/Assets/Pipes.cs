using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed;
    void Update()
    {
        if (!Mechanics.isDead)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
