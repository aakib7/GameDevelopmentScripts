using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
// using UnityEngine.Scene;

public class PlayPauseBtn : MonoBehaviour
{
    GameObject mainPanel;
    public AudioSource dinaoAudio;
    public TMP_Text b1text;
    public int counter = 0;
   
   
   
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
    public void muteUmmute()
    {
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
    public void quitG() {
        print("Quit");
     Application.Quit();
 }
 public void Mainmenu(){
        SceneManager.LoadScene("LevelTwoScene");

    }
}
