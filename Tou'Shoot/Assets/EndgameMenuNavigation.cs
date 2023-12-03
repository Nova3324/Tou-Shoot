using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndgameMenuNavigation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Text Button")]
    [SerializeField] TMP_Text m_quitWin;
    [SerializeField] TMP_Text m_quitLose;
    [SerializeField] TMP_Text m_retry;

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "QuitWin":
                m_quitWin.color = Color.red;
                break;
            case "QuitLose":
                m_quitLose.color = Color.red;
                break;
            case "Retry":
                m_retry.color = new Color32(255, 0, 229, 255);
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "QuitWin":
                m_quitWin.color = Color.white;
                break;
            case "QuitLose":
                m_quitLose.color = Color.white;
                break;
            case "Retry":
                m_retry.color = Color.white;
                break;
            default:
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "QuitWin":
                m_quitWin.color = Color.white;
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("MainMenu");
                break;
            case "QuitLose":
                m_quitLose.color = Color.white;
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("MainMenu");
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
            default:
                break;
        }
    }
}
