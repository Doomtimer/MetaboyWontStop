using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    movement movScript;
    float speed = 10;
    void Start()
    {
        movScript = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
    }

    void Update()
    {
        if(Intro.Instance.GameStart)
        {
            speed = movScript.speed*2;
            Vector3 moveVector = Vector3.MoveTowards(transform.position,  transform.position+ new Vector3( 0, 0, -1), Time.deltaTime * speed);
            transform.position = moveVector;
        }
        if(transform.position.z<-10)
        {
            Destroy(gameObject);
        }
    }
    
}
