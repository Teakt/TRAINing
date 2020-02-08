using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementsByTouch : MonoBehaviour
{

   
    private bool OnMobile=false;
    Transform perso;
    Vector3 persoPosition;
    Player player;
    float rightBorder = 1.0f;
    float leftBorder = -1.0f;


    Animator playerAnim;

    // Use this for initialization
    void Start()
    {
        perso = GetComponent<Transform>();
        player = GetComponent<Player>();
        playerAnim = GetComponent<Animator>();
        persoPosition = perso.position;

        
        
    }

    void Update()
    {


        //Check if we are running either in the Unity editor or in a standalone build.
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        
            
            if (PauseMenu.GameIsPaused != true)
            {
                bool left = Input.GetKeyDown(KeyCode.Q);
                bool right = Input.GetKeyDown(KeyCode.D);
                if (left && right)
                        return;

                if (left)
                {
                    BougeAGauche();
                }
                if (right)
                    BougeADroite();
            }
        
         //Check if we are running on iOS, Android, Windows Phone 8 or Unity iPhone
        #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        /*
        if (Input.touchCount > 0 && PauseMenu.GameIsPaused != true)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                print("TOUCH");
                var touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
                {
                    BougeAGauche();
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    BougeADroite();
                    playerAnim.Play("Right");
                }
            }
        }
        */

        #endif //End of mobile platform dependendent compilation section started above with #elif
    }



    public void BougeAGauche()
    {

        playerAnim.Play("Left");
        if (perso.transform.position.x > leftBorder)
        {
            player.updateScore();
            perso.Translate(-0.5f, 0f, 0f);
        }

        //print("GAUCHE ! ");
    }

    public void BougeADroite()
    {

        playerAnim.Play("Right");
        if (perso.transform.position.x < rightBorder)
        {
            player.updateScore();
            perso.Translate(0.5f, 0f, 0f);
        }
        //print("Droite ! ");
    }

}
