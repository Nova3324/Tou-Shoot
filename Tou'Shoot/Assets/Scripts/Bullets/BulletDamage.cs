using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    EnemyLife m_enemyLife;
    private int m_damage = 1;

    private void Start()
    {
        m_enemyLife = GetComponent<EnemyLife>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            m_enemyLife.TakeDamage(m_damage);
            collision.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("This object don't have Bullet tag");
        }
    }
}
