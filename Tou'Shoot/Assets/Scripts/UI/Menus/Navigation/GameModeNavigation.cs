using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameModeNavigation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Buttons Text")]
    [SerializeField] private TMP_Text m_backText;

    [Header("Buttons")]
    [SerializeField] private GameObject m_infini;
    [SerializeField] private GameObject m_fast;

    [Header("Animators")]
    [SerializeField] private Animator m_mainMenuAnimator;
    [SerializeField] private Animator m_gamemodeAnimator;
    [SerializeField] private Animator m_transitionAnimator;
    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Infini":
                m_infini.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
                break;
            case "Fast":
                m_fast.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
                break;
            case "Back":
                m_backText.color = new Color32(255, 0, 229, 255);
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        switch(gameObject.name) 
        {
            case "Infini":
                m_infini.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case "Fast":
                m_fast.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case "Back":
                m_backText.color = Color.white;
                break;
            default:
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Infini":
                m_infini.transform.localScale = new Vector3(1f, 1f, 1f);
                StartCoroutine(Infini());

                m_transitionAnimator.SetBool("Transition", true);

                //Audio
                MainMenuAudioManager.Instance.Button();

                break;
            case "Fast":
                m_fast.transform.localScale = new Vector3(1f, 1f, 1f);
                StartCoroutine(Limit());

                m_transitionAnimator.SetBool("Transition", true);

                //Audio
                MainMenuAudioManager.Instance.Button();
                break;
            case "Back":
                m_gamemodeAnimator.SetBool("GameMode", true);
                m_gamemodeAnimator.SetBool("MainMenu", false);

                m_mainMenuAnimator.SetBool("GameMode", false);
                m_mainMenuAnimator.SetBool("MainMenu", true);
                break;
            default:
                break;
        }
    }

    /*---------------------------------------------------------------------------METHODS----------------------------------------------------------------------------*/

    IEnumerator Limit()
    {
        yield return new WaitForSeconds(0.8f);

        SceneManager.LoadScene("Fast");
        if (Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }
    IEnumerator Infini()
    {
        yield return new WaitForSeconds(0.8f);


        SceneManager.LoadScene("Infini");
        if (Time.timeScale != 1)
            Time.timeScale = 1.0f;
    }

}
