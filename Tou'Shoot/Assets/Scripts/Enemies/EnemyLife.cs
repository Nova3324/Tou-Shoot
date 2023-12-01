using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int m_life = 10;
    [SerializeField] private GameObject m_explosionPrefab;

    private void Update()
    {
        
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
            EnemyManager.Instance.m_enemiesOnTheMap.Remove(transform.parent.parent.gameObject);
            EndGame.Instance.CheckIfTheGameIsFinish();
            Score.Instance.EnemyDeath();
            EnemyManager.Instance.Explosion(m_explosionPrefab, transform.position, Quaternion.identity);
            StartCoroutine(DisableEnemy());

            //Audio
            GameAudioManager.Instance.Explosion();
        }
    }

    IEnumerator DisableEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        transform.parent.parent.gameObject.SetActive(false);
    }
}
