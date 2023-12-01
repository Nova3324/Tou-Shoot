using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementStation : MonoBehaviour
{
    private Vector3 m_startPosition;
    private Vector3 m_destination;
    private float m_elapsedTime;
    [SerializeField] private float m_time;
    [SerializeField] private AnimationCurve m_curve;
    void Start()
    {
        m_startPosition = transform.position;
        m_destination = new Vector3(0, transform.position.y, transform.position.z);
    }
    void Update()
    {
        MoveGameObject();
    }

    public void MoveGameObject()
    {
        m_elapsedTime += Time.deltaTime;
        float time = Mathf.Clamp01(m_elapsedTime / m_time);

        transform.position = Vector3.Lerp(m_startPosition, m_destination, m_curve.Evaluate(time));
    }
}
