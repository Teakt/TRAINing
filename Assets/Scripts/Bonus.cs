using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour{
    protected Player playerScript;
    protected GameController gameController;
    public enum BonusEnum {Shield,Potion,Armour}; 
    public BonusEnum _bonus;

    public GameObject player;

    public int bonusValue = 0;
    // Use this for initialization
    void Start () {
        
        playerScript=GameController.instance.player;
        gameController=GameController.instance;
        Init();
	}

    protected abstract void Init();

	// Update is called once per frame
	void Update () {
		
	}


    public void onclick()
    {
        if (isActivable())
        {
            if (RewardGaugeManager.instance.useBonus(bonusValue))
            {
                activate();
            }
            
        }
    }
    public abstract void activate();

    public abstract bool isActivable();
}
