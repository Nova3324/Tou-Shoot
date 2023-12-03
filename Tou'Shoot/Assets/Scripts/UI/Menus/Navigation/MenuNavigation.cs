using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuNavigation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] TMP_Text m_resume, m_retry, m_settings, m_quit;
    [SerializeField] GameObject m_pause, m_settingsMenu;
    [SerializeField] private PlayerInput m_playerInputs;
    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Resume":
                m_resume.color = new Color32(255, 0, 229, 255);
                break;
            case "Retry":
                m_retry.color = new Color32(255, 0, 229, 255);
                break;
            case "Settings":
                m_settings.color = new Color32(255, 0, 229, 255);
                break;
            case "Quit": 
                m_quit.color = new Color32(255,0,229,255);  
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Resume":
                m_resume.color = Color.white;
                break;
            case "Retry":
                m_retry.color = Color.white;
                break;
            case "Settings":
                m_settings.color = Color.white;
                break;
            case "Quit":
                m_quit.color = Color.white;
                break;
            default:
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Resume":
                m_resume.color = Color.white;
                m_pause.SetActive(false);
                Time.timeScale = 1f;
                m_playerInputs.SwitchCurrentActionMap("Game");

                //Audio
                GameAudioManager.Instance.Button();

                break;
            case "Retry":
                m_retry.color = Color.white;
                SceneManager.LoadSceneAsync("Game");
                SaveData.Instance.LoadFromJSON();
                if (Time.timeScale != 1)
                    Time.timeScale = 1.0f;

                //Audio
                GameAudioManager.Instance.Button();

                break;
            case "Settings":
                m_settings.color = Color.white;
                m_settingsMenu.SetActive(true);
                m_pause.SetActive(false);
                
                //Audio
                GameAudioManager.Instance.Button();

                break;
            case "Quit":
                m_quit.color = Color.white;
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("MainMenu");
                SaveData.Instance.LoadFromJSON();

                //Audio
                GameAudioManager.Instance.Button();

                break;
            default:
                break;
        }
    }
}
