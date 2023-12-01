using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class NavigationCredits : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Menus")]
    [SerializeField] private GameObject m_mainmenu;

    [Header("Text Button")]
    [SerializeField] private TMP_Text m_back;

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_back.color = new Color32(255, 0, 229, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_back.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Back();
        m_back.color = Color.white;

        //Audio
        MainMenuAudioManager.Instance.Button();
    }

    /*---------------------------------------------------------------------------METHODS----------------------------------------------------------------------------*/

    public void Back()
    {
        transform.parent.gameObject.SetActive(false);
        m_mainmenu.SetActive(true);
    }
}
