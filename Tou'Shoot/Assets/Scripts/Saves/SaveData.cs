using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    public DataHighScore m_saveGameData = new DataHighScore();

    public static SaveData Instance;

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
        if (File.Exists(Application.dataPath + "/Saves/HighScoreSave.json"))
            LoadFromJSON();
        else
            SaveToJSON();
    }
    public void SaveToJSON()
    {
        m_saveGameData.m_highScore = Score.Instance.m_highScore;

        string gameData = JsonUtility.ToJson(m_saveGameData);
        File.WriteAllText(Application.dataPath + "/Saves/HighScoreSave.json", gameData);
        Debug.Log("Sauvegarde effectuée");
    }

    public void LoadFromJSON()
    {
        string filePath = Application.dataPath + "/Saves/HighScoreSave.json";
        string gameData = File.ReadAllText(filePath);

        m_saveGameData = JsonUtility.FromJson<DataHighScore>(gameData);
        Score.Instance.m_highScore = m_saveGameData.m_highScore;
        Debug.Log("Chargement effectuée");

    }
}