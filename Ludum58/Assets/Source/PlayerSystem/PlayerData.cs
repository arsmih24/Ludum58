using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field: SerializeField]
    public Rigidbody2D Rb { get; set; }

    [field: SerializeField]
    public Animator Anim { get; set; }

    [field: SerializeField]
    public float WalkSpeed { get; set; }

    [field: SerializeField]
    public float SprintSpeed { get; set; }

    [field: SerializeField]
    public float SprintDuration { get; set; }

    [field: SerializeField]
    public float SprintRecharge { get; set; }
}
