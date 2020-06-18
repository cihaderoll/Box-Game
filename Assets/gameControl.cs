using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameControl : MonoBehaviour
{
    public static gameControl instantiate;
    public GameObject GameOverScreen;

    public bool press = false;
    public int score = 0;
    public bool gameOver = false;
    public bool gamePause = false;
    public bool countDown = true;
    private int i = 1;
    private int j = 0;
    public Text scoreCountText;
    public int currentCount = 0;
    public Text highScore;
    

    public AudioClip woosh;

    private void Awake()
    {
        instantiate = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gamePause && !countDown && Input.mousePosition.y < 1650f)
        {
            press = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            press = false;
        }
        if (gameOver && j == 0){
            Invoke("activeGameOverPanel", 1.0f);
           
            j++;
        }

        if(score / 100 >= i * 100)
        {
            //movement.instantiate.speed *= 1.2f;
            i++;
        }
    }

   

    /*public void onPointerDown()
    {
        if(Input.mousePosition.y < 1650f)
        {
            press = true;
        }
        
    }
    public void onPointerUp()
    {
        press = false;
    }*/

    public void activeGameOverPanel()
    {
        GameOverScreen.SetActive(true);
        highScore.text = "" + PlayerPrefs.GetInt("bestScore");
        

        StartCoroutine(scoreCount());
    }

    public void playSfx()
    {
        GetComponent<AudioSource>().clip = woosh;
        if (!GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Play();
    }

    IEnumerator scoreCount()
    {
        

        while (currentCount <= PlayerPrefs.GetInt("lastScore"))
        {
            scoreCountText.text = "" + currentCount;
            currentCount += 12;

            if (PlayerPrefs.GetInt("lastScore") - currentCount < 9)
            {
                currentCount = PlayerPrefs.GetInt("lastScore");
            }

            

            yield return new WaitForSeconds(0.001f);
        }
    }
}
