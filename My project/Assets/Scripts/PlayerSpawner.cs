using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;  // Prefab del jugador

    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        // Instanciamos el jugador en la posición del spawner
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
