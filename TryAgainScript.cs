using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TryAgainScript : MonoBehaviour
{ 
    public Button btn;
    public Text scoreText;
    public Text highScoreText;
    public static int highScore;
    public static int score1;
    void Start()
    {
        btn.GetComponent<Button>().onClick.AddListener(Reload1);
        highScore = PlayerPrefs.GetInt("High Score", 0);
        highScoreText.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        score1 = PlayerMovement.score;
        scoreText.text = "Score: " + PlayerMovement.score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
        if (score1 > highScore)
    {
        highScoreText.text = "High Score: " + score1.ToString();
    }
        // txt.text = "Score:" + PlayerMovement.score.ToString();
        
        // if(Input.GetKey(KeyCode.R))
        // {
        //     SceneManager.LoadScene("LevelOneScene"); //this will load the scene mentioned in argument, dont forget to add the header file 
        //     print(PlayerMovement.score);
        // }
    }
    void Reload1(){
        SceneManager.LoadScene("LevelOneScene");
        // PlayerMovement.score = 0;

    }
    
}
