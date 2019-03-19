using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private int speed = 30;                     // Changed by unity editor
    [SerializeField]
    private Transform paddlePosition;           // Set by unity editor
    [SerializeField]
    private Transform centerPoint;              // Set by unity editor
    private Vector3 inputVector;
    private int currentPlayer = 0;
    string playerInput = null;

    // Start is called before the first frame update.
    // Determines which player number the paddle is for based on the location of the paddle.
    void Start() {
        float xStartPosition = GetRelativePaddlePositionX();
        float yStartPosition = GetRelativePaddlePositionZ();
        if (xStartPosition >= 0) {
            if (yStartPosition >= 0)
            {
                currentPlayer = 3;
            }
            else
            {
                currentPlayer = 1;
            }
        } 
        else
        {
            if (yStartPosition >= 0)
            {
                currentPlayer = 4;
            }
            else
            {
                currentPlayer = 2;
            }
        }
        playerInput = ("Player" + currentPlayer.ToString());
    }

    // Update is called once per frame
    // Reads input from controller to determine which direction and speed to move the paddle. 
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis(playerInput), 0, 0);
        StopPaddleAtWall();
        transform.RotateAround(centerPoint.position, Vector3.up, speed * inputVector.x);

    }

    // Checks if the paddle is to the left or to the right of the pivot point. Positive is right, negative is left.
    float GetRelativePaddlePositionX()
    {
        float relativePaddlePosition = 0;
        relativePaddlePosition = paddlePosition.position.x - centerPoint.position.x;
        return relativePaddlePosition;
    }

    // Checks if the paddle is above or below the pivot point. Positive is above, negative is below.
    float GetRelativePaddlePositionZ()
    {
        float relativePaddlePosition = 0;
        relativePaddlePosition = paddlePosition.position.z - centerPoint.position.z;
        return relativePaddlePosition;
    }

    // Checks if the paddle has reached the wall. If it has reached the wall and the
    // controller is trying to move the paddle in that direction, then the speed of the 
    // paddle is set to zero. Otherwise this function doesn’t change the speed of the paddle at all.
    void StopPaddleAtWall()
    {
        switch (currentPlayer)
        {
            case 1:
                if (GetRelativePaddlePositionX() <= 1 && inputVector.x > 0)
                {
                    inputVector.x = 0;
                }
                else if (GetRelativePaddlePositionZ() >= -1 && inputVector.x < 0)
                {
                    inputVector.x = 0;
                }
                break;

            case 2:
                if (GetRelativePaddlePositionX() >= -1 && inputVector.x < 0)
                {
                    inputVector.x = 0;
                }
                else if (GetRelativePaddlePositionZ() >= -1 && inputVector.x > 0)
                {
                    inputVector.x = 0;
                }
                break;

            case 3:
                if (GetRelativePaddlePositionX() <= 1 && inputVector.x < 0)
                {
                    inputVector.x = 0;
                }
                else if (GetRelativePaddlePositionZ() <= 1 && inputVector.x > 0)
                {
                    inputVector.x = 0;
                }
                break;

            case 4:
                if (GetRelativePaddlePositionX() >= -1 && inputVector.x > 0)
                {
                    inputVector.x = 0;
                }
                else if (GetRelativePaddlePositionZ() <= 1 && inputVector.x < 0)
                {
                    inputVector.x = 0;
                }
                break;

            default:
                print("Invalid Player Selection");
                break;
        }
    }
}
