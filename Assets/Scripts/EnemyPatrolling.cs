using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolling : MonoBehaviour
{
    public Transform[] patrolPoints;

    private int currentPointIndex = 0;
    private NavMeshAgent agent;

    public Enemy enemy;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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
        }
    }
}
