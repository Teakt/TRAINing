using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    

    //public GameObject Train;
    public GameObject prefab; 
    public float speed = 3f ;
    float tempSpeed = 0f;
    float distanceSpeciale;
    //float timer ;
    //float spawnRate = 2f;

    float Timer;

	// Use this for initialization
	void Start () {
        //timer = spawnRate;
        
	}

    // Update is called once per frame
    /*void Update () {
        if (Player.getX() == getX())
        {
            ProjVersLeBas();
            print(timer);

        }
        timer = (timer + 1f * Time.fixedDeltaTime);
    }

    void ProjVersLeBas()
    {
        if (timer >= spawnRate)
        {
            print(transform.position.x);
            GameObject Train = Instantiate(prefab, transform);
            Rigidbody2D trainRb = Train.GetComponent<Rigidbody2D>();
            trainRb.velocity = new Vector2(0,-speed);
            
        }
        timer = 0f;
        
    }
    */
    void Update () {
        
        
        

        Timer += Time.deltaTime;

        if (Timer > 2f)
        {

            Timer -= 2f;

           
            speed = Mathf.PingPong(speed + tempSpeed, 25f);
            tempSpeed = speed * 0.2f;
            print("SPEED" + speed);



            Timer = 0;



        }
    }

    public void ProjVersLeBas()
    {
        
        
         //print(transform.position.x);
         GameObject Train = Instantiate(prefab, transform,false);
         Rigidbody2D trainRb = Train.GetComponent<Rigidbody2D>();
        
        trainRb.velocity = new Vector2(0, -speed);

        

    }

    private float getX()
    {
        return transform.position.x; 
    }

    private float getY()
    {
        return transform.position.y;
    }

    public void ScoringSpecial()
    {

    }

    public float getSpeed()
    {
        return speed;
    }

   


}
