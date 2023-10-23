using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float speed;
    private Vector3 tmp;
    // Start is called before the first frame update
    void Awake()
    {
        tmp = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Mechanics.isDead)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
    private void LateUpdate()
    {
        if (transform.position.x < 0)
        {
            transform.position = tmp;
        }
    }
}
