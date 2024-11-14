using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public List<GameObject> animalPrefabs;   // List of different animal prefabs
    public float spawnInterval = 10f;        // Time interval between spawns
    public int maxAnimals = 10;              // Maximum number of animals
    public float despawnInterval = 30f;      // Time before despawning animals

    private float spawnTimer = 0f;
    private List<GameObject> spawnedAnimals = new List<GameObject>(); // Track spawned animals
    private List<float> spawnTimes = new List<float>();  // Track spawn times for despawn tracking

    void Update()
    {
        spawnTimer += Time.deltaTime;

        // Spawn animals at a regular interval if there are fewer than maxAnimals
        if (spawnTimer >= spawnInterval && spawnedAnimals.Count < maxAnimals)
        {
            SpawnAnimal();
            spawnTimer = 0f;
        }

        // Despawn animals after a certain interval
        DespawnAnimals();
    }

    void SpawnAnimal()
    {
        // Find the player GameObject by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Player not found!");
            return;  // Exit if no player found
        }

        // Get a random position near the player and set it on the terrain height
        Vector3 spawnPosition = GetRandomPositionNearPlayer(player.transform.position);

        // Choose a random animal prefab from the list
        GameObject randomAnimalPrefab = animalPrefabs[Random.Range(0, animalPrefabs.Count)];

        // Instantiate the animal prefab at the random position
        GameObject newAnimal = Instantiate(randomAnimalPrefab, spawnPosition, Quaternion.identity, transform);

        // Add a Rigidbody and set gravity, if not already present, to ensure animals stay grounded
        Rigidbody rb = newAnimal.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = newAnimal.AddComponent<Rigidbody>();
            rb.useGravity = true; // Ensure gravity pulls the animal down to the terrain surface
        }

        // Track the newly spawned animal
        spawnedAnimals.Add(newAnimal);
        spawnTimes.Add(Time.time);

        // Log the animal count in the console
        Debug.Log("Animal spawned! Total animals: " + spawnedAnimals.Count);
    }

    void DespawnAnimals()
    {
        for (int i = spawnedAnimals.Count - 1; i >= 0; i--)
        {
            // Despawn an animal if its time has passed the despawn interval
            if (Time.time - spawnTimes[i] > despawnInterval)
            {
                Destroy(spawnedAnimals[i]);  // Destroy the animal object
                spawnedAnimals.RemoveAt(i);  // Remove it from the list
                spawnTimes.RemoveAt(i);      // Remove the corresponding spawn time

                // Log the updated animal count in the console
                Debug.Log("Animal despawned! Total animals: " + spawnedAnimals.Count);
                break;  // Only despawn one animal at a time
            }
        }
    }

    // Get a random position on the terrain near the player
    Vector3 GetRandomPositionNearPlayer(Vector3 playerPosition, float spawnRadius = 50f)
    {
        Terrain terrain = Terrain.activeTerrain;

        // Calculate a random position within the spawn radius around the player
        float x = Random.Range(playerPosition.x - spawnRadius, playerPosition.x + spawnRadius);
        float z = Random.Range(playerPosition.z - spawnRadius, playerPosition.z + spawnRadius);

        // Get the terrain height at the chosen (x, z) position
        float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrain.GetPosition().y;

        return new Vector3(x, y, z);
    }

}
