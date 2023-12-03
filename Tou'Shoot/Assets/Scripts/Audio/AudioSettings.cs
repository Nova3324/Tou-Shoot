using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [Header("Sliders")]
    public Slider m_soundsSlider;
    public Slider m_musicsSlider;

    [Header("Audio")]
    [SerializeField] private List<AudioSource> m_sounds = new List<AudioSource>();
    [SerializeField] private List<AudioSource> m_musics = new List<AudioSource>();

    public static AudioSettings Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            Debug.LogError("There is two AudioSettings");
            return;
        }
    }

    void Update()
    {
        SetSoundsVolume();
        SetMusicVolume();
    }

    public void SetMusicVolume()
    {
        for(int i = 0; i < m_musics.Count; i++) 
            m_musics[i].volume = m_musicsSlider.value;
    }

    public void SetSoundsVolume()
    {
        for (int i = 0; i < m_sounds.Count; i++)
            m_sounds[i].volume = m_soundsSlider.value;
    }
}
