using UnityEngine;
using UnityEngine.UI;
using PlayerSystem;

namespace UiSystem 
{
    public class ItemsPage : MonoBehaviour
    {
        private PlayerController _playerController;
            
        [SerializeField] private Button eyeButton;
        [SerializeField] private Button handButton;
        [SerializeField] private Button greenCardButton;
        [SerializeField] private Button purpleCardButton;
        [SerializeField] private Button redCardButton;
        [Space]
        [SerializeField] private GameObject eyePanel;
        [SerializeField] private GameObject handPanel;
        [SerializeField] private GameObject greenCardPanel;
        [SerializeField] private GameObject purpleCardPanel;
        [SerializeField] private GameObject redCardPanel;
        [Space]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip buttonClip;

        private GameObject _previousPanel;

        public void Awake()
        {
            _playerController = FindFirstObjectByType<PlayerController>();

            eyeButton.onClick.AddListener(EyeButton);
            handButton.onClick.AddListener(HandButton);
            greenCardButton.onClick.AddListener(GreenCardButton);
            purpleCardButton.onClick.AddListener (PurpleCardButton);
            redCardButton.onClick.AddListener(RedCardButton);
        }

        private void OnEnable()
        {
            UpdateButtons();
        }

        public void UpdateButtons() 
        {
            if (_playerController.HasEye) 
                eyeButton.gameObject.SetActive(true);

            if (_playerController.HasHand)
                handButton.gameObject.SetActive(true);

            if (_playerController.HasGreenCard)
                greenCardButton.gameObject.SetActive(true);

            if (_playerController.HasPurpleCard)
                purpleCardButton.gameObject.SetActive(true);

            if (_playerController.HasRedCard)
                redCardButton.gameObject.SetActive(true);
        }

        private void DisablePanels()
        {
            if (_previousPanel)
            {
                _previousPanel.SetActive(false);
                _previousPanel = null;
            }
        }

        private void EyeButton()
        {
            audioSource.PlayOneShot(buttonClip);

            if (_previousPanel)
                _previousPanel.SetActive(false);
            eyePanel.SetActive(true);
            _previousPanel = eyePanel;
        }

        private void HandButton()
        {
            audioSource.PlayOneShot(buttonClip);

            if (_previousPanel)
                _previousPanel.SetActive(false);
            handPanel.SetActive(true);
            _previousPanel = handPanel;
        }

        private void GreenCardButton()
        {
            audioSource.PlayOneShot(buttonClip);

            if (_previousPanel)
                _previousPanel.SetActive(false);
            greenCardPanel.SetActive(true);
            _previousPanel = greenCardPanel;
        }

        private void PurpleCardButton()
        {
            audioSource.PlayOneShot(buttonClip);

            if (_previousPanel)
                _previousPanel.SetActive(false);
            purpleCardPanel.SetActive(true);
            _previousPanel = purpleCardPanel;
        }

        private void RedCardButton()
        {
            audioSource.PlayOneShot(buttonClip);

            if (_previousPanel)
                _previousPanel.SetActive(false);
            redCardPanel.SetActive(true);
            _previousPanel = redCardPanel;
        }

        private void OnDisable()
        {
            DisablePanels();
        }
    }
}

