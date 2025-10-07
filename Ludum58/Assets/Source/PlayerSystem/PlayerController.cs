using UnityEngine;

namespace PlayerSystem 
{
    public class PlayerController : MonoBehaviour
    {
        public bool HasEye { get; private set; } = false;
        public bool HasHand { get; private set; } = false;
        public bool HasGreenCard { get; private set; } = false;
        public bool HasPurpleCard { get; private set; } = false;
        public bool HasRedCard { get; private set; } = false;

        private Collectable _collectable;
        private PlayerData _playerData;
        private int _usefulCollectablesCount = 0;

        private const string _eyeTag = "Eye";
        private const string _handTag = "Hand";
        private const string _greenCardTag = "GreenCard";
        private const string _purpleCardTag = "PurpleCard";
        private const string _redCardTag = "RedCard";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Collectable col)) 
            {
                col.ShowCanvas();
                _collectable = col;
            }
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
                if (_collectable.gameObject.CompareTag(_eyeTag)) 
                {
                    HasEye = true;
                    _usefulCollectablesCount++;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;
                }

                else if (_collectable.gameObject.CompareTag(_handTag))
                {
                    HasHand = true;
                    _usefulCollectablesCount++;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;
                }

                else if (_collectable.gameObject.CompareTag(_greenCardTag))
                {
                    HasGreenCard = true;
                    _usefulCollectablesCount++;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;
                }

                else if (_collectable.gameObject.CompareTag(_purpleCardTag))
                {
                    HasPurpleCard = true;
                    _usefulCollectablesCount++;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;
                }

                else if (_collectable.gameObject.CompareTag(_redCardTag))
                {
                    HasRedCard = true;
                    _usefulCollectablesCount++;
                    _collectable.gameObject.SetActive(false);
                    _collectable = null;
                }
            }
        }

        public void Death() 
        {
            _playerData.CanMove = false;
        }
    }
}

