using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float m_timer;
    [SerializeField] private TMP_Text m_timerText;

    public static Timer Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            Debug.Log("There is two Timer");
            return;
        }
    }

    private void Update()
    {
        TimerForKillEnemies();
    }

    public void TimerForKillEnemies()
    {
        m_timer += Time.deltaTime;
        float timerRound = Mathf.Round(m_timer * 100f) / 100f;
        m_timerText.SetText(timerRound.ToString());
    }
}
