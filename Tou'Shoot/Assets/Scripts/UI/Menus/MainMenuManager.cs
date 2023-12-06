using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

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

    [Header("Buttons")]
    [SerializeField] private GameObject m_infini;
    [SerializeField] private GameObject m_fast;

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
        m_settingsApplyButton.m_interactable = true;
    }

    private void EnableButtons()
    {
        m_settingsBackButton.m_interactable = true;
        m_settingsResetButton.m_interactable = true;
        m_settingsApplyButton.m_interactable = false;
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
        HideVerif();
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
    /*---------------------------------------------------------------------------Credits----------------------------------------------------------------------------*/

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
        m_transitionAnimator.SetBool("Transition", true);
    }

    public void GameModeInfinite()
    {
        m_infini.transform.localScale = new Vector3(1f, 1f, 1f);
        StartCoroutine(Infini());
        m_transitionAnimator.SetBool("Transition", true);
    }

    public void GameModeBack()
    {
        m_gamemodeAnimator.SetBool("GameMode", true);
        m_gamemodeAnimator.SetBool("MainMenu", false);

        m_buttonsAnimator.SetBool("GameMode", false);
        m_buttonsAnimator.SetBool("MainMenu", true);
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
