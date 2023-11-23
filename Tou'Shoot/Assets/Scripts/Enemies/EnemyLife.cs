using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int m_life = 100;

    private void Update()
    {
        Dead();
    }

    public void TakeDamage(int damage)
    {
        m_life -= damage;
        Debug.Log(m_life);
    }

    public void Dead()
    {
        if(m_life <= 0)
        {
            Enemies.Instance.m_enemiesOnTheMap.Remove(transform.parent.parent.gameObject);
            EndGame.Instance.CheckIfTheGameIsFinish();
            transform.parent.parent.gameObject.SetActive(false);
        }
    }
}
