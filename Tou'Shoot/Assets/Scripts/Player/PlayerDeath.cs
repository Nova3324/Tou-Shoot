using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy Bullet"))
        {
            Debug.Log("Player Death");
            SaveData.Instance.SaveToJSON();
            //EndGame.Instance.DisplayTheRightMenu();
        }
    }
}
