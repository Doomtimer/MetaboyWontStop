using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intro : MonoBehaviour
{
    public static Intro Instance;

    public bool GameStart;
    public bool follow;
    public Texture Sip1,Sip2,Sip3,Sip4,Sip5,Sip6;
    public Renderer faceRenderer;

    public float WaitTime = 0.1f;

    public Animator MetaBoyAnim;
    public cameraScript camScript;


    public TMP_Text startText;

    float switchTimer;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
    }

    void Update()
    {
        switchTimer += Time.deltaTime;

        if(!GameStart)
        {
            if (switchTimer > 0.3f)
            {
                if(startText.color == Color.red)
                {
                    startText.color = Color.black;
                }
                else
                {
                    startText.color = Color.red;
                }
                
                switchTimer = 0f;
            }
           
        }
        else
        {
            startText.gameObject.SetActive(false);
        }
       
    }

    public IEnumerator StartIntro()
    {
        MetaBoyAnim.SetBool("sip", true);
        yield return new WaitForSeconds(1f);

        faceRenderer.materials[1].SetTexture("_BaseMap", Sip1);
        yield return new WaitForSeconds(WaitTime);
        faceRenderer.materials[1].SetTexture("_BaseMap", Sip2);
        yield return new WaitForSeconds(WaitTime);
        faceRenderer.materials[1].SetTexture("_BaseMap", Sip3);
        yield return new WaitForSeconds(WaitTime);
        faceRenderer.materials[1].SetTexture("_BaseMap", Sip4);
        yield return new WaitForSeconds(WaitTime);
        faceRenderer.materials[1].SetTexture("_BaseMap", Sip5);
        yield return new WaitForSeconds(WaitTime);
        faceRenderer.materials[1].SetTexture("_BaseMap", Sip6);

        MetaBoyAnim.SetBool("run", true);
        GameStart = true;
        GameManager.Instance.SpawnBlocks();
        yield return new WaitForSeconds(1.5f);
        follow = true;
    }
}
