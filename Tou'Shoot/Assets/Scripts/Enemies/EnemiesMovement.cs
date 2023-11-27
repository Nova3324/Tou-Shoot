using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> m_points = new List<Transform>();
    [SerializeField] private float m_time;
    [SerializeField, Range(0,5)] private float m_rotationTime;

    private Vector3 m_currentPosition;
    [SerializeField] private int m_index;
    private float m_elapsedTime;
    private bool m_roundTrip = true;
    private bool m_canMove = true;
    [SerializeField] private bool m_loop;
    [SerializeField] private AnimationCurve m_curve; 
    void Start()
    {
        m_currentPosition = transform.position;
    }

    void Update()
    {
        Movements();
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, 10 * m_rotationTime * Time.deltaTime);
    }

    private void Movements()
    {
        if(m_canMove) 
        {
            m_elapsedTime += Time.deltaTime;
            float time = m_elapsedTime / m_time;

            transform.position = Vector3.LerpUnclamped(m_currentPosition, m_points[m_index].position, m_curve.Evaluate(time));

            if (time >= 1)
            {
                m_canMove = false;
                StartCoroutine(WaitForMove());
            }
        }
    }

    private void UpdatePosition()
    {
        m_elapsedTime = 0;
        m_currentPosition = m_points[m_index].position;

        if(m_loop)
        {
            m_index++;
            if (m_index >= m_points.Count)
            {
                m_index = 0;
            }
        }
        else if(!m_loop) 
        {
            if (m_index >= m_points.Count - 1)
                m_roundTrip = false;
            else if (m_index == 0)
                m_roundTrip = true;

            if (m_roundTrip)
                m_index++;
            else
                m_index--;
        }
        
        
        m_canMove = true;
    }

    IEnumerator WaitForMove() 
    { 
        yield return new WaitForSeconds(Random.Range(1,7));
        UpdatePosition();
    }
}
