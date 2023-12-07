using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private bool m_godMode = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy Bullet"))
        {
            Debug.Log("Player Death");
            SaveData.Instance.SaveToJSON();
            if(!m_godMode)
                EndGame.Instance.DisplayTheRightMenu();
        }
    }
}
