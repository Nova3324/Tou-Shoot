using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameMenuManager : MonoBehaviour
{
    public void EndGameQuit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void EndGameRetry()
    {
        SceneManager.LoadSceneAsync("Fast");
        SaveData.Instance.LoadFromJSON();
        if (Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }
}
