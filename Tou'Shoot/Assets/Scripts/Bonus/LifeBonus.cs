using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("test");
            GameObject.Find("Player").GetComponent<PlayerLife>().m_life += 1;
            Destroy(this.gameObject);
        }
    }
}
