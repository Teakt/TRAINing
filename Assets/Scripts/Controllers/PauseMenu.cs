using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    public Button pauseButton; // Faire en sorte que quand on appuie sur le bouton pause ça affiche le menu pause

    public static bool GameIsPaused = false ; //indique si la jeu est mise en pause

    public GameObject pauseMenuUI;  // Pour pouvoir manipuler le pause menu UI
	
	// Update is called once per frame
	void Update () {
        
	}


    public void Resume() // Reprend le jeu , à mettre dans le boutton Play
    {
        pauseMenuUI.SetActive(false); // DesActive le Pause menu Ui quand on apelle la fonction Pause()
        Time.timeScale = 1f; //// Permet de RELANCER LA GAME , c la vitesse du jeu * 1f
        GameIsPaused = false;
        Debug.Log("GAME IS RESUMED");
    }


    public void Pause() // Pause le jeu, à mettre dans le button Pause
    {
        if (GameIsPaused == false)
        {


            pauseMenuUI.SetActive(true); // Active le Pause menu Ui quand on apelle la fonction Pause()
            Time.timeScale = 0f;  // Permet de FREEZE LA GAME , c la vitesse du jeu * 0f 
            GameIsPaused = true;
            Debug.Log("GAME IS PAUSED");
        }
        

    }

    public void GoBackToMainMenu() // Ramene le joueur au menu principale
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 ); // Permet d'accéder à la scene d'indice 0
        Resume();

    }

    public bool getGameIsPaused() 
    {
        return GameIsPaused;
    }

    
}
