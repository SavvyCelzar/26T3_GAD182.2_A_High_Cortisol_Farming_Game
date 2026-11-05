using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class AnimalSpawners : Timer
{
    private Transform spawnPoint;
    private float timeBetweenSpawns = 3f;
    [SerializeField] private GameObject[] allAnimalTypes; // Assign animal types in Unity Inspector
    private List<GameObject> animalsInScene = new List<GameObject>();
    private float timer;

    protected override void Start()
    {
        base.Start();

        GameObject spawner = GameObject.Find("AnimalSpawner");
        if(spawner != null)
        {
            spawnPoint = spawner.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        ChangeSpawnRate();

        if (timer >= timeBetweenSpawns)
        {
            SpawnAnimal();
            timer = 0;
        }

    }

    private void ChangeSpawnRate()
    {
        if (currentTime <= 80 && currentTime >= 41)
        {
            timeBetweenSpawns = 2;
            Debug.Log("Spawn rate is now 2 seconds");
        }
        else if (currentTime <= 40 && currentTime >= 21)
        {
            timeBetweenSpawns = 1;
            Debug.Log("Spawn rate is now 1 second");
        }
        else if (currentTime <= 20 && currentTime >= 11)
        {
            timeBetweenSpawns = 0.5f;
            Debug.Log("Spawn rate is now 0.5 seconds");
        }
        else if (currentTime <= 10 && currentTime >= 1)
        {
            timeBetweenSpawns = 0.1f;
            Debug.Log("Spawn rate is now 0.1 second");
        }
    }

    private void SpawnAnimal()
    {
        int randomAnimal = Random.Range(0, allAnimalTypes.Length);
        Vector2 spawnPointPosition = spawnPoint.position;

        Instantiate(allAnimalTypes[randomAnimal], spawnPointPosition, Quaternion.identity);
    }
}
