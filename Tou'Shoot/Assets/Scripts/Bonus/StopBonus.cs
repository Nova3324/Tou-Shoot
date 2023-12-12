using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StopBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StopEnemies());
            transform.position = new Vector3(-10, -10, 0);
            GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().m_bonusOnPlayer.Add(this.gameObject);
        }
    }

    private IEnumerator StopEnemies()
    {
        Debug.Log("test");
        foreach(GameObject obj in GameObject.Find("EnemyManager").GetComponent<EnemyManager>().m_enemiesOnTheMap)
        {
            obj.GetComponentInChildren<EnemiesMovement>().m_canMove = false;
        }
        yield return new WaitForSeconds(30f);
        foreach (GameObject obj in GameObject.Find("EnemyManager").GetComponent<EnemyManager>().m_enemiesOnTheMap)
        {
            obj.GetComponentInChildren<EnemiesMovement>().m_canMove = true;
        }
        GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().m_bonusOnPlayer.Remove(this.gameObject);
        Destroy(gameObject);
    }
}
