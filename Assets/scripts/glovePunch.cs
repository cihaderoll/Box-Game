using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glovePunch : MonoBehaviour
{
    public Animation punch;

    


    void Start()
    {
        
            Invoke("PunchPlay", (Random.Range(0.5f, 3.0f)));
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void PunchPlay()
    {

        if (gameControl.instantiate.gameOver == false)
        {
            float delay = Random.Range(0.5f, 3.0f);
            if (!gameControl.instantiate.countDown && gameControl.instantiate.gamePause == false)
            {
                punch.Play();
                //gameControl.instantiate.playSfx();
            }
            Invoke("PunchPlay", delay);

        }
    }
}
