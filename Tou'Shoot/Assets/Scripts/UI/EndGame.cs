using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance;

    [SerializeField] private GameObject m_win;
    [SerializeField] private GameObject m_lose;

    [SerializeField] private TMP_Text m_loseScoreUI;
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
            m_loseScoreUI.SetText(Score.Instance.m_score.ToString());
            Time.timeScale = 0;
            GameObject.Find("Player").gameObject.SetActive(false);
        }
    }

    IEnumerator EnableWinMenu()
    {
        yield return new WaitForSeconds(0.7f);
        m_win.SetActive(true);
        Time.timeScale = 0;
        GameObject.Find("Player").gameObject.SetActive(false);
    }
}
