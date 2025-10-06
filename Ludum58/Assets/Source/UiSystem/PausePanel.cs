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

        private bool _isPaused = false;

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
            panel.SetActive(true);
            Time.timeScale = 0.0f;
            _isPaused = true;
        }

        private void EndPause()
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

