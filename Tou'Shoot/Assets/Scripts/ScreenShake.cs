using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float amount;
    public float shakeSpeed;

    void Update()
    {
        float x = Mathf.PerlinNoise(Time.time * shakeSpeed, 0f);
        float y = Mathf.PerlinNoise(Time.time * shakeSpeed, 0.5f);

        Vector3 offset = new Vector3(x - 0.5f, y - 0.5f, 0f);
        offset *= amount;
        offset.z = transform.position.z;

        transform.localPosition = offset;
    }
}
