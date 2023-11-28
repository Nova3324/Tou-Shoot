using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance;

    [SerializeField] private GameObject m_win;
    [SerializeField] private GameObject m_lose;
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
        if(Enemies.Instance.m_enemiesOnTheMap.Count == 0)
        {
            DisplayTheRightMenu();
            Score.Instance.LastEnemyIsDead();
            SaveData.Instance.SaveToJSON();
        }
    }

    public void DisplayTheRightMenu()
    {
        if(Enemies.Instance.m_enemiesOnTheMap.Count == 0)
        {
            m_win.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            m_lose.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
