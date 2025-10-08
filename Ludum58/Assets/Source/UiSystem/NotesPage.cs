using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UiSystem 
{
    public class NotesPage : MonoBehaviour
    {
        private PlayerController _playerController;

        [SerializeField] private Button tutorialButton;
        [SerializeField] private Button timeToDieButton;
        [SerializeField] private Button patientReportButton;
        [SerializeField] private Button sypButton;
        [SerializeField] private Button noGodButton;
        [SerializeField] private Button therapyButton;
        [SerializeField] private Button whatTheyDidButton;
        [SerializeField] private Button continueTestingButton;
        [Space]
        [SerializeField] private GameObject tutorialPanel;
        [SerializeField] private GameObject timeToDiePanel;
        [SerializeField] private GameObject patientReportPanel;
        [SerializeField] private GameObject sypPanel;
        [SerializeField] private GameObject noGodPanel;
        [SerializeField] private GameObject therapyPanel;
        [SerializeField] private GameObject whatTheyDidPanel;
        [SerializeField] private GameObject continueTestingPanel;

        private GameObject _previousPanel;

        public void Awake()
        {
            _playerController = FindFirstObjectByType<PlayerController>();

            tutorialButton.onClick.AddListener(TutorialButton);
            timeToDieButton.onClick.AddListener(TimeToDieButton);
            patientReportButton.onClick.AddListener(PatientReportButton);
            sypButton.onClick.AddListener(SypButton);
            noGodButton.onClick.AddListener(NoGodButton);
            therapyButton.onClick.AddListener(TherapyButton);
            whatTheyDidButton.onClick.AddListener(WhatTheyDidButton);
            continueTestingButton.onClick.AddListener(ContinueTestingButton);
        }

        private void OnEnable()
        {
            UpdateButtons();
        }

        public void UpdateButtons() 
        {
            if (_playerController.HasTutorialNote)
                tutorialButton.gameObject.SetActive(true);

            if (_playerController.HasTimeToDieNote)
                timeToDieButton.gameObject.SetActive(true);

            if (_playerController.HasPatientReportNote)
                patientReportButton.gameObject.SetActive(true);

            if (_playerController.HasSypNote)
                sypButton.gameObject.SetActive(true);

            if (_playerController.HasNoGodNote)
                noGodButton.gameObject.SetActive(true);

            if (_playerController.HasTherapyNote)
                therapyButton.gameObject.SetActive(true);

            if (_playerController.HasWhatTheyDidNote)
                whatTheyDidButton.gameObject.SetActive(true);

            if (_playerController.HasContinueTestingNote)
                continueTestingButton.gameObject.SetActive(true);
        }

        private void DisablePanels() 
        {
            if (_previousPanel) 
            {
                _previousPanel.SetActive(false);
                _previousPanel = null;
            }
        }

        private void TutorialButton() 
        {
            if (_previousPanel)
                _previousPanel.SetActive(false);
            tutorialPanel.SetActive(true);
            _previousPanel = tutorialPanel;
        }

        private void TimeToDieButton()
        {
            if (_previousPanel)
                _previousPanel.SetActive(false);
            timeToDiePanel.SetActive(true);
            _previousPanel = timeToDiePanel;
        }

        private void PatientReportButton()
        {
            if (_previousPanel)
                _previousPanel.SetActive(false);
            patientReportPanel.SetActive(true);
            _previousPanel = patientReportPanel;
        }

        private void SypButton()
        {
            if (_previousPanel)
                _previousPanel.SetActive(false);
            sypPanel.SetActive(true);
            _previousPanel = sypPanel;
        }

        private void NoGodButton()
        {
            if (_previousPanel)
                _previousPanel.SetActive(false);
            noGodPanel.SetActive(true);
            _previousPanel = noGodPanel;
        }

        private void TherapyButton()
        {
            if (_previousPanel)
                _previousPanel.SetActive(false);
            therapyPanel.SetActive(true);
            _previousPanel = therapyPanel;
        }

        private void WhatTheyDidButton()
        {
            if (_previousPanel)
                _previousPanel.SetActive(false);
            whatTheyDidPanel.SetActive(true);
            _previousPanel = whatTheyDidPanel;
        }

        private void ContinueTestingButton()
        {
            if (_previousPanel)
                _previousPanel.SetActive(false);
            continueTestingPanel.SetActive(true);
            _previousPanel = continueTestingPanel;
        }

        private void OnDisable()
        {
            DisablePanels();
        }
    }
}

