using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemies : MonoBehaviour
{
    public enum m_enum
    {
        first, second, third, four
    }


    BulletPooler m_bulletPooler;
    
    [SerializeField] public Transform[] m_origin;
    [SerializeField] private float m_fireRate = 1f;
    [SerializeField] m_enum m_enemy;
    private float m_nextFire = 0f;
    
    void Start()
    {
        m_bulletPooler = BulletPooler.Instance;
    }
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if(Time.time > m_nextFire)
        {
            m_nextFire = Time.time + m_fireRate;
            switch (m_enemy)
            {
                case m_enum.first:
                    m_bulletPooler.SpawnFromPool("1st Enemy Bullet North", m_origin[0].position, Quaternion.identity);
                    m_bulletPooler.SpawnFromPool("1st Enemy Bullet South", m_origin[1].position, Quaternion.identity);
                    m_bulletPooler.SpawnFromPool("1st Enemy Bullet East", m_origin[2].position, Quaternion.identity);
                    m_bulletPooler.SpawnFromPool("1st Enemy Bullet West", m_origin[3].position, Quaternion.identity);
                    break;
                case m_enum.second:
                    m_bulletPooler.SpawnFromPool("2nd Enemy Bullet North", m_origin[0].position, Quaternion.identity);
                    m_bulletPooler.SpawnFromPool("2nd Enemy Bullet South", m_origin[1].position, Quaternion.identity);
                    m_bulletPooler.SpawnFromPool("2nd Enemy Bullet East", m_origin[2].position, Quaternion.identity);
                    m_bulletPooler.SpawnFromPool("2nd Enemy Bullet West", m_origin[3].position, Quaternion.identity);
                    break;
                case m_enum.third:
                    m_bulletPooler.SpawnFromPool("3rd Enemy Bullet North", m_origin[0].position, Quaternion.identity);
                    m_bulletPooler.SpawnFromPool("3rd Enemy Bullet South", m_origin[1].position, Quaternion.identity);
                    m_bulletPooler.SpawnFromPool("3rd Enemy Bullet East", m_origin[2].position, Quaternion.identity);
                    m_bulletPooler.SpawnFromPool("3rd Enemy Bullet West", m_origin[3].position, Quaternion.identity);
                    break;
                case m_enum.four:
                    m_bulletPooler.SpawnFromPool("4th Enemy Bullet North", m_origin[0].position, Quaternion.identity);
                    m_bulletPooler.SpawnFromPool("4th Enemy Bullet South", m_origin[1].position, Quaternion.identity);
                    m_bulletPooler.SpawnFromPool("4th Enemy Bullet East", m_origin[2].position, Quaternion.identity);
                    m_bulletPooler.SpawnFromPool("4th Enemy Bullet West", m_origin[3].position, Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
    }
}
