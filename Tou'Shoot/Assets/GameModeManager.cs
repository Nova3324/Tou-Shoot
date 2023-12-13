using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    [Header("Buttons How To Play")]
    [SerializeField] private GameObject m_infini;
    [SerializeField] private GameObject m_fast;

    [Header("Explanation")]
    [SerializeField] private GameObject m_infiniExplanation;
    [SerializeField] private GameObject m_fastExplanation;

    [Header("GameObjects")]
    [SerializeField] private GameObject m_mainMenuGameMode;

    [Header("Arrow")]
    [SerializeField] private GameObject m_leftArrow;
    [SerializeField] private GameObject m_rightArrow;

    [Header("Text")]
    [SerializeField] private GameObject m_leftArrowBack;
    [SerializeField] private GameObject m_rightArrowBack;

    private Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void InfiniButtonSelected()
    {
        m_infini.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
    }

    public void FastButtonSelected()
    {
        m_fast.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
    }

    public void InfiniButtonUnselected()
    {
        m_infini.transform.localScale = Vector3.one;
    }

    public void FastButtonUnselected()
    {
        m_fast.transform.localScale = Vector3.one;
    }

    public void InfiniButton()
    {
        m_infiniExplanation.SetActive(true);
        m_mainMenuGameMode.SetActive(false);
        m_infini.transform.localScale = Vector3.one;
    }

    public void FastButton()
    {
        m_fastExplanation.SetActive(true);
        m_mainMenuGameMode.SetActive(false);
        m_fast.transform.localScale = Vector3.one;
    }

    public void Back()
    {
        if(m_fastExplanation.activeSelf) 
        {
            m_fastExplanation.SetActive(false);
            m_mainMenuGameMode.SetActive(true);
        }
        else if(m_infiniExplanation.activeSelf) 
        {
            m_infiniExplanation.SetActive(false);
            m_mainMenuGameMode.SetActive(true);
        }
    }

    public void RightArrow()
    {
        m_animator.SetBool("Bonus", true);        
    }

    public void LeftArrow() 
    {
        m_animator.SetBool("Bonus", false);
    }

    public void LeftArrowSelected()
    {
        m_leftArrowBack.SetActive(true);
    }

    public void LeftArrowUnselected()
    {
        m_leftArrowBack.SetActive(false);
    }

    public void RightArrowSelected()
    {
        m_rightArrowBack.SetActive(true);
    }

    public void RightArrowUnselected()
    {
        m_rightArrowBack.SetActive(false);
    }
}
