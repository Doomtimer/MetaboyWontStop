using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    bool StartGame;
    public Transform Spawnpoint1, Spawnpoint2, Spawnpoint3;
    public GameObject[] Boxes;
    public List<GameObject> Instances;
    public bool spawnable = true;
    float timer;
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
        SpawnableTimer();
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    void SpawnableTimer()
    {
        if (!spawnable)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                spawnable = true;
            }
        }
    }

    public void SpawnBlocks()
    {
        if(spawnable)
        {
            /*
            Spawnpoint1.position -= new Vector3(0, 0, 1);
            Spawnpoint2.position -= new Vector3(0, 0, 1);
            Spawnpoint3.position -= new Vector3(0, 0, 1);*/
            spawnable = false;
            timer = 0.1f;
            int prefab = Random.Range(0, 3);
            Instances.Add(Instantiate(Boxes[prefab], Spawnpoint1));
            

            switch (prefab)
            {
                case 0:
                   int prefab1;
                    if (Random.value < 0.5f)
                    {
                        prefab1 = 1;
                        Instances.Add(Instantiate(Boxes[prefab1], Spawnpoint2));
                        Instances.Add(Instantiate(Boxes[2], Spawnpoint3));
                    }
                    else
                    {
                        prefab1 = 2;
                        Instances.Add(Instantiate(Boxes[prefab1], Spawnpoint2));
                        Instances.Add(Instantiate(Boxes[1], Spawnpoint3));
                    }

                    break;
                case 1:
                    int prefab2;
                    if (Random.value < 0.5f)
                    {
                        prefab2 = 0;
                        Instances.Add(Instantiate(Boxes[prefab2], Spawnpoint2));
                        Instances.Add(Instantiate(Boxes[2], Spawnpoint3));
                    }
                    else
                    {
                        prefab2 = 2;
                        Instances.Add(Instantiate(Boxes[prefab2], Spawnpoint2));
                        Instances.Add(Instantiate(Boxes[0], Spawnpoint3));
                    }

                    break;

                case 2:
                    int prefab3;
                    if (Random.value < 0.5f)
                    {
                        prefab3 = 0;
                        Instances.Add(Instantiate(Boxes[prefab3], Spawnpoint2));
                        Instances.Add(Instantiate(Boxes[1], Spawnpoint3));
                    }
                    else
                    {
                        prefab3 = 1;
                        Instances.Add(Instantiate(Boxes[prefab3], Spawnpoint2));
                        Instances.Add(Instantiate(Boxes[0], Spawnpoint3));
                    }

                    break;
            }
        }
        
    }
}
