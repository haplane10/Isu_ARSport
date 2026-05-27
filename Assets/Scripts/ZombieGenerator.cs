using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public float spawnInterval = 5f; // Time interval between spawns
    public GameObject zombiePrefab; // Prefab of the zombie to spawn
    public float distance; // Distance from the player to spawn zombies
    public int maxZombies = 10; // Maximum number of zombies to spawn
    public Transform player; // Reference to the player's transform

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0f)
        {
            SpawnZombie();
            spawnInterval = 5f; // Reset the spawn interval
        }
    }

    public void SpawnZombie()
    {
        if (GameObject.FindGameObjectsWithTag("Zombie").Length < maxZombies)
        {
            Vector3 spawnPosition = player.position + Random.onUnitSphere * distance;
            spawnPosition.y = 0; // Keep zombies on the ground
            Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
