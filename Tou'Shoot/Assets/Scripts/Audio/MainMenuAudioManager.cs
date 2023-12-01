using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainMenuAudioManager : MonoBehaviour
{
    [SerializeField] List<AudioSource> m_sounds = new List<AudioSource>();
    [SerializeField] List<AudioSource> m_musics = new List<AudioSource>();

    public static MainMenuAudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            Debug.LogError("There is two component Audio Manager in the scene : Intro");
            return;
        }
    }
    
    public void Button()
    {
        m_sounds.Where(obj => obj.name == "Button").SingleOrDefault().Play();
    }

    public void MainMenuMusic()
    {
        m_musics.Where(obj => obj.name == "Main Menu Music").SingleOrDefault().Play();
    }
}
