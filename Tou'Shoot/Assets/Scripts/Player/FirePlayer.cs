using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    [SerializeField] Transform m_origin;
    [SerializeField] GameObject m_bullet;
    PlayerController m_playerController;
    [SerializeField] private float m_fireRate = 1f;
    private float m_nextFire = 0f;

    private void Start()
    {
        m_playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        Fire();       
    }

    public bool SetFireBool()
    {
        return m_playerController.m_canFire;
    }
    private void Fire()
    {
        if (SetFireBool() && Time.time > m_nextFire)
        {
            m_nextFire = Time.time + m_fireRate;
            Instantiate(m_bullet, m_origin.position, Quaternion.identity);
        }
    }
}
