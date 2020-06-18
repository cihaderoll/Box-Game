using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void GotoPauseScene()
    {
        SceneManager.LoadScene("Pause");
    }
}
