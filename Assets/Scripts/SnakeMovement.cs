using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SnakeMovement : MonoBehaviour
{

    
    public Vector2 inputVector = new Vector2 (1,0);
    Vector2 previousInput;
    Vector3 snakeDirection;
    [SerializeField] public List<Transform> segments;
    [SerializeField] Transform segmentPrefab;
    GameOver gameOver;
    [SerializeField] TextMeshProUGUI lengthText;
    

    void Start() 
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
        gameOver = GetComponent<GameOver>();
        
           
    }
 
    
    
    void FixedUpdate()
    {
        if(!gameOver.isGameOver)
        {
            if(segments.Count > 1)
            {
                snakeDirection = this.transform.position-segments[1].transform.position;        
            }
            SegmentMovement();
            Move();
            UpdateLengthText();
            
            
        }
        
        
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        
        if(inputVector == new Vector2 (0,0))
        {
            inputVector = previousInput;
        }
        else
        {
            previousInput = inputVector;
        }

        
    }

    void Move()
    {
        
        if( inputVector.x > 0.8f)
        {
            FixedBackwardsMoving();
        }
        else if(inputVector.y > 0.8f)
        {    
            FixedBackwardsMoving();
        }
        else if(inputVector.x < -0.8f)
        {
            FixedBackwardsMoving();
        }
        else if(inputVector.y < -0.8f)
        {
            FixedBackwardsMoving();
        }
        else
        {
            inputVector = new Vector2 (Mathf.Sign(inputVector.x),0);
            if(segments.Count > 1)
            {
                this.transform.position = new Vector3 (Mathf.Round(this.transform.position.x) + snakeDirection.x, Mathf.Round(this.transform.position.y) + snakeDirection.y, 0.0f);
            }
            
        }

        


    }


    public void Grow()
    {
        Transform segmentpart = Instantiate(this.segmentPrefab);
        segmentpart.position = segments[segments.Count - 1].position;
        segments.Add(segmentpart);
        
    }

    void SegmentMovement()
    {

        for(int i = segments.Count - 1 ; i > 0 ; i--)
            {
                segments[i].position = segments[i-1].position;
            }
          
    }

    void FixedBackwardsMoving()
    {
        if(snakeDirection == new Vector3 (1,0,0) && inputVector == new Vector2 (-1,0))
        {
            this.transform.position = new Vector3 (Mathf.Round(this.transform.position.x) + snakeDirection.x, Mathf.Round(this.transform.position.y) + snakeDirection.y, 0.0f);
        }
        else if(snakeDirection == new Vector3 (-1,0,0) && inputVector == new Vector2 (1,0))
        {
            this.transform.position = new Vector3 (Mathf.Round(this.transform.position.x) + snakeDirection.x, Mathf.Round(this.transform.position.y) + snakeDirection.y, 0.0f);
        }
        else if(snakeDirection == new Vector3 (0,1,0) && inputVector == new Vector2 (0,-1))
        {
            this.transform.position = new Vector3 (Mathf.Round(this.transform.position.x) + snakeDirection.x, Mathf.Round(this.transform.position.y) + snakeDirection.y, 0.0f);
        }
        else if(snakeDirection == new Vector3 (0,-1,0) && inputVector == new Vector2 (0,1))
        {
            this.transform.position = new Vector3 (Mathf.Round(this.transform.position.x) + snakeDirection.x, Mathf.Round(this.transform.position.y) + snakeDirection.y, 0.0f);
        }
        else
        {
            this.transform.position = new Vector3 (Mathf.Round(this.transform.position.x) + inputVector.x, Mathf.Round(this.transform.position.y) + inputVector.y, 0.0f);
        }
    }

    void UpdateLengthText()
    {
        lengthText.text = "Length: " + segments.Count;
    }
}
