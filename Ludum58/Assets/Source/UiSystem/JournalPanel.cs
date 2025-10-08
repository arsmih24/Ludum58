using UnityEngine;
using UnityEngine.UI;

namespace UiSystem 
{
    public class JournalPanel : MonoBehaviour
    {
        [SerializeField] private Button itemsButton;
        [SerializeField] private Button notesButton;
        [SerializeField] private Button mapButton;
        [SerializeField] private Button closeButton;
        [Space]
        [SerializeField] private ItemsPage itemsPage;
        [SerializeField] private GameObject notesPage;
        [SerializeField] private GameObject mapPage;
        [Space]
        [SerializeField] private GameObject journalPanel;
        [Space]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioSource audioSourceClose;
        [SerializeField] private AudioClip journalOpenClip;
        [SerializeField] private AudioClip journalCloseClip;
        [SerializeField] private AudioClip pagesClip;

        private bool _isOpened = false;

        public bool IsJournalOpened => _isOpened;

        private void Awake()
        {
            itemsButton.onClick.AddListener(OpenItemsPage);
            notesButton.onClick.AddListener(OpenNotesPage);
            mapButton.onClick.AddListener(OpenMapPage);
            closeButton.onClick.AddListener(CloseJournal);
        }

        public void SetJournal()
        {
            if (!_isOpened)
                OpenJournal();

            else if (_isOpened)
                CloseJournal();
        }

        private void OpenJournal()
        {
            audioSource.PlayOneShot(journalOpenClip);

            journalPanel.SetActive(true);
            Time.timeScale = 0.0f;
            _isOpened = true;
        }

        private void CloseJournal()
        {
            audioSourceClose.PlayOneShot(journalCloseClip);

            journalPanel.SetActive(false);
            Time.timeScale = 1.0f;
            _isOpened = false;
        }

        private void OpenItemsPage() 
        {
            audioSource.PlayOneShot(pagesClip);

            itemsPage.gameObject.SetActive(true);
            notesPage.SetActive(false);
            mapPage.SetActive(false);
        }

        private void OpenNotesPage()
        {
            audioSource.PlayOneShot(pagesClip);

            itemsPage.gameObject.SetActive(false);
            notesPage.SetActive(true);
            mapPage.SetActive(false);
        }

        private void OpenMapPage()
        {
            audioSource.PlayOneShot(pagesClip);

            itemsPage.gameObject.SetActive(false);
            notesPage.SetActive(false);
            mapPage.SetActive(true);
        }

        private void OnDestroy()
        {
            itemsButton.onClick.RemoveAllListeners();
            notesButton.onClick.RemoveAllListeners();
            mapButton.onClick.RemoveAllListeners();
            closeButton.onClick.RemoveAllListeners();
        }
    }
}

