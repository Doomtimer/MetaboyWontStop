using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    bool StartGame;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }

    void Update()
    {
        if (!StartGame)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame = true;
                Intro.Instance.StartCoroutine(Intro.Instance.StartIntro());
            }
        }

    }
}
