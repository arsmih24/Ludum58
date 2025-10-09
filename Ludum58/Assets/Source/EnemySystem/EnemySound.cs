using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemySound : MonoBehaviour
{
    [Header("Настройка звука")]
    [SerializeField] float maxDistance = 1f;   // внутри = 100 % громкости
    [SerializeField] float zeroDistance = 10f; // снаружи = 0 %

    [Header("Отрисовка gizmos")]
    [SerializeField] Color maxRadiusColor = new Color(1, 0, 0, 0.25f);
    [SerializeField] Color zeroRadiusColor = new Color(0, 1, 0, 0.15f);

    private Transform _player;
    private AudioSource _audioSource;
    private float _baseVolume;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _audioSource = GetComponent<AudioSource>();
        _baseVolume = _audioSource.volume;
        _audioSource.volume = 0f;
    }

    void Update()
    {
        float d = Vector2.Distance(transform.position, _player.position);
        float t = 1f - Mathf.InverseLerp(maxDistance, zeroDistance, d);
        _audioSource.volume = _baseVolume * Mathf.Clamp01(t);
    }

    void OnDrawGizmosSelected()
    {
        DrawCircles();
    }

    void OnDrawGizmos()
    {
        DrawCircles();
    }

    void DrawCircles()
    {
        Vector3 pos = transform.position;
        pos.z = 0f; 

        Gizmos.color = zeroRadiusColor;
        DrawCircle(pos, zeroDistance, 32);

        Gizmos.color = maxRadiusColor;
        DrawCircle(pos, maxDistance, 32);
    }

    static void DrawCircle(Vector3 center, float radius, int segments)
    {
        float angleStep = 2f * Mathf.PI / segments;
        Vector3 prev = center + new Vector3(radius, 0, 0);

        for (int i = 1; i <= segments; i++)
        {
            float angle = angleStep * i;
            Vector3 next = center + new Vector3(Mathf.Cos(angle) * radius,
                                                Mathf.Sin(angle) * radius, 0);
            Gizmos.DrawLine(prev, next);
            prev = next;
        }
    }
}