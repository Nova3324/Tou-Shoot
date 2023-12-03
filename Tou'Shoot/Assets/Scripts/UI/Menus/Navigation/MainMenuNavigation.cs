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

    [Header("Animator")]
    [SerializeField] private Animator m_transitionAnimator;
    [SerializeField] private Animator m_buttonsAnimator;


    private void Start()
    {
        m_buttonsAnimator.SetBool("MainMenuButtons", true);
    }
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
                m_transitionAnimator.SetBool("Transition", true);

                Invoke("Play", 0.8f);

                //Audio
                MainMenuAudioManager.Instance.Button();
                break;

            case "Settings":
                m_settingsText.color = Color.white;
                Settings();

                //Audio
                MainMenuAudioManager.Instance.Button();
                break;

            case "Credits":
                m_creditsText.color = Color.white;
                Credits();

                //Audio
                MainMenuAudioManager.Instance.Button();

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
