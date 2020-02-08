using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
                                                            //private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
    private int level = 0;                                  //Current level number, expressed in game as "Day 1".

    private bool GameIsOver = false; //variable qui permet de dire si la game est fini

    public int gainScoreparSec = 5;

    public int score = 0; // Le score duuuh

    public Text scoreText; // Pour utiliser le score text

    public int highScore;

    public Text highScoreText;

    public Text highScoreText2;

    float Timer;

    public Spawner spawner;

   

  

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        //boardScript = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level 
        //InitGame();
    }

    private void Start()
    {
        highScoreText.text = "High Score :" + PlayerPrefs.GetInt("HighScore",0).ToString();
        highScoreText2.text = "High Score :" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    //Initializes the game for each level.
    /*void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        //boardScript.SetupScene(level);

    }*/



    //Update is called every frame.
    void FixedUpdate()
    {
        

        if (GameIsOver == false)
        {

            IsScoring();
        }

        
        ////if (GameIsOver == true)
        ////{
        ////    StartCoroutine(timeBeforeGameOver());
        ////    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ////    GameIsOver = false;
        ////}
        StartCoroutine(timeBeforeGameOver());
        
        if (score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High Score :" + score.ToString();
            highScoreText2.text = "High Score :" + score.ToString();


        }
        /*
        if (GameIsOver == true)
        {
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {

                highScoreText.text = "High Score :" + score.ToString();

            }
            return;
        }
        */
        
    }
    

  //Inutilise
    public void IsScoring() // Le score qui monte tant que le joueur n'est pas mort 
    {




        Timer += Time.deltaTime;

        if (Timer > 5f)
        {

            Timer -= 5f;

            //print("HELLO" + score);

            score = score + gainScoreparSec * (int)spawner.getSpeed() ;

            scoreText.text = "Score :" + score.ToString();

            print("ajout" + gainScoreparSec * (int)spawner.getSpeed());

            Timer = 0;


            
        }
        
        
        
        
    } 

    public void updateScore(int addScore)
    {
        score = score + addScore * (int)spawner.getSpeed();
        print("Addscore : " + addScore * (int)spawner.getSpeed());
        scoreText.text = "Score:" + score.ToString();
    }
    

    IEnumerator timeBeforeGameOver()
    {
        if (GameIsOver == true)
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameIsOver = false;
        }
        
    }

    public bool getGameIsOver()
    {
        return GameIsOver;
    }

    public void setGameIsOver(bool status)
    {
        GameIsOver = status ;
    }

    public void ResetHighScore()
    {

        //print(highScoreText.text);
        PlayerPrefs.DeleteAll();
        score = 0;
        highScoreText.text = "High Score : 0 ";
        highScoreText2.text = "High Score : 0 ";



        //print(highScoreText.text);
    }

   


}