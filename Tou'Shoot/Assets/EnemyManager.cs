using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> m_enemiesOnTheMap = new List<GameObject>();

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
    }

    public void Explosion(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        Instantiate(prefab, position, rotation);
    }
}
