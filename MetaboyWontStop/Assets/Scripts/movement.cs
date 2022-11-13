using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class movement : MonoBehaviour
{
    public TMP_Text speedText;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    Rigidbody rb;
    public float speed = 10;
    Animator playerAnim;
    public Transform[] Movepoints;
    int arraySelect;

    Vector3 currentMovepoint;
    bool moveRight;
    bool moveLeft;
    public cameraScript camScript;

    public Renderer faceRenderer;
    public Texture GameOver;
    bool over;
    public int score;

    void Start()
    {
        arraySelect = 1;
        currentMovepoint = Movepoints[1].position;
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
            speedText.text = "SPEED: "+ Mathf.Round(speed).ToString();
        }

        if (Intro.Instance.follow == true )
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
            /*
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                moveLeft = false;
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                moveRight = false;
            }*/
        }
       
    }
    private void FixedUpdate()
    {

        
        if(speed>0)
        {
            if (moveRight)
            {
                if(arraySelect<2)
                {
                    arraySelect++;
                    moveRight = false;
                }
                /*
                rb.velocity = Vector3.right * 20;
                */
            }
            else if (moveLeft)
            {
                if (arraySelect > 0)
                {
                    arraySelect--;
                    moveLeft = false;
                }
                /*
                rb.velocity = Vector3.left * 20;
                */
            }
            else
            {
                if (speed > 0)
                {
                    rb.velocity = Vector3.zero;
                }

            }
            transform.position = Movepoints[arraySelect].position;
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Good")
        {
            score++;
            speed++;
            gameOverText.text = "YOUR SCORE: " + score.ToString();
            scoreText.text = "SCORE: " + score.ToString();
            foreach (GameObject go in GameManager.Instance.Instances)
            {
                Destroy(go);
            }
            GameManager.Instance.Instances.Clear();
            GameManager.Instance.SpawnBlocks();
        }
        else if (other.gameObject.tag == "Bad")
        {
            score --;
            
            if (score<0)
            {
                score = 0;
            }
            scoreText.text = "SCORE: " + score.ToString();
            if (speed < 5)
            {
                speed = 0;
                if (!over)
                {
                    over = true;
                    playerAnim.SetBool("sip", false);
                    playerAnim.SetBool("die", true);
                    gameOverText.gameObject.SetActive(true);
                    gameOverText.text = "YOUR SCORE: \n" + score.ToString();
                    faceRenderer.materials[1].SetTexture("_BaseMap", GameOver);
                    rb.velocity = Vector3.zero;
                    rb.constraints = RigidbodyConstraints.None;
                    rb.AddForce((Vector3.back + Vector3.down) * 10, ForceMode.Impulse);
                }
                

            }
            foreach (GameObject go in GameManager.Instance.Instances)
            {
                Destroy(go);
            }
            GameManager.Instance.Instances.Clear();
            GameManager.Instance.SpawnBlocks();
        }
        else if (other.gameObject.tag == "Ugly")
        {
            speed = 0;
            if (score < 0)
            {
                score = 0;
            }
            scoreText.text = "SCORE: " + score.ToString();
            
            
            if (speed < 5)
            {
                speed = 0;
                if (!over)
                {
                    over = true;
                    playerAnim.SetBool("sip", false);
                    playerAnim.SetBool("die", true);
                    gameOverText.gameObject.SetActive(true);
                    gameOverText.text = "YOUR SCORE: \n" +  score.ToString();
                    faceRenderer.materials[1].SetTexture("_BaseMap", GameOver);
                    rb.velocity = Vector3.zero;
                    rb.constraints = RigidbodyConstraints.None;
                    rb.AddForce((Vector3.back + Vector3.down) * 10, ForceMode.Impulse);
                }
            }
            foreach (GameObject go in GameManager.Instance.Instances)
            {
                Destroy(go);
            }
            GameManager.Instance.Instances.Clear();
            GameManager.Instance.SpawnBlocks();
        }
    }
}
