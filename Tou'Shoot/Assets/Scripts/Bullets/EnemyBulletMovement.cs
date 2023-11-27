using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    private Rigidbody2D m_rigidBody;
    [SerializeField] private float m_speed;
    private FireEnemies m_fireEnemies;
    public m_enum m_enemy;

    public enum m_enum
    {
        first, second, third, fourth
    }

    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        ChooseComponent();
    }
    private void Update()
    {
        BulletMovement();
    }

    private void ChooseComponent()
    {
        switch (m_enemy)
        {
            case m_enum.first:
                m_fireEnemies = GameObject.Find("1st enemy(Clone)").GetComponent<FireEnemies>();
                break;
            case m_enum.second:
                m_fireEnemies = GameObject.Find("2nd enemy(Clone)").GetComponent<FireEnemies>();
                break;
            case m_enum.third:
                m_fireEnemies = GameObject.Find("3rd enemy(Clone)").GetComponent<FireEnemies>();
                break;
            case m_enum.fourth:
                m_fireEnemies = GameObject.Find("4th enemy(Clone)").GetComponent<FireEnemies>();
                break;
            default:
                break;
        }
    }

    public void BulletMovement()
    {
        Vector2 vector = new Vector2(1f, 0f) * m_speed;
        switch (gameObject.name)
        {
            case "North(Clone)":
                m_rigidBody.velocity = m_fireEnemies.m_origin[0].right * m_speed;
                break;
            case "South(Clone)":
                m_rigidBody.velocity = m_fireEnemies.m_origin[1].right * m_speed;
                break;
            case "East(Clone)":
                m_rigidBody.velocity = m_fireEnemies.m_origin[2].right * m_speed;
                break;
            case "West(Clone)":
                m_rigidBody.velocity = m_fireEnemies.m_origin[3].right * m_speed;
                break;
            default: break;
        }
    }
}
