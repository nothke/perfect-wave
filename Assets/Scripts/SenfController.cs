using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenfController : MonoBehaviour
{

    public Transform bottle;

    public ParticleSystem senfticles;

    void Start()
    {

    }

    void Update()
    {
        ParticleSystem.EmissionModule emission = senfticles.emission;

        float rate = 0;

        if (Input.GetMouseButton(0))
            rate = 50;

        Vector3 pos = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));

        bottle.transform.position += pos * 1;

        emission.rateOverTime = new ParticleSystem.MinMaxCurve(rate);
    }
}