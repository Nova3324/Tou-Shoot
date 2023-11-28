using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync("Devroom");
        if(Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
