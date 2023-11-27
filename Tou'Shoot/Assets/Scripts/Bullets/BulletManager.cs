using System.Linq;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public enum m_enum
    {
        north, south, west, east
    }

    [Tooltip("Sélectionner une option")]
    public m_enum m_direction;
    public float m_speed;
}
