using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class MenuManager : MonoBehaviour
{
    public DataHighScore m_saveGameData = new DataHighScore();
    [SerializeField] private GameObject m_credits, m_settings, m_mainmenu;
    [SerializeField] private AudioSettings m_audioSettings;

    public void Retry()
    {
        SceneManager.LoadSceneAsync("Game");
        SaveData.Instance.LoadFromJSON();
        if (Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
        if (Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        if (m_settings.activeSelf == true)
        {
            m_settings.SetActive(false);
            m_mainmenu.SetActive(true);
        }
        else if(m_credits.activeSelf == true)
        {
            m_credits.SetActive(false);
            m_mainmenu.SetActive(true);
        }
    }

    public void Settings()
    {
        m_settings.SetActive(true);
        m_mainmenu.SetActive(false);
    }

    public void Credits()
    {
        m_credits.SetActive(true);
        m_mainmenu.SetActive(false);
        FadeCredits.Instance.ResetCredits();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void DisplayNoFile()
    {
        GameObject.Find("NoFiles").GetComponent<Animator>().SetBool("NoFile", true);
        GameObject.Find("Back").GetComponent<Button>().interactable = false;
        GameObject.Find("Reset").GetComponent<Button>().interactable = false;
    }

    public void HideNoFile()
    {
        GameObject.Find("NoFiles").GetComponent<Animator>().SetBool("NoFile", false);
        GameObject.Find("Back").GetComponent<Button>().interactable = true;
        GameObject.Find("Reset").GetComponent<Button>().interactable = true;
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

    public void Reset()
    {
        if (File.Exists(Application.dataPath + "/HighScoreSave.json"))
        {
            DisplayVerif();
        }
        else
        {
            DisplayNoFile();
        }
    }

    public void ResetHighScore()
    {
        File.Delete(Application.dataPath + "/HighScoreSave.json");
        HideVerif();
    }

    public void ContinueInNoFile()
    {
        HideNoFile();  
    }
}
