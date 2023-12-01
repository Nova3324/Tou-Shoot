using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Menus")]
    [SerializeField] private GameObject m_credits;
    [SerializeField] private GameObject m_settings;
    [SerializeField] private GameObject m_mainmenu;

    [Header("Text Button")]
    [SerializeField] TMP_Text m_playText;
    [SerializeField] TMP_Text m_settingsText;
    [SerializeField] TMP_Text m_creditsText;
    [SerializeField] TMP_Text m_quitText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Play":
                m_playText.color = new Color32(255, 0, 229, 255);
                break;
            case "Settings":
                m_settingsText.color = new Color32(255, 0, 229, 255);
                break;
            case "Credits":
                m_creditsText.color = new Color32(255, 0, 229, 255);
                break;
            case "Quit":
                m_quitText.color = new Color32(255, 0, 229, 255);
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Play":
                m_playText.color = Color.white;
                break;
            case "Settings":
                m_settingsText.color = Color.white;
                break;
            case "Credits":
                m_creditsText.color = Color.white;
                break;
            case "Quit":
                m_quitText.color = Color.white;
                break;
            default:
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Play":
                m_playText.color = Color.white;
                Play();
                break;
            case "Settings":
                m_settingsText.color = Color.white;
                Settings();
                break;
            case "Credits":
                m_creditsText.color = Color.white;
                Credits();
                break;
            case "Quit":
                Quit();
                break;
            default:
                break;
        }
    }

    /*---------------------------------------------------------------------------METHODS----------------------------------------------------------------------------*/

    public void Play()
    {
        SceneManager.LoadScene("Game");
        if (Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }

    public void Settings()
    {
        m_settings.SetActive(true);
        m_mainmenu.SetActive(false);
        GameObject.Find("Check").GetComponent<Animator>().SetInteger("Check", 0);
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
}
