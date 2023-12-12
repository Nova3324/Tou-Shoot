using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_enemyList = new List<GameObject>();
    [SerializeField] private List<GameObject> m_spawnPoints = new List<GameObject>();

    public EnemyLife m_enemyLife;

    public GameObject m_enemy;
    public bool m_infini;
    private bool m_canIncreaseLife = false;
    public bool hasSpawnedOnce = false;

    public int m_enemyCount;

    [SerializeField] private int m_WaitForSpawn;
    private int m_maxEnemies;
    private int m_index = 0;

    private bool m_canSpawn = true;

    public static Enemies Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            Debug.Log("There is two Enemies");
            return;
        }

        for(int i = 0;  i < m_enemyList.Count; ++i) 
        {
            m_enemyList[i].GetComponentInChildren<EnemyLife>().m_maxLife = 10;
        }
    }
    void Start()
    {
        if(!m_infini)
        {
            m_maxEnemies = m_enemyList.Count;
            StartCoroutine(SpawnEnemy());
        }
    }

    private void Update()
    {
        if(m_infini)
        { 
            ModeInfini();
            Difficulty();
        }
    }

    IEnumerator SpawnEnemy()
    {
        if(!m_infini)
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

    private void ModeInfini()
    {
        if (m_canSpawn)
        {
            m_enemy = Instantiate(m_enemyList[m_index], m_spawnPoints[m_index].transform.position, m_spawnPoints[m_index].transform.rotation);
            EnemyManager.Instance.AddEnemyinList();
            m_enemyCount++;
            m_enemyLife = m_enemyList[m_index].GetComponentInChildren<EnemyLife>();

            m_enemyLife.m_maxLife = (int)(m_enemyLife.m_maxLife * 1.1f);
            m_enemyList[m_index].GetComponentInChildren<EnemyLife>().m_maxLife = (int)(m_enemyList[m_index].GetComponentInChildren<EnemyLife>().m_maxLife * 1.1f);

            m_canSpawn = false;
        }
        int percentageoflife = m_enemy.GetComponentInChildren<EnemyLife>().m_life  * 100 / m_enemy.GetComponentInChildren<EnemyLife>().m_maxLife;
        Debug.Log("Pourcentage : " + percentageoflife);

        if (!hasSpawnedOnce && percentageoflife <= 20)
        {
            m_canSpawn = true;
            m_index++;
            if (m_index >= m_enemyList.Count)
                m_index = 0;
            m_canIncreaseLife = true;
            hasSpawnedOnce = true;
        }
    }

    private void Difficulty()
    {
        if (m_enemyCount % 4 == 0 && m_canIncreaseLife)
        {
            for (int i = 0; i < m_enemyList.Count; i++)
                m_enemyList[i].GetComponentInChildren<EnemyLife>().m_maxLife = (int)(m_enemyList[i].GetComponentInChildren<EnemyLife>().m_maxLife * 1.1f);
            m_canIncreaseLife = false;
        }
    }
}
