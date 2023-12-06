using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMainMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_mainMenuCanvasGroup;

    public void ShowMainMenu()
    {
        m_mainMenuCanvasGroup.alpha = 1;
    }
}
