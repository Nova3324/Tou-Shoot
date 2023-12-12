using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBonus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DoubleBullets());
            transform.position = new Vector3(-10, -10, 0);
            GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().m_bonusOnPlayer.Add(this.gameObject);
        }
    }

    private IEnumerator DoubleBullets()
    {
        GameObject.Find("Player").GetComponent<FirePlayer>().m_bulletBonusIsActive = true;
        yield return new WaitForSeconds(30f);
        GameObject.Find("Player").GetComponent<FirePlayer>().m_bulletBonusIsActive = false;
        GameObject.Find("SpawnBonus").GetComponent<SpawnBonus>().m_bonusOnPlayer.Remove(this.gameObject);
        Destroy(gameObject);
    }
}
