using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenuGUI : MonoBehaviour
{

    public GameObject settingsPanel;
    public GameObject exitPanel;
    public Text highScoreText;
    public Text lastScoreText;
    public GameObject checkMark;

    int i = 0;
    bool isPlaySound = true;
    public AudioSource backSound;

    void Start()
    {

        checkMark.SetActive(false);
        //toggle.isOn = false;
        //PlayerPrefs.DeleteAll();



        if (PlayerPrefs.GetInt("sound") % 2 ==1)
        {
            backSound.Play();
            PlayerPrefs.SetInt("sound", 1);
            checkMark.SetActive(true);
            
        }
        

        /*if(PlayerPrefs.GetInt("sound") % 2 == 1)
        {
            toggle.isOn = true;
        }
        else
        {
            
            toggle.isOn = false;
            Debug.Log("sound off");

        }*/
        

        highScoreText.text = "" +  PlayerPrefs.GetInt("bestScore", 0);
        lastScoreText.text = "" + PlayerPrefs.GetInt("lastScore", 0);
    }

    
    void Update()
    {
        
    }

    public void activeSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void closeSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

    public void activeExitPanel()
    {
        exitPanel.SetActive(true);
    }
    public void closeExitPanel()
    {
        exitPanel.SetActive(false);
    }

    public void closeGame()
    {
        Application.Quit();
        Debug.Log("çıkış");
    }

    public void setSound()
    {
        if (PlayerPrefs.GetInt("sound", 0) % 2 ==0)
        {
            isPlaySound = true;
            backSound.Play();
            PlayerPrefs.SetInt("sound", PlayerPrefs.GetInt("sound") + 1);
            checkMark.SetActive(true);
        }
        else
        {
            isPlaySound = false;
            i++;
            backSound.Stop();
            PlayerPrefs.SetInt("sound", PlayerPrefs.GetInt("sound") + 1);
            checkMark.SetActive(false);
        }
    }
}
