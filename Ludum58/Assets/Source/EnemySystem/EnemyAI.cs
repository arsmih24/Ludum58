using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject[] _wayPoints;

    [Header("Параметры")]
    [SerializeField] private float chaseSpeed = 5f;
    [SerializeField] private float patrolSpeed = 3f;
    [SerializeField] private float arrivalDist = 0.35f;   
    [SerializeField] private float flipSmooth = 0.15f;

    [Header("Ультрафиолет")]
    [SerializeField] private Collider2D uvCollider;
    private string _uvTag = "Ultraviolet";
    private bool frozenByUV = false;

    private NavMeshAgent _agent;
    private int _currentWP = 0;
    private bool _chasing = false;
    private Transform _player;
    private float _currentScaleX = 1f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Start()
    {
        GameObject uvObj = GameObject.FindGameObjectWithTag(_uvTag);
        uvCollider = uvObj?.GetComponent<Collider2D>();

        if (_wayPoints.Length == 0)
        {
            Debug.LogWarning("Waypoints не заданы!", this);
            enabled = false;
            return;
        }

        _agent.speed = patrolSpeed;
        GoToCurrentWaypoint();
    }

    private void Update()
    {
        if (uvCollider != null)
        {
            bool intersects = GetComponent<Collider2D>().IsTouching(uvCollider);
            if (intersects && !frozenByUV)
            {
                frozenByUV = true;
                _agent.isStopped = true;
            }
            else if (!intersects && frozenByUV)
            {
                frozenByUV = false;
                _agent.isStopped = false;
            }
        }

        if (frozenByUV) return;
        if (_chasing && _player)
            _agent.SetDestination(_player.position);
        else
        {
            if (!_agent.pathPending && _agent.remainingDistance < arrivalDist)
                AdvanceWaypoint();
        }

        HandleFacingDirection();
    }

    private void GoToCurrentWaypoint()
    {
        _agent.SetDestination(_wayPoints[_currentWP].transform.position);
    }

    private void AdvanceWaypoint()
    {
        _currentWP = (_currentWP + 1) % _wayPoints.Length;
        _agent.SetDestination(_wayPoints[_currentWP].transform.position);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!_chasing && col.CompareTag("Player"))
        {
            _player = col.transform;
            _chasing = true;
            _agent.speed = chaseSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (_chasing && col.CompareTag("Player"))
        {
            _chasing = false;
            _agent.speed = patrolSpeed;
            GoToCurrentWaypoint();
        }
    }

    /*private void OnCollisionEnter(Collision2D col)
    {
        if (col.CompareTag(_uvTag))
        {
            frozenByUV = true;
            _agent.isStopped = true;
            return;
        }
    }

    private void OnCollisionExit(Collision2D col)
    {
        if (col.CompareTag(_uvTag))
        {
            frozenByUV = false;
            _agent.isStopped = false;
            return;
        }
    }*/

    private void HandleFacingDirection()
    {
        Vector2 dir = _agent.velocity.normalized;
        if (dir.sqrMagnitude > 0.01f)
            transform.right = dir;
    }

    private void OnDrawGizmos()
    {
        if (_wayPoints == null || _wayPoints.Length < 2) return;

        Gizmos.color = Color.cyan;
        for (int i = 0; i < _wayPoints.Length; i++)
        {
            Vector3 a = _wayPoints[i].transform.position;
            Vector3 b = _wayPoints[(i + 1) % _wayPoints.Length].transform.position;
            Gizmos.DrawLine(a, b);
            Gizmos.DrawWireSphere(a, 0.2f);
        }
    }
}