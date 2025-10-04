using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field: SerializeField]
    public Rigidbody2D Rb { get; set; }

    [field: SerializeField]
    public float Speed { get; set; }
}
