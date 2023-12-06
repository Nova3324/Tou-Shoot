using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ButtonCustom m_settingsBackButton;
    [SerializeField] private ButtonCustom m_settingsApplyButton;

    [Header("Menus")]
    [SerializeField] GameObject m_settings;
    [SerializeField] GameObject m_pause;

    [Header("Sliders")]
    [SerializeField] private Slider m_musicsSlider;
    [SerializeField] private Slider m_soundsSlider;

    [SerializeField] private PlayerInput m_playerInputs;

    private float m_currentMusicSliderValue;
    private float m_currentSoundsSliderValue;

    void Start()
    {
        m_currentMusicSliderValue = m_musicsSlider.value;
        m_currentSoundsSliderValue = m_soundsSlider.value;
    }

    void Update()
    {
        ApplyButton();    
    }

    private void DisableButton()
    {
        m_settingsBackButton.m_interactable = false;
        m_settingsApplyButton.m_interactable = true;
    }

    private void EnableButtons()
    {
        m_settingsBackButton.m_interactable = true;
        m_settingsApplyButton.m_interactable = false;
    }

 /*---------------------------------------------------------------------------Menu----------------------------------------------------------------------------*/

    public void MenuResume()
    {
        m_pause.SetActive(false);
        Time.timeScale = 1f;
        m_playerInputs.SwitchCurrentActionMap("Game");
    }

    public void MenuRetry()
    {
        SceneManager.LoadSceneAsync("Fast");
        SaveData.Instance.LoadFromJSON();
        if (Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }

    public void MenuSettings()
    {
        m_settings.SetActive(true);
        m_pause.SetActive(false);
    }

    public void MenuQuit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
        SaveData.Instance.LoadFromJSON();
    }

 /*-------------------------------------------------------------------------Settings--------------------------------------------------------------------------*/
    public void SettingsApply()
    {
        EnableButtons();
    }

    public void SettingsBack()
    {
        m_settings.SetActive(false);
        m_pause.SetActive(true);
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
