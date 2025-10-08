using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace LightSystem 
{
    public class LightController : MonoBehaviour
    {
        [SerializeField] private Light2D normalLight;
        [SerializeField] private Light2D uvLight;
        [Space]
        [SerializeField][Range(0.1f, 10f)] private float maxCharge = 5f;
        [SerializeField][Range(0.1f, 5f)] private float drainPerSec = 1f;
        [SerializeField][Range(0.01f, 2f)] private float rechargePerSec = 0.2f;
        [Space]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip uvOnClip;
        [SerializeField] private AudioClip uvOffClip;

        public float Charge => _currentCharge / maxCharge;

        private float _currentCharge;
        private bool _uvActive;

        private void Awake()
        {
            _currentCharge = maxCharge;
            SyncLights();
        }

        private void Update()
        {
            if (_uvActive)
            {
                _currentCharge -= drainPerSec * Time.deltaTime;
                if (_currentCharge <= 0f)
                {
                    _currentCharge = 0f;
                    DisableUV();
                }
            }
            else
            {
                _currentCharge = Mathf.MoveTowards(_currentCharge, maxCharge, rechargePerSec * Time.deltaTime);
            }
        }

        public void EnableUV()
        {
            if (Time.timeScale == 0.0f) return;
            if (_currentCharge <= 0f) return;
            audioSource.PlayOneShot(uvOnClip);
            _uvActive = true;
            SyncLights();
        }

        public void DisableUV()
        {
            if (Time.timeScale == 0.0f) return;
            if (!_uvActive) return;
            audioSource.PlayOneShot(uvOffClip);
            _uvActive = false;
            SyncLights();
        }

        private void SyncLights()
        {
            normalLight.gameObject.SetActive(!_uvActive);
            uvLight.gameObject.SetActive(_uvActive);
        }
    }
}
