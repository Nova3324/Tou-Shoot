using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_enemyList = new List<GameObject>();
    [SerializeField] private List<GameObject> m_spawnPoints = new List<GameObject>();

    public GameObject m_enemy;

    
    [SerializeField] private int m_WaitForSpawn;
    private int m_maxEnemies;
    private int m_index = 0;
    
    private bool m_canSpawn = true;

    public static Enemies Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            Debug.Log("There is two Enemies");
            return;
        }
            
    }
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
                m_enemy = Instantiate(m_enemyList[m_index], m_spawnPoints[m_index].transform.position, m_spawnPoints[m_index].transform.rotation);
                EnemyManager.Instance.AddEnemyinList();
                m_index++;

                m_canSpawn = false;
                yield return new WaitForSeconds(m_WaitForSpawn);
                m_canSpawn = true;
            }
            yield return null;
        }
    }
}
