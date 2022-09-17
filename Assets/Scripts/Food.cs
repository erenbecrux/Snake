using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    
    SnakeMovement snakeMovement;
    FoodSpawn foodSpawn;
    
    

    void Start() 
    {
        snakeMovement = GetComponent<SnakeMovement>();
        foodSpawn = FindObjectOfType<FoodSpawn>();
            
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Food")
        {

            // increase size
            snakeMovement.Grow();
            Destroy(other.gameObject);
            foodSpawn.eatenFoodNumber++;
           
        }    
        else if(other.tag == "BiggerFood")
        {
            snakeMovement.Grow();
            snakeMovement.Grow();
            snakeMovement.Grow();
            Destroy(other.gameObject);
            foodSpawn.eatenFoodNumber = 0;
        }
    }


}
