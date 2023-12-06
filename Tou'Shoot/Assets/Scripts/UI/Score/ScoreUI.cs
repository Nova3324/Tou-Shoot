using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text m_highScoreUI;
    private int m_highScore;
    public DataHighScore m_saveGameData = new DataHighScore();
    void Start()
    {
        
    }

    void Update()
    {
        if (File.Exists(Application.dataPath + "/Saves/HighScoreSave.json"))
        {
            string filePath = Application.dataPath + "/Saves/HighScoreSave.json";
            string gameData = File.ReadAllText(filePath);

            m_saveGameData = JsonUtility.FromJson<DataHighScore>(gameData);

            m_highScore = m_saveGameData.m_highScore;
            m_highScoreUI.text = m_highScore.ToString();    
            m_highScoreUI.color = Color.yellow;
        }
        else
        {
            m_highScoreUI.SetText("No high score is saved !");
            m_highScoreUI.fontSize = 30;
            m_highScoreUI.alignment = TextAlignmentOptions.Center;
            m_highScoreUI.color = Color.yellow;
        }
    }
}
