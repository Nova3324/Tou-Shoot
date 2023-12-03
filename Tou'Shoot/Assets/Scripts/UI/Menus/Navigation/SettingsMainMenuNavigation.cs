using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class SettingsMainMenuNavigation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Menus")]
    [SerializeField] private GameObject m_mainmenu;

    [Header("Text Button")]
    [SerializeField] private TMP_Text m_back;
    [SerializeField] private TMP_Text m_reset;
    [SerializeField] private TMP_Text m_yes;
    [SerializeField] private TMP_Text m_no;
    [SerializeField] private TMP_Text m_continue;
    [SerializeField] private TMP_Text m_apply;

    [Header("Sprites")]
    [SerializeField] private Sprite m_disableButtons;
    [SerializeField] private Sprite m_enableButton;

    [Header("Images")]
    [SerializeField] private Image m_backSprite;
    [SerializeField] private Image m_resetSprite;

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
            case "Back":
                if (m_backSprite.sprite != m_disableButtons)
                    m_back.color = new Color32(255, 0, 229, 255);
                break;
            case "Reset":
                if (m_backSprite.sprite != m_disableButtons)
                    m_reset.color = new Color32(255, 0, 229, 255);
                break;
            case "Continue":
                m_continue.color = Color.green;
                break;
            case "Yes":
                m_yes.color = Color.green;
                break;
            case "No":
                m_no.color = Color.red;
                break;
            case "Apply":
                m_apply.color = Color.green;
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
                if (m_backSprite.sprite != m_disableButtons)
                    m_back.color = Color.white;
                break;
            case "Reset":
                if (m_backSprite.sprite != m_disableButtons)
                    m_reset.color = Color.white;
                break;
            case "Continue":
                m_continue.color = Color.white;
                break;
            case "Yes":
                m_yes.color = Color.white;
                break;
            case "No":
                m_no.color = Color.white;
                break;
            case "Apply":
                m_apply.color = Color.white;
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
                if (m_backSprite.sprite != m_disableButtons)
                {
                    m_back.color = Color.white;
                    Back();

                    //Audio
                    MainMenuAudioManager.Instance.Button();
                }

                break;

            case "Reset":
                if (m_backSprite.sprite != m_disableButtons)
                {
                    m_reset.color = Color.white;
                    CheckReset();
                    DisableButton();

                    //Audio
                    MainMenuAudioManager.Instance.Button();
                }

                break;
            case "Continue":
                EnableButton();
                m_continue.color = Color.white;
                ContinueInNoFile();

                //Audio
                MainMenuAudioManager.Instance.Button();

                break;
            case "Yes":
                EnableButton();
                m_yes.color = Color.white;
                ResetHighScore();

                //Audio
                MainMenuAudioManager.Instance.Button();

                break;
            case "No":
                EnableButton();
                m_no.color = Color.white;
                HideVerif();

                //Audio
                MainMenuAudioManager.Instance.Button();

                break;
            case "Apply":
                m_apply.color = Color.white;
                SaveAudioSettings.Instance.SaveToJSON();
                EnableButton();

                //Audio
                MainMenuAudioManager.Instance.Button();

                break;
            default:
                break;
        }
    }

    /*---------------------------------------------------------------------------METHODS----------------------------------------------------------------------------*/

    public void Back()
    {
        transform.parent.parent.gameObject.SetActive(false);
        m_mainmenu.SetActive(true);
    }

    public void DisplayNoFile()
    {
        GameObject.Find("NoFiles").GetComponent<Animator>().SetBool("NoFile", true);
    }

    public void HideNoFile()
    {
        GameObject.Find("NoFiles").GetComponent<Animator>().SetBool("NoFile", false);
    }

    public void DisplayVerif()
    {
        GameObject.Find("Check").GetComponent<Animator>().SetInteger("Check", 1);
    }

    public void HideVerif()
    {
        GameObject.Find("Check").GetComponent<Animator>().SetInteger("Check", 2);
    }

    public void CheckReset()
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

    public void DisableButton()
    {
        m_backSprite.sprite = m_disableButtons;
        m_resetSprite.sprite = m_disableButtons;
    }

    public void EnableButton()
    {
        m_backSprite.sprite = m_enableButton;
        m_resetSprite.sprite = m_enableButton;
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
