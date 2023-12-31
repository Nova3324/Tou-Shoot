using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance;

    [SerializeField] private GameObject m_win;
    [SerializeField] private GameObject m_lose;
    [SerializeField] private GameObject m_timerInUI;
    [SerializeField] private GameObject m_timeUI;

    [SerializeField] private TMP_Text m_loseScoreUI;
    [SerializeField] private TMP_Text m_loseTimer;
    [SerializeField] private TMP_Text m_winTimer;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            Debug.LogError("There is two Endgame");
            return;
        }
    }

    public void CheckIfTheGameIsFinish() 
    { 
        if(EnemyManager.Instance.m_enemiesOnTheMap.Count == 0)
        {
            DisplayTheRightMenu();
            Score.Instance.LastEnemyIsDead();
            SaveData.Instance.SaveToJSON();
        }
    }

    public void DisplayTheRightMenu()
    {
        if(EnemyManager.Instance.m_enemiesOnTheMap.Count == 0)
        {
            StartCoroutine(EnableWinMenu());
        }
        else
        {
            m_lose.SetActive(true);
            m_timerInUI.SetActive(false);
            m_timeUI.SetActive(false);
            //m_loseScoreUI.SetText(Score.Instance.m_score.ToString());
            float timerRound = Mathf.Round(Timer.Instance.m_timer * 100f) / 100f;
            m_loseTimer.SetText(timerRound.ToString());
            Time.timeScale = 0;
            GameObject.Find("Player").gameObject.SetActive(false);
        }
    }

    IEnumerator EnableWinMenu()
    {
        yield return new WaitForSeconds(0.7f);
        m_win.SetActive(true);
        m_timerInUI.SetActive(false);
        m_timeUI.SetActive(false);
        float timerRound = Mathf.Round(Timer.Instance.m_timer * 100f) / 100f;
        m_winTimer.SetText(timerRound.ToString());
        Time.timeScale = 0;
        GameObject.Find("Player").gameObject.SetActive(false);
    }
}
