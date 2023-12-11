using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private bool m_godMode = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy Bullet"))
        {
            if(!m_godMode)
            {
                PlayerLife.Instance.m_life -= 1;

                if(PlayerLife.Instance.m_life <= 0)
                {
                    Debug.Log("Player Death");
                    EndGame.Instance.DisplayTheRightMenu();
                    SaveData.Instance.SaveToJSON();
                }
            }
        }
    }
}
