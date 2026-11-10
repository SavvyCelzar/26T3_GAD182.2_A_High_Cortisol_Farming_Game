using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class AnimalSpawners : Timer
{
    private Transform spawnPoint;
    [SerializeField] private GameObject[] allAnimalTypes; // Assign animal types in Unity Inspector
    private List<GameObject> animalsInScene = new List<GameObject>();

    private float currentSpawnRate;
   [SerializeField] private float startingSpawnRate = 3f;
    private float minimumSpawnRate = 0.5f;

    private float increaseSpawnRateBy = 0.5f; 
    private float secondsToSpawnIncrease = 20f;

    private float spawnerTimer;
    private float spawnRateTimer;

    protected override void Start()
    {
        base.Start();

        GameObject spawner = GameObject.Find("AnimalSpawner");
        if(spawner != null)
        {
            spawnPoint = spawner.transform;
        }

        currentSpawnRate = startingSpawnRate;       
    }

    // Update is called once per frame
    void Update()
    {
        spawnRateTimer += Time.deltaTime;

        if (spawnRateTimer >= secondsToSpawnIncrease)
        {
            currentSpawnRate -= increaseSpawnRateBy;
            currentSpawnRate = Mathf.Max(currentSpawnRate, minimumSpawnRate);

            spawnRateTimer = 0f;
            Debug.Log("20 seconds passed, new spawn rate is now " + currentSpawnRate + " seconds.");
        }

        spawnerTimer += Time.deltaTime;

        if (spawnerTimer >= currentSpawnRate)
        {
            SpawnAnimal();
            spawnerTimer = 0;
        }

    }

    private void SpawnAnimal()
    {
        int randomAnimal = Random.Range(0, allAnimalTypes.Length);
        Vector2 spawnPointPosition = spawnPoint.position;

        Instantiate(allAnimalTypes[randomAnimal], spawnPointPosition, Quaternion.identity);
    }
}
