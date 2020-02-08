using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovements : MonoBehaviour {

    public Button BoutonGauche;
    public Button BoutonDroite;
    
    
    float rightBorder = 1.0f;
    float leftBorder = -1.0f;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(PauseMenu.GameIsPaused);

    }

    public void BougeAGauche()
    {
        if (PauseMenu.GameIsPaused == true)
        {
            if (Player.getX() > leftBorder)
            {
                Player.getTransform().Translate(-0.5f, 0f, 0f);
            }

            print("GAUCHE ! ");
        }
    }
    public void BougeADroite()
    {
        if (PauseMenu.GameIsPaused == true)
        {
            if (Player.getY() < rightBorder)
            {
                Player.getTransform().Translate(0.5f, 0f, 0f);
            }
            print("Droite ! ");
        }
    }
}
