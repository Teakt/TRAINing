using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton class which contains the stats that only the player has
/// </summary>
public class Player : MonoBehaviour
{
    [HideInInspector]public static Player instance = null;

    //public delegate void PlayerDelegate();
    //public static event PlayerDelegate OnPlayerDodge;

    GameManager game;

    public RewardGaugeManager rewardGauge;


    public float RangeScoring;//Distance ou le score prend effet
    public bool EnVie;
    bool debugDontDie=false;






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

       

       
    }

    void Start()
    {
        EnVie = true;
    }

    private void Update()
    {
        //Debug.DrawLine(transform.position, transform.position + (new Vector3(0, .1f, 0) * RangeScoring), Color.cyan, 0f);
        Debug.Log("EnVie égale :" + EnVie);
    }


    public void updateScore()
    {
        Debug.DrawLine(transform.position, transform.position+(new Vector3(0, .1f,0)*RangeScoring), Color.red, 1f);
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0,.1f), RangeScoring, LayerMask.GetMask("Train"));

        
        
        if (hit)
        {
           
            Debug.DrawLine(transform.position,hit.collider.gameObject.transform.position, Color.cyan,3f);
            float distance = hit.distance;
        
            int addScore = (int)((1/(distance+1))*10);
            addScore = addScore*addScore* addScore;
            
            
            Debug.Log("Distance" +distance +"HitDistance"+hit.distance+ " Score"+addScore);
            GameManager.instance.updateScore(addScore);

            if (EnVie == true && distance< 1)
            {
                Dodge();
            }

            
        }
    }

    public static GameObject getObject()
    {
        return instance.gameObject;
    }

    public static Transform getTransform()
    {
        return instance.transform;
    }

    public static float getX()
    {
        return instance.transform.position.x;
    }

    public static float getY()
    {
        return instance.transform.position.y;
    }

    public static bool getEnVie()
    {
        return instance.EnVie; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (debugDontDie) return;
        print("LOSER");
        EnVie = false;
        Debug.Log("EnVie égale :" + EnVie);
        // Animation de mort du perso 
        // Death sound effect
        GameManager.instance.setGameIsOver(true);
        this.gameObject.SetActive(false);
    }

    public void Dodge()
    {
        rewardGauge.actualAmount = rewardGauge.actualAmount + 100;
        Debug.Log("PERFECTO DODGU !");
    }

    
    
}

