using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    private float m_speed = 5f;
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();     
    }
    
    void Update()
    {
        BulletMove();
    }

    public void BulletMove()
    {
        m_rigidbody.velocity = Vector2.up * m_speed;

    }
}
