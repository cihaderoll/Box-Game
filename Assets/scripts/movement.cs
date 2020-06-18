using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public static movement instantiate;
    

    private float targetPoint = -6;
    public float speed = 10f;

    public Animation animation;

    private void Awake()
    {
        instantiate = this;        
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameControl.instantiate.press == true && gameControl.instantiate.gameOver == false)
        {
            //Debug.Log("çalıştı");
            movePunch();
        }  

        //if (gameControl.instantiate.gameOver)
        //{
        //    animation.Stop();
        //}
    }

    private void movePunch()
    {
        Vector2 vector = transform.position;

        if (this.tag == "leftPunch")
        {
            targetPoint = -4.85f;
            
        }
        else
        {
            targetPoint = -7.5f;
        }
        vector.y = Mathf.MoveTowards(vector.y, targetPoint, 0.03f * movement.instantiate.speed);
        if(Mathf.Abs(vector.y - targetPoint) < 0.01f)
        {
            if(this.tag == "leftPunch")
            {
                vector.y = 7.65f;
                
            }
            else
            {
                vector.y = 5.0f;
            }
            
        }

        transform.position = vector;
        gameControl.instantiate.score++;

        
    }

    

    
}
