using UnityEngine;
using System.IO;

public class SaveAudioSettings : MonoBehaviour
{
    public DataAudioSettings m_DataAudioSettings = new DataAudioSettings();

    [SerializeField] private GameObject m_settings;
    
    public static SaveAudioSettings Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            Debug.LogError("There is two SaveAudioSettings");
            return;
        }
    }

    private void Start()
    {
        if (File.Exists(Application.dataPath + "/AudioSettings.json"))
        {
            LoadFromJSON();
            Invoke("HideSettings", 0.3f);
        }
        else
            return;
    }

    public void SaveToJSON()
    {
        m_DataAudioSettings.musicsSlider = AudioSettings.Instance.m_musicsSlider.value;
        m_DataAudioSettings.sounddsSlider = AudioSettings.Instance.m_soundsSlider.value;

        string gameData = JsonUtility.ToJson(m_DataAudioSettings);
        File.WriteAllText(Application.dataPath + "/AudioSettings.json", gameData);
        Debug.Log("Paramètres audio sauvegardés");
    }
    public void LoadFromJSON()
    {
        string filePath = Application.dataPath + "/AudioSettings.json";
        string gameData = File.ReadAllText(filePath);

        m_DataAudioSettings = JsonUtility.FromJson<DataAudioSettings>(gameData);
        AudioSettings.Instance.m_musicsSlider.value = m_DataAudioSettings.musicsSlider;
        AudioSettings.Instance.m_soundsSlider.value = m_DataAudioSettings.sounddsSlider;
        Debug.Log("Paramètres audio chargés");
    }

    public void ResetMusicsSettings()
    {
        string filePath = Application.dataPath + "/AudioSettings.json";
        string gameData = File.ReadAllText(filePath);

        m_DataAudioSettings = JsonUtility.FromJson<DataAudioSettings>(gameData);
        m_DataAudioSettings.musicsSlider = 0.5f;
        AudioSettings.Instance.m_musicsSlider.value = m_DataAudioSettings.musicsSlider;
        Debug.Log("Reset Music");
    }

    public void ResetSoundsSettings()
    {
        string filePath = Application.dataPath + "/AudioSettings.json";
        string gameData = File.ReadAllText(filePath);

        m_DataAudioSettings = JsonUtility.FromJson<DataAudioSettings>(gameData);
        m_DataAudioSettings.sounddsSlider = 0.5f;
        AudioSettings.Instance.m_soundsSlider.value = m_DataAudioSettings.sounddsSlider;
        Debug.Log("Reset Sounds");
    }
    
    private void HideSettings()
    {
        m_settings.SetActive(false);
    }
}
