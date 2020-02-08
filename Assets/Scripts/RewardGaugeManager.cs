using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardGaugeManager : MonoBehaviour {

    public static RewardGaugeManager instance = null;

    public Slider rewardGauge;

    public float max = 1000;
    public float actualAmount = 0;


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



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (actualAmount > max - 1)
        {
            actualAmount = max;
            print("GAUGE MAXED !!!!!");
        }
        rewardGauge.value = actualAmount;
        actualAmount++;
        
        print("GAUGE :" + actualAmount);
    }

        



    public bool useBonus(int value)
    {
        if (rewardGauge.value > value)
        {
            actualAmount=actualAmount - value;
            Debug.Log("Actual amount" + actualAmount + " - Value de : " + value);
            return true;
        }
        return false;
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
