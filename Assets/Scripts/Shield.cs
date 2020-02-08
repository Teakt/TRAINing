using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shield : Bonus {
    
    private float timeOut=120f;
    private bool actif=false;
    private Collider2D col2D;
    public Image shieldImage;
    public Button shieldButton;
    public Text cooldown;

    public void Start()
    {
        col2D = player.GetComponent<Collider2D>();
        bonusValue = 300;
    }

    protected override void Init()
    {
        
        
    }
    public override bool isActivable()
    {
        return !actif;
    }


    public override void activate()
    {
        
        if (isActivable()) {
            Debug.Log("SHIELDO ACTIVATO ! ");
            actif = true;
            //timeOut = duringTime;
            
            col2D.isTrigger= false;
            shieldButton.enabled = false;
        }

    }

    public void Update()
    {
        if (isActivable() == false) // when the button is not active then timer is running in order to make the button active again
        {
            if (timeOut < 0)
            {
                cooldown.text =  "";
                actif = false;
                col2D.isTrigger = true;
                shieldImage.color = Color.white;
                shieldButton.enabled = true;
                timeOut = 120f;
            }
            else
            {
                cooldown.text = (timeOut/60f).ToString("F2")  + "Seconds ";
                shieldImage.color = Color.gray;
                timeOut--;
            }
        }  
    }
}
