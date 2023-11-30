using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public DataHighScore m_saveGameData = new DataHighScore();
    public void Retry()
    {
        SceneManager.LoadSceneAsync("Game");
        SaveData.Instance.LoadFromJSON();
        if (Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync("Game");
        if (Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        if (Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync("Settings");
    }

    public void Credits()
    {
        SceneManager.LoadSceneAsync("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void DisplayVerif()
    {
        GameObject.Find("Check").GetComponent<Animator>().SetBool("Check", true);
        GameObject.Find("Back").GetComponent<Button>().interactable = false;
        GameObject.Find("Reset").GetComponent<Button>().interactable = false;
    }

    public void HideVerif()
    {
        GameObject.Find("Check").GetComponent<Animator>().SetBool("Check", false);
        GameObject.Find("Back").GetComponent<Button>().interactable = true;
        GameObject.Find("Reset").GetComponent<Button>().interactable = true;
    }

    public void ResetHighScore()
    {
        if (File.Exists(Application.dataPath + "/HighScoreSave.json"))
        {
            File.Delete(Application.dataPath + "/HighScoreSave.json");
            HideVerif();
            Debug.Log("Highscore réinitialisé");
        }
        else
        {
            Debug.Log("Aucun fichier HighScoreSave.json trouvé pour réinitialiser.");
        }
    }
}
