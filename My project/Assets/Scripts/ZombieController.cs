using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector3 targetPosition;
    private bool isChasing = false;
    private NavMeshAgent agent;
    
    //WANDER
    public float wanderRadius = 5f;
    public float changeInterval = 2f;

    private Vector3 wanderPosition;
    private float timer;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateTargetPosition();
        agent.speed = moveSpeed;
        timer = changeInterval;
    }

    public void PlayerDetected(Vector3 playerPosition)
    {
        isChasing = true;
        targetPosition = playerPosition;
        agent.SetDestination(targetPosition);
    }

    void Update()
    {
        if (isChasing)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {

            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                UpdateTargetPosition();
                timer = changeInterval;
            }

            transform.position = Vector3.MoveTowards(transform.position, wanderPosition, moveSpeed * Time.deltaTime);
        }
    }

    void UpdateTargetPosition()
    {
        float x = Random.Range(-wanderRadius, wanderRadius);
        float z = Random.Range(-wanderRadius, wanderRadius);
        wanderPosition = new Vector3(x, 0, z) + transform.position;
    }
}
