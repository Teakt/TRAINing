using System.Collections;

using UnityEngine;

using UnityEngine.SceneManagement; //Permet d'utiliser les fonctions qui gère les Changements de Scenes
using UnityEngine.UI; //Permet d'utiliser User Interface Functions

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen; //Ecran de chargement dans le hierarchy
    public Slider slider;  // Barre de chargement dans le Hierarchy

    public Text progressText; //Le chiffre dans la barre de chargement


	public void LoadLevel(int sceneIndex)
    {

        StartCoroutine(ChargerEnAsynchrone(sceneIndex));
        


    }

    IEnumerator ChargerEnAsynchrone(int sceneIndex)
    {
        // Mettre AsyncOperation operation permet de pouvoir regarder les informations dessus

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); // Permet de charger une scene en arrière plan ? 


        loadingScreen.SetActive(true);

        while (!operation.isDone) //operation.isDone == false
        {

            float progress = Mathf.Clamp01(operation.progress / 0.9f);  // Clamp = Restreindre, serrer / restreint la valeur entre 0 et 1 

            slider.value = progress;
            progressText.text = progress * 100f + "%"; 
            Debug.Log((progress * 100 ) + "%");

            

            yield return null; // wait till next frame before continuing 

        }    
    }
}
