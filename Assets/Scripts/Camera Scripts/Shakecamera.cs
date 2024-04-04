using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shakecamera : MonoBehaviour
{
    public float power = 0.2f;
    public float duration = 0.2f;
    public float slowDownAmount = 1f;
    private bool shouldShake;
    private float initialDuration;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            Shake();
        }
    }

    void Shake()
    {
        if (shouldShake)
        {
            if (duration > 0f)
            {
                // The Random.insideUnitSphere will create a small circle around the camera a will move the camera to any random point in that circle
                transform.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime + slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                transform.localPosition = startPosition;
            }
        }
    }

    public bool ShouldShake
    {
        get
        {
            return shouldShake;
        }
        set
        {
            shouldShake = value;
        }
    }

}
