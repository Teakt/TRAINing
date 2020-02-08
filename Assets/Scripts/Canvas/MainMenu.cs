using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Permet d'accéder à la deuxième Scene sur l'Editor Unity , là en gros ça passe à la Scene Game


    }

    public void QuitGame()
    {
        Debug.Log("ALLEZ SALUT");
        Application.Quit();

    }


}
