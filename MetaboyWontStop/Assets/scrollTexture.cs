using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollTexture : MonoBehaviour
{

    float scrollSpeed = 0.5f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if(Intro.Instance.GameStart)
        {
            float offset = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_BaseMap", new Vector2(0, -offset));
        }
        
    }
}
