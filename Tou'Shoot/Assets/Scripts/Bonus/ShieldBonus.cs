using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ActiveShield());
            transform.position = new Vector3(-10, -10, 0);
            GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().m_bonusOnPlayer.Add(this.gameObject);
        }
    }

    private IEnumerator ActiveShield()
    {
        GameObject.Find("Player").transform.GetChild(4).gameObject.SetActive(true);
        yield return new WaitForSeconds(15f);
        GameObject.Find("Player").transform.GetChild(4).gameObject.SetActive(false);
        GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().m_bonusOnPlayer.Remove(this.gameObject);
        Destroy(gameObject);
    }
}
