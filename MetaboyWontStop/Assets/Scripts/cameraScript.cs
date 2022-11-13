using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject Player;
    Vector3 distanceToPlayer;
    Vector3 goalPos;
    Vector3 followPos;
    bool atPoint;
    void Start()
    {
        goalPos = new Vector3(transform.position.x, transform.position.y, -8f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        


        if (Intro.Instance.GameStart)
        {
            if (!atPoint)
            {
                transform.LookAt(Player.transform.position + Vector3.up * 2);
                if (transform.position != goalPos)
                {
                    Vector3 moveTo = Vector3.MoveTowards(transform.position, goalPos, 10*Time.fixedDeltaTime);
                    transform.position = moveTo;
                }
                else
                {
                    atPoint = true;
                    distanceToPlayer = transform.position - Player.transform.position;
                }
                
                followPos.y = 0;
            }
            else
            {
                followPos = Player.transform.position;
                followPos.y = 0;
                transform.position = followPos + distanceToPlayer;
            }
        }
       
    }
        
}
