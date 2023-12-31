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

    /*---------------------------------------------------------------------------SOUNDS----------------------------------------------------------------------------*/

    public void Button()
    {
        m_sounds.Where(obj => obj.name == "Button").SingleOrDefault().Play();
    }

    /*---------------------------------------------------------------------------MUSICS----------------------------------------------------------------------------*/

    public void MainMenuMusic()
    {
        StartCoroutine(StartFade(m_musics.Where(obj => obj.name == "Main Menu Music").SingleOrDefault(), 3f, 0.5f));
        m_musics.Where(obj => obj.name == "Main Menu Music").SingleOrDefault().Play();
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
