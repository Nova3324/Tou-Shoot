using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    private float m_speed = 5;
    private Vector2 m_movements;
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();   
    }
    void Update()
    {
        Movements();     
    }

    public void Move(Vector2 vector2)
    {
        m_movements = vector2;                   
    }

    private void Movements()
    {
        m_rigidbody.velocity = m_movements * m_speed;
    }
}
