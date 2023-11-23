using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int m_life = 100;

    public void TakeDamage(int damage)
    {
        m_life -= damage;
        Debug.Log(m_life);
    }
}
