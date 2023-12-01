using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IntroAudioManager : MonoBehaviour
{
    [SerializeField] List<AudioSource> m_sounds = new List<AudioSource>();

    public static IntroAudioManager Instance;

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
    public void Explosion()
    {
        m_sounds.Where(obj => obj.name == "Explosion").SingleOrDefault().Play();
    }

    public void Laser()
    {
        m_sounds.Where(obj => obj.name == "Laser").SingleOrDefault().Play();
    }

    public void StarShipMouvement()
    {
        m_sounds.Where(obj => obj.name == "StarShipMouvement").SingleOrDefault().PlayDelayed(0.8f);
        StartCoroutine(StartFade(m_sounds.Where(obj => obj.name == "StarShipMouvement").SingleOrDefault(), 3f, 0f));
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
