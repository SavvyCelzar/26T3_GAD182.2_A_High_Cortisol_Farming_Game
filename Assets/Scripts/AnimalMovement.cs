using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using SAE.GAD182.Project2.SortTheSheep;
public class AnimalMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> allDestinations;
    [SerializeField] private float moveSpeed = 1f;
    private int currentDestination;
    private bool randomDirections;
    private MainSheepController sheepController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentDestination = 0;
        randomDirections = true;
    }

    // Update is called once per frame
   private void Update()
    {
        MoveSelf();
 
    }


    private void MoveSelf()
    {
        transform.position = Vector2.MoveTowards(transform.position, allDestinations[currentDestination].position, moveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, allDestinations[currentDestination].position) < moveSpeed * Time.deltaTime)
        {
            switch (randomDirections)
            {
                case true:

                    int randomNumber = Random.Range(0, allDestinations.Count);
                    currentDestination = randomNumber;

                    break;

                case false:
                    currentDestination++;
                    if (currentDestination >= allDestinations.Count)
                    {
                        currentDestination = 0;
                    }
                    break;
            }          
        }
    }
}
