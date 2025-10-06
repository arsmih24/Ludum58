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

        public void Awake()
        {
            _playerController = FindFirstObjectByType<PlayerController>();
            Debug.Log("Huy");
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
    }
}

