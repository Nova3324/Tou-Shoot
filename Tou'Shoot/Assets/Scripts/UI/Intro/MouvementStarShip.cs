using UnityEngine;
using System.IO;

public class MouvementStarShip : MonoBehaviour
{
    private Vector3 m_startPosition;
    private Vector3 m_destination;
    private float m_elapsedTime;
    private GameObject m_bullet;

    [Header("Mouvements")]
    [SerializeField] private float m_time;
    [SerializeField] private AnimationCurve m_curve;

    [Header("Prefab")]
    [SerializeField] private GameObject m_bulletPrefab;
    [SerializeField] private GameObject m_explosionPrefab;

    [Header("GameObjects")]
    [SerializeField] private GameObject m_station;
    [SerializeField] private GameObject m_transition;

    private bool m_hasShot = false;
    private bool m_hasExplose = false;
    void Start()
    {
        m_startPosition = transform.position;
        m_destination = new Vector3(4, transform.position.y, transform.position.z);

        IntroAudioManager.Instance.StarShipMouvement();
    }
    void Update()
    {
        MoveGameObject();
        ShootStation();
    }

    public void MoveGameObject()
    {
        m_elapsedTime += Time.deltaTime;
        float time = Mathf.Clamp01(m_elapsedTime / m_time);

        transform.position = Vector3.Lerp(m_startPosition, m_destination, m_curve.Evaluate(time));

        if (time >= 1 && !m_hasShot)
        {
            m_bullet = Instantiate(m_bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
            m_hasShot = true;

            //Audio
            IntroAudioManager.Instance.Laser();
        }

    }

    public void ShootStation()
    {
        if (m_hasShot)
        {
            m_bullet.transform.position += Vector3.left * 0.05f;
            
            if (m_bullet.transform.position.x <= 1.032f && !m_hasExplose)
            {
                Instantiate(m_explosionPrefab);
                m_station.SetActive(false);
                m_transition.SetActive(true);
                m_hasExplose = true;
                m_bullet.SetActive(false);

                //Audio
                IntroAudioManager.Instance.Explosion();
            }
        }
    }
}
