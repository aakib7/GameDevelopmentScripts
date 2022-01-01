using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinoControllerScript : MonoBehaviour
{   
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // anim = GetComponent<Animator>();
        // anim.setBool("isWalk",false);
        // // anim.setBool('isDead',false);
        // // anim.setBool('isJump',false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            //  anim.setBool("isWalk",true);
            transform.Translate(0.04f,0,0);

        }
        
    }
}
