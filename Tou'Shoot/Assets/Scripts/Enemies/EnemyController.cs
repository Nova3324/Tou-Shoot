using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyLife m_enemyLife;
    void Start()
    {
        m_enemyLife = GameObject.Find("Life Collider").GetComponentInChildren<EnemyLife>();    
    }
    
    void Update()
    {
        m_enemyLife.Dead();   
    }
}
