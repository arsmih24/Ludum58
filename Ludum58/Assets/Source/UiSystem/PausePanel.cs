using UnityEngine;
using UnityEngine.UI;

namespace UiSystem 
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private GameObject panel;

        private bool _isPaused = false;

        private void Awake()
        {
            resumeButton.onClick.AddListener(ResetPause);
            mainMenuButton.onClick.AddListener(MainMenu);
        }

        public void Pause()
        {
            if (!_isPaused)
                SetPause();

            else if (_isPaused)
                ResetPause();
        }

        private void SetPause()
        {
            panel.SetActive(true);
            Time.timeScale = 0.0f;
            _isPaused = true;
        }

        private void ResetPause()
        {
            panel.SetActive(false);
            Time.timeScale = 1.0f;
            _isPaused = false;
        }

        private void MainMenu()
        {
            Level.MainMenu();
        }

        private void OnDestroy()
        {
            resumeButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.RemoveAllListeners();
        }
    }
}

