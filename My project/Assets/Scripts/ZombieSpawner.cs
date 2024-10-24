using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;  // Prefab del zombi que vas a instanciar
    public int numberOfZombies = 5;  // N�mero de zombis a generar
    public float spawnRadius = 5f;   // Radio alrededor del spawner donde los zombis aparecer�n

    void Start()
    {
        SpawnZombies();
    }

    void SpawnZombies()
    {
        for (int i = 0; i < numberOfZombies; i++)
        {
            // Calculamos una posici�n aleatoria alrededor del spawner
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            randomPosition.y = transform.position.y;  // Mantener la altura del spawner

            // Instanciamos el prefab del zombi en la posici�n calculada
            Instantiate(zombiePrefab, randomPosition, Quaternion.identity);
        }
    }
}
