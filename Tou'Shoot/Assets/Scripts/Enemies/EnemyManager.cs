using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> m_enemiesOnTheMap = new List<GameObject>();

    public bool m_infini;

    public static EnemyManager Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            Debug.Log("There is two enemyManager");
            return;
        }
    }

    public void AddEnemyinList()
    {
        m_enemiesOnTheMap.Add(Enemies.Instance.m_enemy);
        if(!m_infini) 
            StartCoroutine(SetLife());
    }

    public void Explosion(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        Instantiate(prefab, position, rotation);
    }

    private IEnumerator SetLife()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < m_enemiesOnTheMap.Count; i++)
        {
            m_enemiesOnTheMap[i].transform.GetChild(0).GetComponentInChildren<EnemyLife>().m_life = 50;
        }
    }
}
