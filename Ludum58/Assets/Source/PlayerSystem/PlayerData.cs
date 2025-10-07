using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field: SerializeField]
    public Rigidbody2D Rb { get; private set; }

    [field: SerializeField]
    public SpriteRenderer Sr { get; private set; }

    [field: SerializeField]
    public Animator Anim { get; private set; }

    [field: SerializeField]
    public float WalkSpeed { get; private set; }

    [field: SerializeField]
    public float SprintSpeed { get; private set; }

    [field: SerializeField]
    public float SprintDuration { get; private set; }

    [field: SerializeField]
    public float SprintRecharge { get; private set; }

    [field: SerializeField]
    public bool CanMove { get; set; }
}
