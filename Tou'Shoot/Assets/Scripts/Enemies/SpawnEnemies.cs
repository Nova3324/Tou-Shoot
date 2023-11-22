using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_enemyList = new List<GameObject>();
    [SerializeField] private List<GameObject> m_spawnPoints = new List<GameObject>();
    
    [SerializeField] private int m_WaitForSpawn;
    private int m_maxEnemies;
    private int m_index = 0;
    
    private bool m_canSpawn = true;
    void Start()
    {
        m_maxEnemies = m_enemyList.Count;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (m_index < m_maxEnemies)
        {
            if (m_canSpawn)
            {
                Instantiate(m_enemyList[m_index], m_spawnPoints[m_index].transform.position, m_spawnPoints[m_index].transform.rotation);
                m_index++;

                m_canSpawn = false;
                yield return new WaitForSeconds(m_WaitForSpawn);
                m_canSpawn = true;
            }
            yield return null;
        }
    }
}
