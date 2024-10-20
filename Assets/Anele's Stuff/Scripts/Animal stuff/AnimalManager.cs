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
        // Choose a random animal prefab from the list
        GameObject randomAnimalPrefab = animalPrefabs[Random.Range(0, animalPrefabs.Count)];

        // Choose a random position on the terrain to spawn the animal
        Vector3 spawnPosition = GetRandomPositionOnTerrain();

        // Instantiate the animal prefab at the random position
        GameObject newAnimal = Instantiate(randomAnimalPrefab, spawnPosition, Quaternion.identity, transform);

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

    // Get a random position on the terrain
    Vector3 GetRandomPositionOnTerrain()
    {
        Terrain terrain = Terrain.activeTerrain;
        float x = Random.Range(terrain.transform.position.x, terrain.transform.position.x + terrain.terrainData.size.x);
        float z = Random.Range(terrain.transform.position.z, terrain.transform.position.z + terrain.terrainData.size.z);
        float y = terrain.SampleHeight(new Vector3(x, 0, z));
        return new Vector3(x, y, z);
    }


}
