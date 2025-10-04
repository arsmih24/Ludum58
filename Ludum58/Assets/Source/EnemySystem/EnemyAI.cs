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

    

    private NavMeshAgent agent;
    private int currentWP = 0;
    private bool chasing = false;
    private Transform player;
    private float currentScaleX = 1f;

    //private const string _wayPointsTag = "WayPoint";

    private void Awake()
    {
        //_wayPoints = GameObject.FindGameObjectsWithTag(_wayPointsTag);
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Start()
    {
        if (_wayPoints.Length == 0)
        {
            Debug.LogWarning("Waypoints не заданы!", this);
            enabled = false;
            return;
        }

        agent.speed = patrolSpeed;
        GoToCurrentWaypoint();
    }

    private void Update()
    {
        if (chasing && player)
            agent.SetDestination(player.position);
        else
        {
            if (!agent.pathPending && agent.remainingDistance < arrivalDist)
                AdvanceWaypoint();
        }

        HandleFacingDirection();
    }

    private void GoToCurrentWaypoint()
    {
        agent.SetDestination(_wayPoints[currentWP].transform.position);
    }

    private void AdvanceWaypoint()
    {
        currentWP = (currentWP + 1) % _wayPoints.Length;
        agent.SetDestination(_wayPoints[currentWP].transform.position);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!chasing && col.CompareTag("Player"))
        {
            player = col.transform;
            chasing = true;
            agent.speed = chaseSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (chasing && col.CompareTag("Player"))
        {
            chasing = false;
            agent.speed = patrolSpeed;

            GoToCurrentWaypoint();
        }
    }

    private void HandleFacingDirection()
    {
        Vector2 dir = agent.velocity.normalized;
        if (dir.sqrMagnitude > 0.01f)
            transform.right = dir;   // "лицо" спрайта должно быть направлено вдоль оси X
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