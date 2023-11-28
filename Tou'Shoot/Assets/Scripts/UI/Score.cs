using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int m_score;
    private int m_constant = 100;
    public float m_timeSinceStart;
    public int m_remainingEnemies;

    public static Score Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            Debug.LogError("There is two Endgame");
            return;
        }
    }

    void Update()
    {
        m_timeSinceStart = Time.realtimeSinceStartup;
        m_remainingEnemies = Enemies.Instance.m_enemiesOnTheMap.Count;
    }

    public void EnemyHit()
    {
        m_score += 100000;
    }

    public void EnemyDeath()
    {
        if(m_remainingEnemies > 0)
            m_score += (m_score + m_remainingEnemies * m_constant) / Convert.ToInt32(m_timeSinceStart);
    }

    public void LastEnemyIsDead()
    {
        m_constant = 10;
        m_score += (m_score * m_constant);
    }
}
