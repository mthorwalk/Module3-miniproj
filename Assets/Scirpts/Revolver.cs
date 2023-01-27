using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Revolver : MonoBehaviour
{
    private float angleMax = Mathf.PI * 2;
    private float radius = 5.0f;
    private float angleTime = 0.0f;

    void Update()
    {
        float angleNew = Time.deltaTime + angleTime;
        angleTime += Time.deltaTime;
        float xNew = radius * Mathf.Sin(angleNew);
        float zNew = radius * Mathf.Cos(angleNew);

        if (angleTime >= angleMax)
        {
            angleTime = 0.0f;
        }

        transform.position = new Vector3(xNew, 0.75f, zNew);
    }
}
