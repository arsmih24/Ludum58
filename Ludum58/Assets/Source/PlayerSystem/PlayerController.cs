using UiSystem;
using UnityEngine;

namespace PlayerSystem 
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject elevatorClosed;
        [SerializeField] private GameObject elevatorOpened;
        [Space]
        [SerializeField] private AudioSource collectAudioSource;
        [SerializeField] private AudioSource deathAudioSource;
        [SerializeField] private AudioClip collectClip;
        [SerializeField] private AudioClip deathClip;

        public bool HasEye { get; private set; } = false;
        public bool HasHand { get; private set; } = false;
        public bool HasGreenCard { get; private set; } = false;
        public bool HasPurpleCard { get; private set; } = false;
        public bool HasRedCard { get; private set; } = false;

        public bool HasTutorialNote { get; private set; } = true;
        public bool HasTimeToDieNote { get; private set; } = false;
        public bool HasPatientReportNote { get; private set; } = false;
        public bool HasSypNote { get; private set; } = false;
        public bool HasNoGodNote { get; private set; } = false;
        public bool HasTherapyNote { get; private set; } = false;
        public bool HasWhatTheyDidNote { get; private set; } = false;
        public bool HasContinueTestingNote { get; private set; } = false;

        private Collectable _collectable;
        private PlayerData _playerData;
        private UiController _uiController;
        private int _usefulCollectablesCount = 0;

        private const string _eyeTag = "Eye";
        private const string _handTag = "Hand";
        private const string _greenCardTag = "GreenCard";
        private const string _purpleCardTag = "PurpleCard";
        private const string _redCardTag = "RedCard";

        private const string _tutorialNote = "TutorialNote";
        private const string _timeToDieNote = "TimeToDieNote";
        private const string _patientReportNote = "PatientReportNote";
        private const string _sypNote = "SypNote";
        private const string _noGodNote = "NoGodNote";
        private const string _therapyNote = "TherapyNote";
        private const string _whatTheyDidNote = "WhatTheyDidNote";
        private const string _continueTestingNote = "ContinueTestingNote";

        private const string _elevatorTag = "Elevator";

        public void Construct(PlayerData playerData, UiController uiController) 
        {
            _playerData = playerData;
            _uiController = uiController;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Collectable col))
            {
                col.ShowCanvas();
                _collectable = col;
            }

            else if (collision.gameObject.CompareTag(_elevatorTag))
                EndGame();  
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Collectable col))
            {
                col.HideCanvas();
                _collectable = null;
            }
        }

        public void Collect() 
        {
            if (_collectable) 
            {
                collectAudioSource.PlayOneShot(collectClip);

                if (_collectable.gameObject.CompareTag(_eyeTag))
                {
                    HasEye = true;
                    _usefulCollectablesCount++;
                    CheckUsefulCollectables();
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowItemMessage();
                }

                else if (_collectable.gameObject.CompareTag(_handTag))
                {
                    HasHand = true;
                    _usefulCollectablesCount++;
                    CheckUsefulCollectables();
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowItemMessage();
                }

                else if (_collectable.gameObject.CompareTag(_greenCardTag))
                {
                    HasGreenCard = true;
                    _usefulCollectablesCount++;
                    CheckUsefulCollectables();
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowItemMessage();
                }

                else if (_collectable.gameObject.CompareTag(_purpleCardTag))
                {
                    HasPurpleCard = true;
                    _usefulCollectablesCount++;
                    CheckUsefulCollectables();
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowItemMessage();
                }

                else if (_collectable.gameObject.CompareTag(_redCardTag))
                {
                    HasRedCard = true;
                    _usefulCollectablesCount++;
                    CheckUsefulCollectables();
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowItemMessage();
                }

                else if (_collectable.gameObject.CompareTag(_tutorialNote)) 
                {
                    HasTutorialNote = true;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowNoteMessage();
                }

                else if (_collectable.gameObject.CompareTag(_timeToDieNote))
                {
                    HasTimeToDieNote = true;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowNoteMessage();
                }

                else if (_collectable.gameObject.CompareTag(_patientReportNote))
                {
                    HasPatientReportNote = true;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowNoteMessage();
                }

                else if (_collectable.gameObject.CompareTag(_sypNote))
                {
                    HasSypNote = true;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowNoteMessage();
                }

                else if (_collectable.gameObject.CompareTag(_noGodNote))
                {
                    HasNoGodNote = true;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowNoteMessage();
                }

                else if (_collectable.gameObject.CompareTag(_therapyNote))
                {
                    HasTherapyNote = true;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowNoteMessage();
                }

                else if (_collectable.gameObject.CompareTag(_whatTheyDidNote))
                {
                    HasWhatTheyDidNote = true;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowNoteMessage();
                }

                else if (_collectable.gameObject.CompareTag(_continueTestingNote))
                {
                    HasContinueTestingNote = true;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;

                    _uiController.ShowNoteMessage();
                }
            }
        }

        public void Death() 
        {
            _playerData.CanMove = false;
            deathAudioSource.PlayOneShot(deathClip);
            _uiController.ReloadGame();
        }

        private void EndGame()
        {
            _uiController.EndGame();
        }

        private void CheckUsefulCollectables() 
        {
            if (_usefulCollectablesCount == 5) 
            {
                elevatorClosed.SetActive(false);
                elevatorOpened.SetActive(true);
                _uiController.ShowCollectAllMessage();
            }
        }
    }
}

