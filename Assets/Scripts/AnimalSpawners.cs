using NUnit.Framework;
using UnityEngine;

public class AnimalSpawners : MonoBehaviour
{
    private Transform spawnPoint;
    [SerializeField] private GameObject[] allAnimalTypes; // Assign animal types in Unity Inspector

    void Start()
    {
        GameObject spawner = GameObject.Find("AnimalSpawner");
        if(spawner != null)
        {
            spawnPoint = spawner.transform;
        }
  
    }

    // Update is called once per frame
    void Update()
    {
        int randomAnimal = Random.Range(0, allAnimalTypes.Length);
        Vector2 spawnPointPosition = spawnPoint.position;

        Instantiate(allAnimalTypes[randomAnimal], spawnPointPosition, Quaternion.identity);
    }
}
