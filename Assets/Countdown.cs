using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    int currentTime = 0;
    int startTime = 3;
    public AudioSource source;
    public AudioClip ring;
    public AudioClip countSound;
    public AudioClip backSound;
    public AudioClip gameOverSound;

    public Text countDown;
    int j =0;

    void Start()
    {
        
        StartCoroutine(countDownFunc(startTime));
    }

    void Update()
    {
        //if(gameControl.instantiate.gamePause == false)
        //{
        //    currentTime -= 1 * Time.deltaTime;
        //    countDown.text = currentTime.ToString("0");
        //    if (currentTime < 0.5)
        //    {
        //        countDown.gameObject.SetActive(false);
        //        currentTime = 0f;
        //        if (currentTime <= 0)
        //        {
        //            gameControl.instantiate.countDown = false;
        //            source.PlayOneShot(ring);
        //        }

        //    }
        //}

        if (gameControl.instantiate.gameOver == true && j==0)
        {
            source.Stop();
            if(PlayerPrefs.GetInt("sound") % 2 == 1)
            {
                source.PlayOneShot(gameOverSound);
            }
            
            j++;
        }

    }

    IEnumerator countDownFunc(int startTime)
    {
        currentTime = startTime;
        while(currentTime > 0 )
        {
            countDown.text = "" + currentTime;
            if(PlayerPrefs.GetInt("sound") % 2 == 1)
            {
                source.PlayOneShot(countSound);
            }
           
            currentTime--;
            yield return new WaitForSeconds(1);
        }
        closeCountDown();
    }

    public void closeCountDown()
    {
        gameControl.instantiate.countDown = false;
        countDown.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("sound") % 2 == 1)
        {
            source.PlayOneShot(ring);
        }
        
        Invoke("playBackSound", 1.0f);
    }

    public void playBackSound()
    {
        if (PlayerPrefs.GetInt("sound") % 2 == 1)
        {
            source.PlayOneShot(backSound);
        }
            
    }
}
