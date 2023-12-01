using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int m_score;
    public int m_highScore;
    private int m_limiteScore = 999999999;
    public float m_timeSinceStart;
    public int m_remainingEnemies;

    [SerializeField] private TMP_Text m_scoreUI;
    public TMP_Text m_highScoreUI;

    public static Score Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            Debug.LogError("There is two Score");
            return;
        }
    }

    private void Start()
    {
        m_highScoreUI.SetText(m_highScore.ToString());
    }

    void Update()
    {
        m_timeSinceStart = Time.realtimeSinceStartup;
        m_remainingEnemies = EnemyManager.Instance.m_enemiesOnTheMap.Count;

        CalculatingHighScore();
    }

    public void EnemyHit()
    {
        m_score += 5;

        if (m_score >= m_limiteScore)
            m_score = m_limiteScore;

        m_scoreUI.SetText(m_score.ToString());
    }

    public void EnemyDeath()
    {
        if(m_remainingEnemies > 0)
            m_score = (m_score * m_remainingEnemies);

        if (m_score >= m_limiteScore)
            m_score = m_limiteScore;

        m_scoreUI.SetText(m_score.ToString());
    }

    public void LastEnemyIsDead()
    {
        m_score += 1000;

        if (m_score >= m_limiteScore)
            m_score = m_limiteScore;

        m_scoreUI.SetText(m_score.ToString());
    }

    private void CalculatingHighScore()
    {
        if (m_highScore <= m_score)
            m_highScore = m_score;

        m_highScoreUI.SetText(m_highScore.ToString());
    }
}
