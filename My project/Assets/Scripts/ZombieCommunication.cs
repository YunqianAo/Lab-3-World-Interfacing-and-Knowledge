using UnityEngine;

public class ZombieCommunication : MonoBehaviour
{
    // Este método es llamado cuando otro zombi ha detectado al jugador
    void PlayerDetected(Vector3 playerPosition)
    {
        Debug.Log("Player detectado por: " + gameObject.name);
        ZombieController controller = GetComponent<ZombieController>();
        controller.PlayerDetected(playerPosition);
    }

}
