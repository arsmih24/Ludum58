using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using PlayerSystem;
using LightSystem;

namespace UiSystem 
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private PausePanel pausePanel;
        [SerializeField] private JournalPanel journalPanel;
        [Space]
        [SerializeField] private Image battery;
        [Space]
        [SerializeField] private GameObject itemMessage;
        [SerializeField] private GameObject noteMessage;
        [SerializeField] private GameObject collectAllMessage;
        [SerializeField] private float messageDuration = 1.5f;
        [Space]
        [SerializeField] private Image loadPanel;
        [SerializeField] private float fadeDuration = 1f;

        private LightController _lightController;

        public void Construct(LightController lightController)
        {
            _lightController = lightController;
        }

        private void Awake()
        {
            loadPanel.gameObject.SetActive(true);
        }

        private void Start()
        {
            loadPanel.DOFade(0, fadeDuration);
        }

        private void Update()
        {
            battery.fillAmount = _lightController.Charge;
        }

        public void Pause() 
        {
            pausePanel.SetPause();
        }

        public void Journal() 
        {
            if (pausePanel.IsPaused) return;
            journalPanel.SetJournal();
            HideItemMessage();
            HideNoteMessage();
        }

        public void ShowItemMessage() 
        {
            itemMessage.SetActive(true);
            Invoke(nameof(HideItemMessage), messageDuration);
        }
        private void HideItemMessage() 
        {
            itemMessage.SetActive(false);
        }

        public void ShowNoteMessage()
        {
            noteMessage.SetActive(true);
            Invoke(nameof(HideNoteMessage), messageDuration);
        }
        private void HideNoteMessage()
        {
            noteMessage.SetActive(false);
        }

        public void ShowCollectAllMessage() 
        {
            collectAllMessage.SetActive(true);
        }

        public void ReloadGame() 
        {
            loadPanel.DOFade(1, fadeDuration).OnComplete(() =>
            {
                Level.ReloadLevel();
            });
        }

        public void EndGame()
        {
            loadPanel.DOFade(1, fadeDuration).OnComplete(() =>
            {
                Level.MainMenu();
            });
        }
    }
}

