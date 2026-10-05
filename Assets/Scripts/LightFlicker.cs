using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
    private Light2D lightObj;
    [SerializeField] private float flickerSpeed = 1f;
    [SerializeField] private float minIntensity = 0.5f;
    [SerializeField] private float maxIntensity = 1f;
    [SerializeField] private float minRadius = 0.7f;
    [SerializeField] private float maxRadius = 1f;
    private float noiseOffset;


    void Awake()
    {
        lightObj = GetComponent<Light2D>();
        noiseOffset = Random.Range(0f, 100f); // Give each light a different position in the Perlin noise field,
        // otherwise identical lights would sample the same noise values
        // at the same time and flicker in sync.
    }
    void Update()
    {
        float intensityNoise = Mathf.PerlinNoise(Time.time * flickerSpeed + noiseOffset, 0f);
        float radiusNoise = Mathf.PerlinNoise(Time.time * flickerSpeed + noiseOffset, 10f);
        lightObj.intensity = Mathf.Lerp(minIntensity, maxIntensity, intensityNoise);
        lightObj.pointLightOuterRadius = Mathf.Lerp(minRadius, maxRadius, radiusNoise);
    }
}
