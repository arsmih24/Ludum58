using UnityEngine;
using UnityEngine.UI;
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

        private PlayerInventory _playerInventory;
        private LightController _lightController;

        public void Construct(PlayerInventory playerInventory, LightController lightController)
        {
            _playerInventory = playerInventory;
            _lightController = lightController;
        }

        private void Update()
        {
            battery.fillAmount = _lightController.Charge;
        }

        public void Pause() 
        {
            if (journalPanel.IsJournalOpened) return;
            pausePanel.SetPause();
        }

        public void Journal() 
        {
            journalPanel.SetJournal();
        }
    }
}

