using TMPro;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int m_life;
    [SerializeField] private TMP_Text m_lifeText;

    public static PlayerLife Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            return;
        }
    }

    private void Update()
    {
        m_lifeText.SetText(m_life.ToString());     
    }
}
