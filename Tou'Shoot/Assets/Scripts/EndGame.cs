using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance;
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
            Debug.Log("The Game is Finish");
        }
    }
}
