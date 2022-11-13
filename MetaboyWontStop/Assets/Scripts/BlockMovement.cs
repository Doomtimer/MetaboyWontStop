using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    movement movScript;
    float speed = 10;
    Rigidbody rb;
    void Start()
    {
        movScript = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (Intro.Instance.GameStart)
        {
            speed = movScript.speed * 2;
            rb.MovePosition(transform.position + new Vector3(0, 0, -1)* Time.fixedDeltaTime*speed);

        }
    }
}
