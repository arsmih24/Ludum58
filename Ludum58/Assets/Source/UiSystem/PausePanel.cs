using UnityEngine;
using UnityEngine.UI;

namespace UiSystem 
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button mainMenuButton;
        [Space]
        [SerializeField] private GameObject panel;
        [Space]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip panelClip;
        [SerializeField] private AudioClip buttonClip;

        private bool _isPaused = false;

        public bool IsPaused => _isPaused;

        private void Awake()
        {
            resumeButton.onClick.AddListener(EndPause);
            mainMenuButton.onClick.AddListener(MainMenu);
        }

        public void SetPause()
        {
            if (!_isPaused)
                StartPause();

            else if (_isPaused)
                EndPause();
        }

        private void StartPause()
        {
            audioSource.PlayOneShot(panelClip);
            panel.SetActive(true);
            Time.timeScale = 0.0f;
            _isPaused = true;
        }

        private void EndPause()
        {
            audioSource.PlayOneShot(panelClip);
            panel.SetActive(false);
            Time.timeScale = 1.0f;
            _isPaused = false;
        }

        private void MainMenu()
        {
            audioSource.PlayOneShot(buttonClip);
            Level.MainMenu();
        }

        private void OnDestroy()
        {
            resumeButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.RemoveAllListeners();
        }
    }
}

