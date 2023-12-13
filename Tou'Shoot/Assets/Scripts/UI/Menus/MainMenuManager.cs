using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ButtonCustom m_settingsBackButton;
    [SerializeField] private ButtonCustom m_settingsResetButton;
    [SerializeField] private ButtonCustom m_settingsApplyButton;

    [Header("Menus")]
    [SerializeField] private GameObject m_credits;
    [SerializeField] private GameObject m_settings;
    [SerializeField] private GameObject m_mainmenu;
    [SerializeField] private GameObject m_controls;

    [Header("Buttons")]
    [SerializeField] private GameObject m_infini;
    [SerializeField] private GameObject m_fast;
    [SerializeField] private GameObject m_controlsButton;

    [Header("Sliders")]
    [SerializeField] private Slider m_musicsSlider;
    [SerializeField] private Slider m_soundsSlider;

    [Header("Texts")]
    [SerializeField] private GameObject m_controlsText;

    private float m_currentMusicSliderValue;
    private float m_currentSoundsSliderValue;

    private MainMenuAnimationsManager m_animationManager;

    private void Start()
    {
        m_currentMusicSliderValue = m_musicsSlider.value;
        m_currentSoundsSliderValue = m_soundsSlider.value;

        m_animationManager = MainMenuAnimationsManager.Instance;
    }

    private void Update()
    {
        ApplyButton();
    }

    public void DisableButton()
    {
        m_settingsBackButton.m_interactable = false;
        m_settingsResetButton.m_interactable = false;
        m_settingsApplyButton.m_interactable = true;
    }

    private void EnableButtons()
    {
        m_settingsBackButton.m_interactable = true;
        m_settingsResetButton.m_interactable = true;
        m_settingsApplyButton.m_interactable = false;
    }

    /*---------------------------------------------------------------------------Main Menu----------------------------------------------------------------------------*/

    public void MainMenuMode()
    {
        m_animationManager.MainMenuToMode();
    }

    public void MainMenuSettings()
    {
        m_animationManager.MainMenuToSettings();
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

    /*---------------------------------------------------------------------------Settings----------------------------------------------------------------------------*/
    public void ControlsSelected()
    {
        m_controlsButton.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
        m_controlsText.SetActive(true);
    }

    public void ControlsUnselected()
    {
        m_controlsButton.transform.localScale = Vector3.one;    
        m_controlsText.SetActive(false);
    }

    public void Controls()
    {
        m_controlsButton.transform.localScale = Vector3.one;
        m_controls.SetActive(true);
        m_settings.SetActive(false);
    }

    public void ControlsToSettings()
    {
        m_controls.SetActive(false);
        m_settings.SetActive(true);
    }
    public void SettingsBack()
    {
        m_animationManager.SettingsToMainMenu();
    }

    public void SettingsReset()
    {
        CheckReset();
        DisableButton();
    }

    public void SettingsContinue()
    {
        EnableButtons();
        ContinueInNoFile();
    }

    public void SettingsYes()
    {
        EnableButtons();
        ResetHighScore();
    }

    public void SettingsNo()
    {
        EnableButtons();
        m_animationManager.SecurityToSettings();
    }

    public void SettingsApply()
    {
        SaveAudioSettings.Instance.SaveToJSON();
        EnableButtons();
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

    private void CheckReset()
    {
        if (File.Exists(Application.dataPath + "/Saves/HighScoreSave.json"))
        {
            m_animationManager.SettingsToSecurity();
        }
        else
        {
            DisplayNoFile();
        }
    }

    private void DisplayNoFile()
    {
        m_animationManager.SettingsToNoFiles();
    }

    private void ResetHighScore()
    {
        File.Delete(Application.dataPath + "/Saves/HighScoreSave.json");
        m_animationManager.SecurityToSettings();
    }

    private void ContinueInNoFile()
    {
        m_animationManager.NoFilesToSettings();
    }

    /*---------------------------------------------------------------------------Credits----------------------------------------------------------------------------*/

    public void CreditsBack()
    {
        m_credits.SetActive(false);
        m_mainmenu.SetActive(true);
    }
    /*---------------------------------------------------------------------------Mode----------------------------------------------------------------------------*/

    public void GameModeBack()
    {
        m_animationManager.ModeToMainMenu();
    }
    public void GameModeFastSelected()
    {
        m_fast.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
    }

    public void GameModeInfiniteSelected()
    {
        m_infini.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
    }

    public void GameModeFastUnselect()
    {
        m_fast.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void GameModeInfiniteUnselect()
    {
        m_infini.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void GameModeFast()
    {
        m_fast.transform.localScale = new Vector3(1f, 1f, 1f);
        StartCoroutine(Fast());
        m_animationManager.ModeToGame();
    }

    public void GameModeInfinite()
    {
        m_infini.transform.localScale = new Vector3(1f, 1f, 1f);
        StartCoroutine(Infini());
        m_animationManager.ModeToGame();
    }

    private IEnumerator Fast()
    {
        yield return new WaitForSeconds(0.8f);

        SceneManager.LoadScene("Fast");
        if (Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }

    private IEnumerator Infini()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Infini");
        if (Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }
}
