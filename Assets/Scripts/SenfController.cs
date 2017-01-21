using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenfController : MonoBehaviour
{
    public static SenfController e;
    void Awake() { e = this; }

    public Transform bottle;
    public Transform bottleChild;

    public ParticleSystem senfticles;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public float maxRate = 100;

    public float idleFrequency = 1;
    public float idleScale = 1;

    public float squeezeFrequency = 10;
    public float squeezeScale = 1;

    float squeezeGain;

    public AnimationCurve squeezeCurve;

    float refVelo;
    float squeeze;



    void Update()
    {
        ParticleSystem.EmissionModule emission = senfticles.emission;

        float rate = 0;

        if (Input.GetMouseButton(0))
        {
            squeezeGain += Time.deltaTime;

            squeezeGain = Mathf.Clamp01(squeezeGain);

            rate = 100;
        }
        else squeezeGain = 0;

        Vector3 pos = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));

        bottle.transform.position += pos * 0.2f;

        emission.rateOverTime = new ParticleSystem.MinMaxCurve(rate);

        float idleNoiseX = Mathf.PerlinNoise(idleFrequency * Time.time, 345.4f) * idleScale;
        float idleNoiseY = Mathf.PerlinNoise(idleFrequency * Time.time, 34.45f) * idleScale;

        float noiseX = Mathf.PerlinNoise(squeezeFrequency * Time.time, 345.4f) * squeezeScale;
        float noiseY = Mathf.PerlinNoise(squeezeFrequency * Time.time, 34.45f) * squeezeScale;

        Vector3 noiseIdle = new Vector3(idleNoiseX, 0, idleNoiseY);

        Vector3 noiseV = new Vector3(noiseX, 0, noiseY);

        squeeze = Mathf.SmoothDamp(squeeze, squeezeGain, ref refVelo, 0.1f);

        Vector3 squeezeV = noiseV;
        squeezeV.y = -squeezeCurve.Evaluate(squeeze);

        bottleChild.transform.localPosition = noiseIdle + squeezeV * squeezeCurve.Evaluate(squeeze);
    }
}