using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlower : Bonus
{

    private float timeOut = 300f, timeRefresh = 300f;
    private bool actif = false;
    // private Collider2D col2D;
    public Image timeSlowerImage;
    public Button timeSlowerButton;
    public Text cooldown;
    private Animator animator;
    public GameObject ZaWarudo;
    private AudioSource ZaWarudoAudio;

    // Use this for initialization
    public void Start()
    {
        bonusValue = 600;

        animator = GetComponentInChildren<Animator>();
        ZaWarudoAudio = GetComponent<AudioSource>();
    }

    protected override void Init()
    {
        timeOut = timeRefresh;
        
    }



    public override void activate()
    {
        if (isActivable())
        {
            Debug.Log("ZA WORLDO !  TOKI O TOMARE! ");
            actif = true;
            //timeOut = duringTime;

            

            timeSlowerButton.enabled = false;
            Time.timeScale = 0.05f;
            ZaWarudo.SetActive(true);
            ZaWarudoAudio.Play();
            
        }

    }

    public override bool isActivable()
    {
        return !actif;
    }



    public void Update()
    {
        
        if (isActivable() == false) // when the button is not active then timer is running in order to make the button active again
        {
            
            if (timeOut < 0)
            {
                cooldown.text = "";
                actif = false;
                //col2D.isTrigger = true;
                Time.timeScale = 1.0f;
                timeSlowerImage.color = Color.white;
                timeSlowerButton.enabled = true;
                timeOut = timeRefresh;
                ZaWarudo.SetActive(false);
                
            }
            else
            {
                

                cooldown.text = (timeOut / 60f).ToString("F2") + "Seconds ";
                timeSlowerImage.color = Color.gray;
                timeOut--;
            }
        }
        
        if (actif == true) // when the time slower is ON
        {
            if (timeOut == 0.9 * timeRefresh)
            {
                Time.timeScale = 0.1f;
            }
            if (timeOut == 0.8 * timeRefresh)
            {
                Time.timeScale = 0.2f;
            }
            if (timeOut == 0.7 * timeRefresh)
            {
                Time.timeScale = 0.3f;
            }
            if (timeOut == 0.6 * timeRefresh)
            {
                Time.timeScale = 0.4f;
            }
            if (timeOut == 0.5 * timeRefresh)
            {
                Time.timeScale = 0.3f;
            }
            if (timeOut == 0.4 * timeRefresh)
            {
                Time.timeScale = 0.6f;
            }
            if (timeOut == 0.3 * timeRefresh)
            {
                Time.timeScale = 0.7f;
            }
            if (timeOut == 0.2 * timeRefresh)
            {
                Time.timeScale = 0.8f;
            }
            if (timeOut == 0.1 * timeRefresh)
            {
                Time.timeScale = 0.9f;
            }
            
        }
        



    }
}
