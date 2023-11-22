using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovements m_playerMovements;
    void Start()
    {
        m_playerMovements = GetComponent<PlayerMovements>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 vector)
    {
        m_playerMovements.Move(vector);
    }
}
