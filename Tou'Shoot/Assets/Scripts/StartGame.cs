using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] Animator m_animator;
    
    [SerializeField] private List<GameObject> m_objectToEnable = new List<GameObject>();
    private float m_timer;

    [SerializeField] private TMP_Text m_timerUI;
    void Start()
    {
        for(int i = 0;  i < m_objectToEnable.Count; i++)
            m_objectToEnable[i].SetActive(false);
    }
    
    void Update()
    {
        m_timer += Time.deltaTime;
        WaitBeforeStart();
    }

    public void WaitBeforeStart()
    {
        if(m_timer >= 1.5)
        {
            m_timerUI.SetText("2");
            m_animator.SetInteger("Timer", 2);
        }
        if (m_timer >= 3)
        {
            m_timerUI.SetText("1");
            m_animator.SetInteger("Timer", 1);
        }
        if (m_timer >= 4.5)
        {
            m_timerUI.SetText("Start");
            m_animator.SetInteger("Timer", 0);
        }
        if (m_timer >= 7)
        {
            for (int i = 0; i < m_objectToEnable.Count; i++)
                m_objectToEnable[i].SetActive(true);
            this.enabled = false;

            if(this.enabled == false)
                GameObject.Find("Timer").gameObject.SetActive(false);
        }
    }       
}
