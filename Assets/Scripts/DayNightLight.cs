using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class DayNightLighting : MonoBehaviour
{
    private Light2D globalLight;
    [SerializeField] private float dayIntensity = 2f;
    [SerializeField] private float nightIntensity = 0.15f;
    [SerializeField] private float transitionDuration = 10f;
    [SerializeField] private float dayDuration = 5f;
    [SerializeField] private float nightDuration = 5f;
    [SerializeField] private Color dayColor = new Color(1f, 0.95f, 0.85f, 1f);
    [SerializeField] private Color nightColor = new Color(0.35f, 0.42f, 0.55f, 1f);

    [SerializeField] private LightingPhase[] phases =
    {
        new LightingPhase
        {
            phase = DayPhase.Night,
            intensity = 0.15f,
            color = new Color(0.35f, 0.42f, 0.55f, 1f),
            holdDuration = 5f,
            transitionDurationToNext = 5f
        },

        new LightingPhase
        {
            phase = DayPhase.Dawn,
            intensity = 0.6f,
            color = new Color(1f, 0.55f, 0.35f, 1f),
            holdDuration = 3f,
            transitionDurationToNext = 5f
        },

        new LightingPhase
        {
            phase = DayPhase.Day,
            intensity = 2f,
            color = new Color(1f, 0.95f, 0.85f, 1f),
            holdDuration = 5f,
            transitionDurationToNext = 5f
        },

        new LightingPhase
        {
            phase = DayPhase.Dusk,
            intensity = 0.8f,
            color = new Color(0.9f, 0.4f, 0.2f, 1f),
            holdDuration = 3f,
            transitionDurationToNext = 5f
        }
    };

    void Awake()
    {
        globalLight = GetComponent<Light2D>();
    }

    void Start()
    {

        globalLight.intensity = phases[0].intensity;
        globalLight.color = phases[0].color;
        StartCoroutine(DayNightCycle());
    }

    IEnumerator DayNightCycle()
    {
        while (true)
        {
            for (int i = 0; i < phases.Length; i++)
            {
                LightingPhase currPhase = phases[i];
                LightingPhase nextPhase = phases[(i + 1) % phases.Length];
                globalLight.intensity = currPhase.intensity;
                globalLight.color = currPhase.color;
                yield return new WaitForSeconds(currPhase.holdDuration);
                yield return StartCoroutine(
                    TransitionCycle(
                        currPhase.intensity,
                        nextPhase.intensity,
                        currPhase.color,
                        nextPhase.color,
                        currPhase.transitionDurationToNext
                    )
                );
            }
        }
    }

    IEnumerator TransitionCycle(float startIntensity, float endIntensity, Color startColor, Color endColor, float transitionDuration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;

            globalLight.intensity = Mathf.Lerp(startIntensity, endIntensity, t);
            globalLight.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }
        globalLight.intensity = endIntensity;
        globalLight.color = endColor;
    }

    [System.Serializable]
    public struct LightingPhase
    {
        public DayPhase phase;
        public float intensity;
        public Color color;
        public float holdDuration;
        public float transitionDurationToNext;
    }
    
    public enum DayPhase
    {
        Night,
        Dawn,
        Day,
        Dusk
    }

}
