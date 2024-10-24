using UnityEngine;

public class ZombiePerception : MonoBehaviour
{
    public float viewDistance = 10f;
    public float fieldOfView = 60f;
    public float rotationSpeed = 100f;

    private ZombieController zombieController;
    private Transform target;

    void Start()
    {
        zombieController = GetComponent<ZombieController>();
    }

    void Update()
    {
        if (ClickToMove.instance != null)
        {
            DetectPlayer(ClickToMove.instance.gameObject);
            RotateTowardsPlayer();
        }
    }

    void DetectPlayer(GameObject player)
    {
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        float angleBetweenZombieAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        if (angleBetweenZombieAndPlayer < fieldOfView / 2 && distanceToPlayer < viewDistance)
        {
            zombieController.PlayerDetected(player.transform.position);
            target = player.transform;

            Collider[] nearbyZombies = Physics.OverlapSphere(transform.position, 5f);
            foreach (var hitCollider in nearbyZombies)
            {
                if (hitCollider.gameObject.CompareTag("Zombie") && hitCollider.gameObject != gameObject)
                {
                    hitCollider.gameObject.SendMessage("PlayerDetected", player.transform.position, SendMessageOptions.DontRequireReceiver);

                }
            }
        }
    }

    void RotateTowardsPlayer()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // Dibujar el frustum del campo de visión
        Vector3 leftBoundary = Quaternion.Euler(0, -fieldOfView / 2, 0) * transform.forward * viewDistance;
        Vector3 rightBoundary = Quaternion.Euler(0, fieldOfView / 2, 0) * transform.forward * viewDistance;

        Gizmos.DrawRay(transform.position, leftBoundary);
        Gizmos.DrawRay(transform.position, rightBoundary);
        Gizmos.DrawWireSphere(transform.position + transform.forward * viewDistance, 0.2f);

        // Dibujar una esfera para representar el rango de alerta entre zombis
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 5f); // Rango de comunicación entre zombies
    }
}
