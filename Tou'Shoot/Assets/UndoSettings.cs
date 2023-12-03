using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UndoSettings : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Texts")]
    [SerializeField] private GameObject m_undoSounds;
    [SerializeField] private GameObject m_undoMusics;
    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Undo Sound":
                m_undoSounds.SetActive(true);
                break;
            case "Undo Music":
                m_undoMusics.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Undo Sound":
                m_undoSounds.SetActive(false);
                break;
            case "Undo Music":
                m_undoMusics.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Undo Sound":
                SaveAudioSettings.Instance.ResetSoundsSettings();
                break;
            case "Undo Music":
                SaveAudioSettings.Instance.ResetMusicsSettings();
                break;
            default:
                break;
        }
    }
}
