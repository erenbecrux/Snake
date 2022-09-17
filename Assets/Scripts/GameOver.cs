using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public bool isGameOver;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] TextMeshProUGUI scoreText;
    SnakeMovement snakeMovement;

    void Start() 
    {
        snakeMovement = GetComponent<SnakeMovement>();    
    }

    void Update() 
    {
        scoreText.text = "Score: " + snakeMovement.segments.Count;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {

        if(other.tag == "Wall")
        {
            Debug.Log("Game Over");
            isGameOver = true;
            gameOverCanvas.SetActive(true);
            
        }

        if(other.tag == "Segment")
        {
            Debug.Log("Game Over");
            isGameOver = true;
            gameOverCanvas.SetActive(true);
        }

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        gameOverCanvas.SetActive(false);
    }


 
}
