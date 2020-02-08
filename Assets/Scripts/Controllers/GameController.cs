using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //public delegate void GameDelegate();




    public static GameController instance; // Permet de rendre l'instance unique et permettre aux autres objets,scripts de lui faire appel
    public static RewardGaugeManager instanceGauge;

    public bool GameIsOver = false; //variable qui permet de dire si la game est fini

    public Text scoreText; // Pour utiliser le score text 

    public int score = 0; // Le score duuuh

    public int gainScoreparSec = 100;



    public float RewardGauge = 0;


    public Player player; // Acces au script du player

    private void Awake() // Awake est appelé avant Start() , c'est dédié pour les controller par exemple , pour les Singletons 
    {
        if (instance == null)  // renforce le Singleton en vérifiant qu'il n'ya pas d'autres instances de GameController
        {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);  // Detruit cette instance de GameController si il y en a déjà 1 
        }
    }




    // Update is called once per frame
    void Update() {
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);

        instanceGauge.SetActualAmount(42f);
        Debug.Log("GAUGE :" + instanceGauge.GetActualAmount());

        if (GameIsOver == true)  // Si le joueur est mort
        {
            PlayerIsDead();

        }
        //Debug.Log(score);
        //Debug.Log("GameIsOver =" + GameIsOver.ToString());
    }

    public void PlayerIsDead() // Quand le joueur crève
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameIsOver = false;
    }

    public void PlayerIsScoring() // Le score qui monte tant que le joueur n'est pas mort 
    {
        if (GameIsOver == true)
        {
            return;
        }
        //score = score + gainScoreparSec;
        scoreText.text = "Score:" + score.ToString(); // Permet de connecter avec l'UI et d'afficher le score
    }

    public class RewardGaugeManager{
        

        private float max = 1000;
        private float actualAmount = 0;



        public RewardGaugeManager() {
        }

      

        public float AddActualAmount(float chiffre)
        {
            return actualAmount + chiffre;
        }

        public void SetActualAmount(float chiffre)
        {
            actualAmount = chiffre;
        }

        public float GetActualAmount()
        {
            return actualAmount;
        }



    }

    
}
