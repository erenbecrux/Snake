using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField] GridArea gridArea;
    [SerializeField] GameObject foodPrefab;
    [SerializeField] GameObject biggerFoodPrefab;
    BoxCollider2D gridAreaBoxCollider;
    public int eatenFoodNumber = 0;
    int generatedFoodNumber = 0;
    

    void Awake() 
    {
        gridArea = FindObjectOfType<GridArea>();
        gridAreaBoxCollider = gridArea.GetComponent<BoxCollider2D>();    
    }
    void Start()
    {
        
        SpawnFood();
    }
    void Update()
    {
        if(generatedFoodNumber == eatenFoodNumber)
        {
            SpawnFood();
        }
        else if(generatedFoodNumber == 5)
        {
            SpawnBiggerFood();
        }
    }

    Vector3 RandomPosition()
    {
        Bounds bounds = gridAreaBoxCollider.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 randomPosition = new Vector3 (Mathf.Round(x),Mathf.Round(y),0.0f);
        return randomPosition;

    }

    void SpawnFood()
    {
        Vector3 foodPosition = RandomPosition();
        Instantiate(foodPrefab, foodPosition, Quaternion.identity);
        generatedFoodNumber++;

    }

    void SpawnBiggerFood()
    {
        Vector3 foodPosition = RandomPosition();
        Instantiate(biggerFoodPrefab, foodPosition, Quaternion.identity);
        generatedFoodNumber = 0;
    }

}
