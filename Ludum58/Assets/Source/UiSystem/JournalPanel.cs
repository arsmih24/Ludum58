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
        [SerializeField] private GameObject journalPanel;

        private bool _isOpened = false;

        public bool IsJournalOpened => _isOpened;

        private void Awake()
        {
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
            journalPanel.SetActive(true);
            Time.timeScale = 0.0f;
            _isOpened = true;
        }

        private void CloseJournal()
        {
            journalPanel.SetActive(false);
            Time.timeScale = 1.0f;
            _isOpened = false;
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

