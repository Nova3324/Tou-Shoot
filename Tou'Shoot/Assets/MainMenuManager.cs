using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class MainMenuManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ButtonCustom m_settingsBackButton;
    [SerializeField] private ButtonCustom m_settingsResetButton;

    [Header("Menus")]
    [SerializeField] private GameObject m_credits;
    [SerializeField] private GameObject m_settings;
    [SerializeField] private GameObject m_mainmenu;

    [Header("Animator")]
    [SerializeField] private Animator m_transitionAnimator;
    [SerializeField] private Animator m_buttonsAnimator;
    [SerializeField] private Animator m_gamemodeAnimator;

    [Header("Sliders")]
    [SerializeField] private Slider m_musicsSlider;
    [SerializeField] private Slider m_soundsSlider;

    private float m_currentMusicSliderValue;
    private float m_currentSoundsSliderValue;

    private void Start()
    {
        Invoke("MainMenuButtonsAnimation", 1f);

        m_currentMusicSliderValue = m_musicsSlider.value;
        m_currentSoundsSliderValue = m_soundsSlider.value;
    }

    private void Update()
    {
        ApplyButton();
    }

    public void DisableButton()
    {
        m_settingsBackButton.m_interactable = false;
        m_settingsResetButton.m_interactable = false;
    }

    private IEnumerator EnableButtons()
    {
        yield return new WaitForSeconds(0.5f);
        m_settingsBackButton.m_interactable = true;
        m_settingsResetButton.m_interactable = true;
    }

    /*---------------------------------------------------------------------------Main Menu----------------------------------------------------------------------------*/

    public void MainMenuSettings()
    {
        m_settings.SetActive(true);
        m_mainmenu.SetActive(false);
        GameObject.Find("Check").GetComponent<Animator>().SetInteger("Check", 0);
    }

    public void MainMenuCredits()
    {
        m_credits.SetActive(true);
        m_mainmenu.SetActive(false);
        FadeCredits.Instance.ResetCredits();
    }

    public void MainMenuQuit()
    {
        Application.Quit();
    }

    private void MainMenuButtonsAnimation()
    {
        m_buttonsAnimator.SetBool("MainMenuButtons", true);
    }

    public void MainMenuMode()
    {
        m_gamemodeAnimator.SetBool("MainMenu", true);
        m_gamemodeAnimator.SetBool("GameMode", false);

        m_buttonsAnimator.SetBool("GameMode", true);
        m_buttonsAnimator.SetBool("MainMenu", false);
        m_buttonsAnimator.SetBool("MainMenuButtons", false);
    }

    /*---------------------------------------------------------------------------Settings----------------------------------------------------------------------------*/

    public void SettingsBack()
    {
        m_settings.SetActive(false);
        m_mainmenu.SetActive(true);
    }

    public void SettingsReset()
    {
        CheckReset();
        DisableButton();
    }

    public void SettingsContinue()
    {
        StartCoroutine(EnableButtons());
        ContinueInNoFile();
    }

    public void SettingsYes()
    {
        StartCoroutine(EnableButtons());
        ResetHighScore();
    }

    public void SettingsNo()
    {
        StartCoroutine(EnableButtons());
        HideVerif();
    }

    public void SettingsApply()
    {
        SaveAudioSettings.Instance.SaveToJSON();
        StartCoroutine(EnableButtons());
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

    private IEnumerator SetBoolToZero()
    {
        yield return new WaitForSeconds(0.6f);
        GameObject.Find("Check").GetComponent<Animator>().SetInteger("Check", 0);
    }

    private void DisplayNoFile()
    {
        GameObject.Find("NoFiles").GetComponent<Animator>().SetBool("NoFile", true);
    }

    private void HideNoFile()
    {
        GameObject.Find("NoFiles").GetComponent<Animator>().SetBool("NoFile", false);
    }

    private void DisplayVerif()
    {
        GameObject.Find("Check").GetComponent<Animator>().SetInteger("Check", 1);
    }

    private void HideVerif()
    {
        GameObject.Find("Check").GetComponent<Animator>().SetInteger("Check", 2);
        StartCoroutine(SetBoolToZero());
    }

    private void CheckReset()
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

    private void ResetHighScore()
    {
        File.Delete(Application.dataPath + "/HighScoreSave.json");
        HideVerif();
    }

    private void ContinueInNoFile()
    {
        HideNoFile();
    }

    /*---------------------------------------------------------------------------Credits----------------------------------------------------------------------------*/

    public void CreditsBack()
    {
        m_credits.SetActive(false);
        m_mainmenu.SetActive(true);
    }
}
