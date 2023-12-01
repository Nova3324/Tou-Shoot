using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SettingsNavigation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] TMP_Text m_back;
    [SerializeField] GameObject m_settings, m_pause;
    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Back":
                m_back.color = new Color32(255, 0, 229, 255);
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Back":
                m_back.color = Color.white;
                break;
            default:
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Back":
                m_back.color = Color.white;

                m_pause.SetActive(true);
                m_settings.SetActive(false);

                //Audio
                GameAudioManager.Instance.Button();

                break;
            default:
                break;
        }
    }
}
