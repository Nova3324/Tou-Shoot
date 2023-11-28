using UnityEngine;


public class HighScore
{
    public int m_highScore = 15;
}

public class SaveData : MonoBehaviour
{
    public HighScore m_highScoreToSave = new HighScore();


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
        LoadFromJSON();
    }
    public void SaveToJSON()
    {
        m_highScoreToSave.m_highScore = Score.Instance.m_highScore;
        string highscoreData = JsonUtility.ToJson(m_highScoreToSave);
        Debug.Log(highscoreData);
        string filePath = Application.persistentDataPath + "/save.json";
        System.IO.File.WriteAllText(filePath, highscoreData);
        Debug.Log("Sauvegarde effectuée");
    }

    public void LoadFromJSON()
    {
        string filePath = Application.persistentDataPath + "/save.json";
        string highscoreData = System.IO.File.ReadAllText(filePath);

        m_highScoreToSave = JsonUtility.FromJson<HighScore>(highscoreData);
        Score.Instance.m_highScore = m_highScoreToSave.m_highScore;
        Debug.Log("Chargement effectuée");

    }
}