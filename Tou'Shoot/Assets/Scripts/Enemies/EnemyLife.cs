using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int m_life;
    public int m_maxLife;
    [SerializeField] private GameObject m_explosionPrefab;

    private void Start()
    {
        m_life = m_maxLife;    
    }


    public void TakeDamage(int damage)
    {
        m_life -= damage;
    }

    public void Dead()
    {
        if(m_life <= 0)
        {
            EnemyManager.Instance.m_enemiesOnTheMap.Remove(transform.parent.parent.gameObject);
            Score.Instance.EnemyDeath();
            EnemyManager.Instance.Explosion(m_explosionPrefab, transform.position, Quaternion.identity);
            if(!Enemies.Instance.m_infini)
                EndGame.Instance.CheckIfTheGameIsFinish();

            if (Enemies.Instance.m_infini)
            {
                Enemies.Instance.hasSpawnedOnce = false;
            }
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
