using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Vector2 amplitude;
    public Vector2 frequency;
    Vector2 time = Vector2.zero;
    static bool shouldShake;
    static float shakeTime;

    // Update is called once per frame
    void Update()
    {
        time.x += Time.deltaTime * frequency.x;
        time.y += Time.deltaTime * frequency.y;

        Vector3 shakePos;

        if(shakeTime > 0)
        {
            shouldShake = true;
        }
        else
        {
            shouldShake = false;
        }

        shakeTime -= Time.deltaTime;

        if (shouldShake)
        {
            shakePos = new Vector3(Mathf.Sin(time.x), Mathf.Sin(time.y),0) * amplitude;
        }
        else
        {
            shakePos = Vector3.zero;
        }

        transform.localPosition = shakePos;
    }

    public static void Shake(bool value)
    {
        shouldShake = value;
    }

    public static void Shake(float timeShake)
    {
        shakeTime = timeShake;
    }
}
