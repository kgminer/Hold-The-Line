using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2 : MonoBehaviour
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private Transform paddlePosition; 
    [SerializeField]
    private Transform centerPoint;
    private Vector3 inputVector;
    string playerInput = "Player2";
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis(playerInput), 0, 0);
        if (GetRelativePaddlePositionX() <= 1 && inputVector.x > 0)
        {
            inputVector.x = 0;
        }
        else if (GetRelativePaddlePositionZ() >= -1 && inputVector.x < 0)
        {
            inputVector.x = 0;
        }
        transform.RotateAround(centerPoint.position, Vector3.up, speed * inputVector.x);

    }

    float GetRelativePaddlePositionX()
    {
        float relativePaddlePosition = 0;
        relativePaddlePosition = paddlePosition.position.x - centerPoint.position.x;
        return relativePaddlePosition;
    }

    float GetRelativePaddlePositionZ()
    {
        float relativePaddlePosition = 0;
        relativePaddlePosition = paddlePosition.position.z - centerPoint.position.z;
        return relativePaddlePosition;
    }
}
