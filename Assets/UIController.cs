using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Text scoreText;
    public GameObject pausePanel;
    public GameObject surePanel;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text ="" + gameControl.instantiate.score / 10;
    }

    public void restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void pauseGame()
    {
        gameControl.instantiate.gamePause = true;
        pausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        gameControl.instantiate.gamePause = false;
        pausePanel.SetActive(false);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("Start Scene");
    }

    public void closeGame()
    {
        Application.Quit();
    }

    public void surePanelActive()
    {
        surePanel.SetActive(true);
    }

    public void surePanelDeActive()
    {
        surePanel.SetActive(false);
    }




}
