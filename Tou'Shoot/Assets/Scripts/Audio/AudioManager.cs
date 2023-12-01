using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioSource> m_sources = new List<AudioSource>();
    public List<AudioSource> m_musics = new List<AudioSource>();

    public AudioSource m_musicInProgress;

    public static AudioManager Instance;

    private void Awake()
    {
        if(Instance == null) 
            Instance = this;
        else
        {
            Destroy(this);
            Debug.Log("There is two AudioManager");
            return;
        }
    }

    private void Start()
    {
        PlaySoundStarShip();
        StartCoroutine(StartFade(m_sources.Where(obj => obj.name == "StarShip").SingleOrDefault(), 3f, 0f));
    }

    public void PlaySoundLaser()
    {
        m_sources.Where(obj => obj.name == "Laser").SingleOrDefault().Play();
    }

    public void PlaySoundExplosion()
    {
        m_sources.Where(obj => obj.name == "Explosion").SingleOrDefault().Play();
    }

    public void PlaySoundStarShip()
    {
        m_sources.Where(obj => obj.name == "StarShip").SingleOrDefault().Play();
    }

    public void PlaySoundCountDown()
    {
        m_sources.Where(obj => obj.name == "CountDown").SingleOrDefault().Play();
    }

    public void PlayMusicInGame()
    {
        int index = Random.Range(0, m_musics.Count);
        
        m_musicInProgress = m_musics[index];
        
        StartCoroutine(StartFade(m_musicInProgress, 3f, 0.5f));
        m_musicInProgress.Play();
    }

    public void InitFirstMusic()
    {
        if (m_musicInProgress == null)
        {
            m_musicInProgress = m_musics[Random.Range(0, m_musics.Count)];
        }
    }

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
