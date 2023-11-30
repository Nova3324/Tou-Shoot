using UnityEngine;

public class AnimButtonsMainMenu : MonoBehaviour
{
    [SerializeField] private Animator m_animator;

    public void ButtonsMainMenu()
    {
        m_animator.SetBool("ButtonsMainMenu", true);
        GameObject.Find("Circle").gameObject.SetActive(false);
    }
}
