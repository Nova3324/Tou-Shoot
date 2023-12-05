using UnityEngine;
using System.IO;
using System.Collections;

public class SaveAudioSettings : MonoBehaviour
{
    public DataAudioSettings m_DataAudioSettings = new DataAudioSettings();

    private string saveFolderPath = Application.dataPath + "/Saves";


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
        if (!Directory.Exists(saveFolderPath))
        {
            Directory.CreateDirectory(saveFolderPath);
        }

        Debug.Log(saveFolderPath);

        if (File.Exists(Application.dataPath + "/Saves/AudioSettings.json"))
        {
            LoadFromJSON();
            StartCoroutine(HideSettings()); 
        }
        else
        {
            SaveToJSON();
            StartCoroutine(HideSettings());
        }
    }

    public void SaveToJSON()
    {
        m_DataAudioSettings.musicsSlider = AudioSettings.Instance.m_musicsSlider.value;
        m_DataAudioSettings.sounddsSlider = AudioSettings.Instance.m_soundsSlider.value;

        string gameData = JsonUtility.ToJson(m_DataAudioSettings);
        File.WriteAllText(Application.dataPath + "/Saves/AudioSettings.json", gameData);
        Debug.Log("Paramètres audio sauvegardés");
    }
    public void LoadFromJSON()
    {
        string filePath = Application.dataPath + "/Saves/AudioSettings.json";
        string gameData = File.ReadAllText(filePath);

        m_DataAudioSettings = JsonUtility.FromJson<DataAudioSettings>(gameData);
        AudioSettings.Instance.m_musicsSlider.value = m_DataAudioSettings.musicsSlider;
        AudioSettings.Instance.m_soundsSlider.value = m_DataAudioSettings.sounddsSlider;
        Debug.Log("Paramètres audio chargés");
    }

    public void ResetMusicsSettings()
    {
        string filePath = Application.dataPath + "/Saves/AudioSettings.json";
        string gameData = File.ReadAllText(filePath);

        m_DataAudioSettings = JsonUtility.FromJson<DataAudioSettings>(gameData);
        m_DataAudioSettings.musicsSlider = 0.5f;
        AudioSettings.Instance.m_musicsSlider.value = m_DataAudioSettings.musicsSlider;
        Debug.Log("Reset Music");
    }

    public void ResetSoundsSettings()
    {
        string filePath = Application.dataPath + "/Saves/AudioSettings.json";
        string gameData = File.ReadAllText(filePath);

        m_DataAudioSettings = JsonUtility.FromJson<DataAudioSettings>(gameData);
        m_DataAudioSettings.sounddsSlider = 0.5f;
        AudioSettings.Instance.m_soundsSlider.value = m_DataAudioSettings.sounddsSlider;
        Debug.Log("Reset Sounds");
    }
   

    public IEnumerator HideSettings()
    {
        yield return new WaitForSeconds(0.3f); 
        m_settings.SetActive(false);
        Debug.Log("test");
    }

}
