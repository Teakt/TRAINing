using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar : MonoBehaviour {

   public List<Spawner> tab;
   private List<Rigidbody2D> tabr2b;
   float timer ;
   float spawnRate = 1f;

    // Use this for initialization
    void Start () {
        tabr2b = new List<Rigidbody2D>();

		for(int i = 0; i < tab.Count; i++)
        {
            tabr2b[i] = tab[i].GetComponent<Rigidbody2D>();
        }
        timer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused != true)
        {


            if (timer >= spawnRate)
            {
                int randomInt = Random.Range(0, 6);
                tab[randomInt].ProjVersLeBas();
                timer = 0;
            }
            timer = (timer + 1f * Time.fixedDeltaTime);
        }
    }
}
