using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObject : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_objectToEnable = new List<GameObject>();
    private Animator m_animator;
    void Start()
    {
        m_animator = GetComponent<Animator>();
        
        Invoke("TransitionAnimation", 2f);
        Invoke("EnableGameObjects", 3f);
    }

    private void EnableGameObjects()
    {
        for(int i = 0;  i < m_objectToEnable.Count; i++) 
        {
            m_objectToEnable[i].SetActive(true);
        }
    }

    private void TransitionAnimation()
    {
        m_animator.SetBool("Transition", true);
    }
}
