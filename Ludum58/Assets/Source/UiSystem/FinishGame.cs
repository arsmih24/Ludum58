using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UiSystem 
{
    public class FinishGame : MonoBehaviour
    {
        [SerializeField] private Button mainMenuButton;
        [Space]
        [SerializeField] private Image loadPanel;
        [SerializeField] private float fadeDuration;
        [Space]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip elevatorClip;
        [SerializeField] private AudioClip elevatorSampleClip;

        private void Awake()
        {
            loadPanel.gameObject.SetActive(true);
            mainMenuButton.onClick.AddListener(Menu);
        }

        private void Start()
        {
            loadPanel.DOFade(0, fadeDuration);
            audioSource.PlayOneShot(elevatorClip);
            Invoke(nameof(PlayElevatorSample), 23f);
        }

        private void PlayElevatorSample() 
        {
            audioSource.PlayOneShot(elevatorSampleClip);
            audioSource.volume -= 0.1f;
        }

        private void Menu() 
        {
            Level.MainMenu();
        }

        private void OnDestroy()
        {
            mainMenuButton.onClick.RemoveAllListeners();
        }
    }
}
