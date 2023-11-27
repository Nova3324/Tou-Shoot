using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player Bullet") || other.gameObject.CompareTag("Enemy Bullet"))
        {
            other.gameObject.SetActive(false); 
        }
    }
}
