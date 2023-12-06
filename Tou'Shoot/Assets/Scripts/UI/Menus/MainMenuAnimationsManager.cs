using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationsManager : MonoBehaviour
{
    private Animator m_mainMenuAnimator;
    [SerializeField] private Animator m_settingsAnimator;

    public static MainMenuAnimationsManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            return;
        }
    }
    void Start()
    {
        m_mainMenuAnimator = GetComponent<Animator>();
        MainMenuButtonsAnimation();
    }

    /*---------------------------------------------------------------------------Main Menu----------------------------------------------------------------------------*/
    private void MainMenuButtonsAnimation()
    {
        m_mainMenuAnimator.SetBool("MainMenuButtons", true);
    }

    public void MainMenuToMode()
    {
        m_mainMenuAnimator.SetBool("Mode", true);
    }

    public void ModeToMainMenu()
    {
        m_mainMenuAnimator.SetBool("Mode", false);
    }
    
    public void MainMenuToSettings()
    {
        m_mainMenuAnimator.SetBool("Settings", true);
    }

    public void SettingsToMainMenu()
    {
        m_mainMenuAnimator.SetBool("Settings", false);
    }

    public void ModeToGame()
    {
        m_mainMenuAnimator.SetBool("Game", true);
    }

    /*---------------------------------------------------------------------------Settings----------------------------------------------------------------------------*/

    public void SettingsToSecurity()
    {
        m_settingsAnimator.SetBool("Security", true);
    }

    public void SecurityToSettings()
    {
        m_settingsAnimator.SetBool("Security", false);
    }

    public void SettingsToNoFiles()
    {
        m_settingsAnimator.SetBool("NoFiles", true);
    }

    public void NoFilesToSettings()
    {
        m_settingsAnimator.SetBool("NoFiles", false);
    }
    /*---------------------------------------------------------------------------Events----------------------------------------------------------------------------*/
    public void SetBoolMainMenuButtons()
    {
        m_mainMenuAnimator.SetBool("MainMenuButtons", false);
    }
}
