using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static BulletPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> m_pools;
    public Dictionary<string, Queue<GameObject>> m_poolDictionary;
    void Start()
    {
        m_poolDictionary = new Dictionary<string, Queue<GameObject>>();   

        foreach(Pool pool in m_pools) 
        { 
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++) 
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            m_poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {

        if(!m_poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
            return null;
        }


        GameObject ObjectToSpawn = m_poolDictionary[tag].Dequeue(); 

        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = position;    
        ObjectToSpawn.transform.rotation = rotation;

        m_poolDictionary[tag].Enqueue(ObjectToSpawn);

        return ObjectToSpawn;
    }
}
