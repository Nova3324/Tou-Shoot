using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SettingsNavigation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Text Button")]
    [SerializeField] TMP_Text m_apply;
    [SerializeField] TMP_Text m_back;

    [Header("Settings")]
    [SerializeField] GameObject m_settings;
    [SerializeField] GameObject m_pause;

    [Header("Sprites")]
    [SerializeField] private Sprite m_disableButtons;
    [SerializeField] private Sprite m_enableButton;

    [Header("Images")]
    [SerializeField] private Image m_backSprite;

    [Header("Sliders")]
    [SerializeField] private Slider m_musicsSlider;
    [SerializeField] private Slider m_soundsSlider;


    private float m_currentMusicSliderValue;
    private float m_currentSoundsSliderValue;

    private void Start()
    {
        m_currentMusicSliderValue = m_musicsSlider.value;
        m_currentSoundsSliderValue = m_soundsSlider.value;
    }

    private void Update()
    {
        ApplyButton();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Apply":
                m_apply.color = Color.green;
                break;
            case "Back":
                if (m_backSprite.sprite != m_disableButtons)
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
            case "Apply":
                m_apply.color = Color.white;
                break;
            case "Back":
                if (m_backSprite.sprite != m_disableButtons)
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
            case "Apply":
                m_apply.color = Color.white;

                SaveAudioSettings.Instance.SaveToJSON();
                EnableButton();

                //Audio
                GameAudioManager.Instance.Button();

                break;
            case "Back":
                if (m_backSprite.sprite != m_disableButtons)
                {
                    m_back.color = Color.white;
                    HideSettings();
                    //Audio
                    GameAudioManager.Instance.Button();

                }
                break;
            default:
                break;
        }
    }

    /*---------------------------------------------------------------------------METHODS----------------------------------------------------------------------------*/

    public void EnableButton()
    {
        m_backSprite.sprite = m_enableButton;
    }

    private void HideSettings()
    {
        m_settings.SetActive(false);
        m_pause.SetActive(true);
    }

    public void DisableButton()
    {
        m_backSprite.sprite = m_disableButtons;
    }


    private void ApplyButton()
    {
        if (m_musicsSlider.value != m_currentMusicSliderValue || m_soundsSlider.value != m_currentSoundsSliderValue)
        {
            m_currentMusicSliderValue = m_musicsSlider.value;
            m_currentSoundsSliderValue = m_soundsSlider.value;
            DisableButton();
        }
    }
}
