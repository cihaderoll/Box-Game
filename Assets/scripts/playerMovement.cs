using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    [Range(0, 0.5f)]
    public float followSpeedDelay = 0.1f;       

    private int fingerOffset = 200;

    public GameObject newBestText;
   

    //Private internal variables
    private float xVelocity = 0.0f;
    private float zVelocity = 0.0f;
    private float yVelocity = 0.0f;
    private Vector3 screenToWorldVector;

    //-------------------------------

    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.0f, -3.0f, 0.0f);
    }


    // Update is called once per frame
    void Update()
    {
        if (gameControl.instantiate.press)
        {
            touchControl();


            if(transform.position.x <= -2.3f)
            {
                transform.position = new Vector3(-2.3f, transform.position.y, transform.position.y);
            }


            if (transform.position.x >= 2.3f)
            {
                transform.position = new Vector3(2.3f, transform.position.y, transform.position.y);
            }

            if (transform.position.y <= -4.5f)
            {
                transform.position = new Vector3(transform.position.x, -4.5f, transform.position.y);
            }

            if (transform.position.y >= 3f)
            {
                transform.position = new Vector3(transform.position.x, 3f, transform.position.y);
            }


        }
        
    }

    void touchControl()
    {
        if (gameControl.instantiate.gameOver == false)
        {
            screenToWorldVector = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + fingerOffset, 10));
            
                float touchX = Mathf.SmoothDamp(transform.position.x, screenToWorldVector.x, ref xVelocity, followSpeedDelay);
            
            
            float touchY = Mathf.SmoothDamp(transform.position.y, screenToWorldVector.y, ref yVelocity, followSpeedDelay);
            float touchZ = Mathf.SmoothDamp(transform.position.z, screenToWorldVector.z, ref zVelocity, followSpeedDelay);
            Debug.Log(Input.mousePosition.y);
            
            if(Input.mousePosition.y < 1650f)
            {
                transform.position = new Vector3(touchX, touchY, touchZ);
            }
                
            
                
                
                       
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        gameControl.instantiate.press = false;
        gameControl.instantiate.gameOver = true;

        

        saveScore();

    }


    public void saveScore()
    {
        PlayerPrefs.SetInt("lastScore", gameControl.instantiate.score / 10);


        int lastBestScore;
        lastBestScore = PlayerPrefs.GetInt("bestScore");
        if (PlayerPrefs.GetInt("lastScore") > lastBestScore)
        {
            PlayerPrefs.SetInt("bestScore", gameControl.instantiate.score / 10);
            //Invoke("bestScoreCall", 3f);
            
        }
            
        Debug.Log(PlayerPrefs.GetInt("lastScore"));
    }

    public void bestScoreCall()
    {
        newBestText.SetActive(true);
    }

}
