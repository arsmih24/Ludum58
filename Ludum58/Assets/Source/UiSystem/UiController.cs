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

        private PlayerController _playerInventory;
        private LightController _lightController;

        public void Construct(PlayerController playerInventory, LightController lightController)
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
            pausePanel.SetPause();
        }

        public void Journal() 
        {
            if (pausePanel.IsPaused) return;
            journalPanel.SetJournal();
        }
    }
}

