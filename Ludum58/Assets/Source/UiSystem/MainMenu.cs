using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UiSystem 
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Image loadPanel;
        [SerializeField] private float fadeDuration = 1.5f;
        [Space]
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitButton;
        [Space]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip buttonClip;

        private void Awake()
        {
            playButton.onClick.AddListener(NextLevel);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void NextLevel() 
        {
            audioSource.PlayOneShot(buttonClip);

            loadPanel.DOFade(1, fadeDuration).OnComplete(() =>
            {
                Level.LoadNextLevel();
            });
        }

        private void ExitGame() 
        {
            audioSource.PlayOneShot(buttonClip);

            Application.Quit();
        }

        private void OnDestroy()
        {
            playButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();
        }
    }
}

