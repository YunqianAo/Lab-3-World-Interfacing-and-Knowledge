using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;  // Prefab del zombi que vas a instanciar
    public int numberOfZombies = 5;  // Número de zombis a generar
    public float spawnRadius = 5f;   // Radio alrededor del spawner donde los zombis aparecerán

    void Start()
    {
        SpawnZombies();
    }

    void SpawnZombies()
    {
        for (int i = 0; i < numberOfZombies; i++)
        {
            // Calculamos una posición aleatoria alrededor del spawner
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            randomPosition.y = transform.position.y;  // Mantener la altura del spawner

            // Instanciamos el prefab del zombi en la posición calculada
            Instantiate(zombiePrefab, randomPosition, Quaternion.identity);
        }
    }
}
