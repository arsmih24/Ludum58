using UnityEngine;
using UnityEngine.AI;
using PlayerSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [Header("Waypoints (циклический маршрут)")]
    [SerializeField] private Transform[] wayPoints;

    [Header("Параметры")]
    [SerializeField] private float chaseSpeed = 5f;
    [SerializeField] private float patrolSpeed = 3f;
    [SerializeField] private float arrivalDist = 0.35f;
    [SerializeField] private float flipSmooth = 0.15f;

    [SerializeField] private Collider2D uvCollider;

    private string uvTag = "Ultraviolet";
    private bool frozenByUV = false;

    private NavMeshAgent agent;
    private int currentWP = 0;
    private bool chasing = false;
    private Transform player;
    private float currentScaleX = 1f;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Start()
    {
        GameObject uvObj = GameObject.FindGameObjectWithTag(uvTag);
        uvCollider = uvObj?.GetComponent<Collider2D>();

        if (wayPoints.Length == 0)
        {
            enabled = false;
            return;
        }

        agent.speed = patrolSpeed;
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
                agent.isStopped = true;
            }
            else if (!intersects && frozenByUV)
            {
                frozenByUV = false;
                agent.isStopped = false;
            }
        }

        if (frozenByUV) return;

        if (chasing && player)       
        {
            agent.SetDestination(player.position);
        }
        else                      
        {
            if (!agent.pathPending && agent.remainingDistance < arrivalDist)
                AdvanceWaypoint();

            HandleSpriteFlip();
        }
    }

    private void GoToCurrentWaypoint()
    {
        agent.SetDestination(wayPoints[currentWP].position);
    }

    private void AdvanceWaypoint()
    {
        currentWP = (currentWP + 1) % wayPoints.Length;
        agent.SetDestination(wayPoints[currentWP].position);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(uvTag))
        {
            frozenByUV = true;
            agent.isStopped = true;
            return;
        }

        if (!chasing && col.CompareTag("Player")) 
        {
            player = col.transform;
            chasing = true;
            agent.speed = chaseSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(uvTag))
        {
            frozenByUV = false;
            agent.isStopped = false;
            return;
        }

        if (chasing && col.CompareTag("Player"))   
        {
            chasing = false;
            agent.speed = patrolSpeed;
            GoToCurrentWaypoint();          
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            Attack();
            //player.Death();
        }
    }

    private void Attack()
    {
        agent.isStopped = true;
        anim.SetTrigger("Attacking");
    }

    private void HandleSpriteFlip()
    {
        Vector3 vel = agent.velocity;
        if (vel.sqrMagnitude > 0.01f)
        {
            float targetScaleX = vel.x >= 0 ? 1f : -1f;
            currentScaleX = Mathf.Lerp(currentScaleX, targetScaleX, flipSmooth);
        }
        transform.localScale = new Vector3(currentScaleX, 1f, 1f);
    }

    private void OnDrawGizmos()
    {
        if (wayPoints == null || wayPoints.Length < 2) return;

        Gizmos.color = Color.cyan;
        for (int i = 0; i < wayPoints.Length; i++)
        {
            Vector3 a = wayPoints[i].position;
            Vector3 b = wayPoints[(i + 1) % wayPoints.Length].position;
            Gizmos.DrawLine(a, b);
            Gizmos.DrawWireSphere(a, 0.2f);
        }
    }
}