using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace LightSystem 
{
    [RequireComponent(typeof(Light2D))]
    public class LightFlicker : MonoBehaviour
    {
        [SerializeField] private float baseIntensity = 1.2f;
        [Space]
        [SerializeField][Range(0f, 1f)] private float flickerAmplitude = 0.5f;
        [SerializeField] private float minInterval = 0.5f;
        [SerializeField] private float maxInterval = 3f;

        private Light2D light2d;
        private float nextFlickerTime;
        private bool isFlicker;

        private void Awake()
        {
            light2d = GetComponent<Light2D>();
            light2d.intensity = baseIntensity;
            ScheduleNext();
        }

        private void Update()
        {
            if (Time.time >= nextFlickerTime)
            {
                if (isFlicker)
                {
                    light2d.intensity = baseIntensity;
                    isFlicker = false;
                    ScheduleNext();
                }
                else     
                {
                    float randomDepth = Random.Range(0.7f, 1f); // 0.7..1.0 от amplitude
                    light2d.intensity = baseIntensity * (1f - flickerAmplitude * randomDepth);
                    isFlicker = true;
                    nextFlickerTime = Time.time + Random.Range(0.03f, 0.08f); // короткий «щелчок»
                }
            }
        }

        private void ScheduleNext()
        {
            nextFlickerTime = Time.time + Random.Range(minInterval, maxInterval);
        }
    }
}
