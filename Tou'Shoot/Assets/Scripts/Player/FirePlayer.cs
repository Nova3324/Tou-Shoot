using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    PlayerController m_playerController;
    BulletPooler m_bulletPooler;
    
    
    [SerializeField] Transform m_origin;
    [SerializeField] private float m_fireRate = 1f;
    [SerializeField] private int m_NumberOfBullets;
    private float m_nextFire = 0f;

    private void Start()
    {
        m_playerController = GetComponent<PlayerController>();
        m_bulletPooler = BulletPooler.Instance;
        m_bulletPooler.m_poolSize = m_NumberOfBullets;
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
            m_bulletPooler.SpawnFromPool("Player Bullet", m_origin.position, Quaternion.identity);
        }
    }
}
