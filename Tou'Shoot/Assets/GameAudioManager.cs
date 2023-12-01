using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    [SerializeField] List<AudioSource> m_sounds = new List<AudioSource>();
    [SerializeField] List<AudioSource> m_musics = new List<AudioSource>();

    [SerializeField] private AudioSource m_currentMusic;

    public static GameAudioManager Instance;
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

    private void Start()
    {
        Countdown();
        InitFirstMusic();
    }

    private void Update()
    {
        Music();
    }

    /*---------------------------------------------------------------------------SOUNDS----------------------------------------------------------------------------*/

    public void Button()
    {
        m_sounds.Where(obj => obj.name == "Button").SingleOrDefault().Play();
    }

    public void Laser()
    {
        m_sounds.Where(obj => obj.name == "Laser").SingleOrDefault().Play();
    }

    public void Explosion()
    {
        m_sounds.Where(obj => obj.name == "Explosion").SingleOrDefault().Play();
    }

    private void Countdown()
    {
        m_sounds.Where(obj => obj.name == "Countdown").SingleOrDefault().PlayDelayed(0.6f);
    }

    /*---------------------------------------------------------------------------MUSICS----------------------------------------------------------------------------*/

    private void Music()
    {
        if(!m_currentMusic.isPlaying)
        {
            int index = Random.Range(0, m_musics.Count);

            m_currentMusic = m_musics[index];
            StartCoroutine(StartFade(m_currentMusic, 3f, 0.5f));
            m_currentMusic.Play();
        }
    }

    private void InitFirstMusic()
    {
        int index = Random.Range(0, m_musics.Count);

        m_currentMusic = m_musics[index];
        StartCoroutine(StartFade(m_currentMusic, 5f, 0.5f));
        m_currentMusic.Play();
    }

    /*---------------------------------------------------------------------------FADE----------------------------------------------------------------------------*/

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
