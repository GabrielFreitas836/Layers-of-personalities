using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolling : MonoBehaviour
{
    public Transform[] patrolPoints;

    private int currentPointIndex = 0;

    [HideInInspector]
    public NavMeshAgent agent;

    public Enemy enemy;

    [HideInInspector]
    public Transform playerTransform;

    [HideInInspector]
    public Transform enemyTransform;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        enemyTransform = GetComponent<Transform>();
    }

    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(patrolPoints[currentPointIndex].position);
        agent.speed = enemy.data.enemySpeed;
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPointIndex].position);
            enemy.renderer.flipX = !enemy.renderer.flipX;
            
        }

        if (Mathf.Abs(playerTransform.position.x) - Mathf.Abs(enemyTransform.position.x) >= -enemy.data.rangeAttack &&
            -0.1f < Mathf.Abs(playerTransform.position.y) - Mathf.Abs(enemyTransform.position.y) &&
            Mathf.Abs(playerTransform.position.y) - Mathf.Abs(enemyTransform.position.y) <= 0.5f)
        {

            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
    }
}
