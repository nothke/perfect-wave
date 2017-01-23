using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyCam : MonoBehaviour
{

    public Vector3 startRot;

    public float gain = 10;
    public float frequency = 10;

    // Use this for initialization
    void Start()
    {
        startRot = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        float rotX = Mathf.PerlinNoise(Time.time * frequency, 456.43f) * gain;
        float rotY = Mathf.PerlinNoise(Time.time * frequency, 434.95f) * gain;

        transform.localEulerAngles = startRot + new Vector3(rotX, 0, rotY);
    }
}