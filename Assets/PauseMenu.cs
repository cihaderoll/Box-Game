using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pausemenu, PauseButton;

    public void Pause(){
        Pausemenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;
        gameControl.instantiate.gamePause = true;
    }

    public void Resume(){
        Pausemenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
        gameControl.instantiate.gamePause = false;
    }
}