using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10;
    Animator playerAnim;

    bool moveRight;
    bool moveLeft;
    public cameraScript camScript;
    void Start()
    {
        camScript = Camera.main.GetComponent<cameraScript>();
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnim.SetFloat("Speed", speed / 5);
        if(Intro.Instance.GameStart)
        {
            speed += speed * 0.01f*Time.deltaTime;
        }

        if (camScript.follow == true )
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moveLeft = true;
                moveRight = false;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                moveRight = true;
                moveLeft = false;
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                moveLeft = false;
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                moveRight = false;
            }
        }
       
    }
    private void FixedUpdate()
    {
        if(moveRight)
        {
            rb.velocity = Vector3.right*10;
        }
        else if(moveLeft)
        {
            rb.velocity = Vector3.left*10;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Good")
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Bad")
        {
            speed -= 2;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Ugly")
        {
            speed -= 5;
            Destroy(other.gameObject);
        }
    }
}
