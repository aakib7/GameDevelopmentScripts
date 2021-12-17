//Camera Script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour
{
    public GameObject heli;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - heli.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = heli.transform.position + offset;
    }

}
// ################################################################################################# 

// Scene Reload

using UnityEngine.SceneManagement;
public class ReloadScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BulletScript.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("MainScene"); //this will load the scene mentioned in argument, dont forget to add the header file 
        }
    }
}

// ################################################################################################# 
// Instantiate 
// Aply on Empty game object
public class ControllerScript : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            Vector3 enemypos = new Vector3(Random.Range(0, 1000), 10, Random.Range(0, 1000));
            Instantiate(enemy, enemypos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// ################################################################################################# 
// Instantiate  and move heli
public class HelicopterScript : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, 1);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -1);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.D))

        {
            transform.Translate(0, -1, 0);
        }

        if (Input.GetKeyDown(KeyCode.X))

        {
            Vector3 heliposition = transform.position;
            heliposition.y -= 1.5f;

            Instantiate(bullet, heliposition, transform.rotation);
        }


    }

   private void OnCollisionEnter(Collision col)
    {
        SceneManager.LoadScene("GameOverScene");
    }
}

// ################################################################################################# 
// set active explosion score and destroy

public class BulletScript : MonoBehaviour
{
    public GameObject explosion;
    public Text scoreText; //this is the text that has been placed in game scene as scoreText

    public static float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 1);
        explosion.SetActive(false); //it will hide the gameObject
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.name.StartsWith("Terrain"))
        {
            Destroy(col.gameObject); //it will destroy the object with which bullet will collide
            score += 10; //thats your own rule to increase score by 10
           
        }
        scoreText.text = "Score: " + score.ToString();
        print(score);

        Destroy(transform.gameObject); //destroy the bullet
        explosion.SetActive(true); //unhide 
        Instantiate(explosion, transform.position, transform.rotation);
    }
}

// ############################## ###############################################
// Button and text 
using UnityEngine.UI;

public class Print : MonoBehaviour
{
    public Button btn;
    public Button hello;
    public Text txt;
    // Start is called before the first frame update
    void Start()
    {
        // btn.GetComponent<Button>().onClick.AddListener(PrintOnClick);
        // // btn.onClick.AddListener(PrintOnClick);
        btn.GetComponent<Button>();
        hello.GetComponent<Button>();

        
    }

    // Update is called once per frame
    void Update()
    {   
    }

    public void PrintOnClick(){
        txt.text = "Hello";
        print("Button Click");
    }
    public void PrintOnClickHello(){
        // txt.text = "Hello";
        print("Hello Clicked");
    }
}
// #################################################################

// Touch, Animation and other concepts
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;

    public CharacterController2D controller;
    public float runSpeed = 40f;
    private float startTouchPosition, endTouchPosition;
    private Rigidbody2D rb;
    public float m_JumpForce;
    float speed = 0.05f;
    public GameObject cloud;

    private float health =100;
    public static float score = 0;

    public Text HealthText;
    public Text ScoreText;




    float move = 0f;
    float righthorizontalMove = 40f;
    float lefthorizontalMove = -40f;
    //private bool jumpAllowed = false;

    bool jump = false;
    bool crouch = false;
    public Vector2 pos;

    void Start()
    {
        HealthText.text = "Health:" + health.ToString();
        ScoreText.text = "Score:" + score.ToString();
        


        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            var touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position.y;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position.y;
                if (endTouchPosition > startTouchPosition)
                {
                    transform.Translate(Vector2.up * 150 * Time.fixedDeltaTime);
                }

            }
        }
        pos = transform.position;
        if(pos.x < -6.29){
            pos.x =  -3.52f;
            transform.position = pos;
        }
        if(pos.x > 48.43){
            SceneManager.LoadScene("LevelTwoScene");
        }  
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                controller.Move(lefthorizontalMove * Time.fixedDeltaTime, crouch, jump);
                anim.SetBool("isWalk", true);
            }
            if (touch.position.x > Screen.width / 2)
            {
                controller.Move(righthorizontalMove * Time.fixedDeltaTime, crouch, jump);
                anim.SetBool("isWalk", true);
            }
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("cloud"))
        {
            print("coll");
            transform.gameObject.transform.parent = cloud.transform;
        }

        if (collision.gameObject.name.StartsWith("Saw") || collision.gameObject.name.StartsWith("Mace") )
        {
            health -= 20;
            HealthText.text = "Health:" + health.ToString();
            if(health <= 0)
            {
                anim.SetTrigger("deadTrigger");
                SceneManager.LoadScene("GameOver");     
            }
        }
        if (collision.gameObject.name.StartsWith("Coin"))
        {
            score += 10;
            ScoreText.text = "Score:" + score.ToString();
            Destroy(collision.gameObject);
        } 
    }
}
/// #################################################################
// ping pong vertical
public class CloudMovementScript : MonoBehaviour
{
    public Vector2 pos1;
    public Vector2 pos2;
    public Vector2 posDiff = new Vector2(5f, 0f);
    float speed= 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = transform.position;
        pos2 = pos1 + posDiff;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
// Game Pause and resume
public void PauseGame ()
    {
        Time.timeScale = 0;
        mainPanel.gameObject.SetActive (true);
    }

   public void ResumeGame ()
    {
        Time.timeScale = 1;
        mainPanel.gameObject.SetActive (false);
        
    }
// Play PauseGame and Active Pannel
// Change btn text
// Mute and unmute
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayPauseBtn : MonoBehaviour
{
    GameObject mainPanel;
    public AudioSource dinaoAudio;
    public TMP_Text b1text;  // pass btn text here 
    public int counter = 0; // initialalize with one in the game
   
   
   
    // Start is called before the first frame update
    
    void Start()
    {
         mainPanel= GameObject.Find("Panel");
         mainPanel.gameObject.SetActive (false);
         

    }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
    public void PauseGame ()
    {
        Time.timeScale = 0;
        mainPanel.gameObject.SetActive (true);
    }

   public void ResumeGame ()
    {
        Time.timeScale = 1;
        mainPanel.gameObject.SetActive (false);
        
    }
    public void muteUmmute(){
        if (counter % 2 == 1) {
            dinaoAudio.mute = true;
        }
        else{
            dinaoAudio.mute = false;
        }
        TextChange();
        
    }

    void TextChange(){
       counter++;
        if (counter % 2 == 1) {
            b1text.text = "Mute";
        } else {
            b1text.text = "UnMute";
        }
    }
}