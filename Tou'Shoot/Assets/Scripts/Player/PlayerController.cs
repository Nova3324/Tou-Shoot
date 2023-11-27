using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovements), typeof(FirePlayer), typeof(PlayerLife))]
public class PlayerController : MonoBehaviour
{
    private PlayerMovements m_playerMovements;
    public bool m_canFire = false;
    void Start()
    {
        m_playerMovements = GetComponent<PlayerMovements>();   
    }
    
    public void Move(Vector2 vector)
    {
        m_playerMovements.Move(vector);
    }
}
