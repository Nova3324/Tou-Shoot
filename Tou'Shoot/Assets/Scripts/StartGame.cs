using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] Animator m_animator;
    
    [SerializeField] private List<GameObject> m_objectToEnable = new List<GameObject>();
    private float m_timer;
    private bool m_detectingCollision = false;

    [SerializeField] private TMP_Text m_timerUI;

    [SerializeField] private GameObject m_player;

    void Start()
    {
        for(int i = 0;  i < m_objectToEnable.Count; i++)
            m_objectToEnable[i].SetActive(false);
    }
    
    void Update()
    {
        m_timer += Time.deltaTime;
        WaitBeforeStart();
        SpawnStarShip();
        DetectingCollision();
    }

    public void WaitBeforeStart()
    {
        if(m_timer >= 1)
        {
            m_timerUI.SetText("2");
            m_timerUI.color = new Color32(255, 155, 0, 255);
            m_animator.SetInteger("Timer", 2);
        }
        if (m_timer >= 2)
        {
            m_timerUI.SetText("1");
            m_timerUI.color = new Color32(255,0, 0,255);
            m_animator.SetInteger("Timer", 1);
        }
        if (m_timer >= 3)
        {
            m_detectingCollision = true;
            for (int i = 0; i < m_objectToEnable.Count; i++)
            {
                m_objectToEnable[i].SetActive(true);
            }
            this.enabled = false;    
            if (this.enabled == false)
            {
                GameObject.Find("Timer").gameObject.SetActive(false);
            }
        }
    }  
    
    public void SpawnStarShip()
    {
        m_player.transform.position += Vector3.up * Time.deltaTime;
    }

    public void DetectingCollision()
    {
        if (m_detectingCollision == true)
        {
            m_player.GetComponent<BoxCollider2D>().isTrigger = false;
            GameObject.Find("Start Game").gameObject.SetActive(false);
        }
        else if (m_detectingCollision == false)
            m_player.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
