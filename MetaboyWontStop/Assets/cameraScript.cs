using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public bool follow;
    public GameObject Player;
    bool recordDistance;
    Vector3 distanceToPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!follow)
        {
            transform.LookAt(Player.transform.position + Vector3.up * 2);
        }
       
       
        if (follow)
        {
            if(!recordDistance)
            {
                recordDistance = true;
                distanceToPlayer = transform.position-Player.transform.position;
            }
            Vector3 followPos = Player.transform.position;
            followPos.y = 0;
            transform.position = followPos + distanceToPlayer;
        }
    }
}
