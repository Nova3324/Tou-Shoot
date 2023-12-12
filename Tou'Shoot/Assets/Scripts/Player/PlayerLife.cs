using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int m_life;

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

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
