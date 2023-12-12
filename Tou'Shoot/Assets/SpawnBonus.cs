using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    public GameObject m_bonus;
    public GameObject m_lastBonus;
    public List<GameObject> m_bonusList = new List<GameObject>();
    public List<GameObject> m_bonusOnPlayer = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(BonusSpawn());
    }
    void Update()
    {

    }

    private IEnumerator BonusSpawn()
    {
        while (true) 
        {
            yield return new WaitForSeconds(30f);
            SpawnBonusObject();
            StartCoroutine(DestroyBonusAfterDelay());
        }
    }

    private IEnumerator DestroyBonusAfterDelay()
    {
        yield return new WaitForSeconds(35f);

        if (m_bonus != null && !m_bonusOnPlayer.Contains(m_bonus))
        {
            Destroy(m_lastBonus);
            m_lastBonus = m_bonus;
        }
    }

    private void SpawnBonusObject()
    {
        int randombonus = Random.Range(0, m_bonusList.Count);
        m_bonus = Instantiate(m_bonusList[randombonus], new Vector3(Random.Range(-8.31f, 0.16f), Random.Range(0, -4.31f), 0), Quaternion.identity);
        if (m_lastBonus == null)
            m_lastBonus = m_bonus;
    }
}
