using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private Transform paddlePosition; 
    [SerializeField]
    private Transform centerPoint;
    private Vector3 inputVector;
    private int currentPlayer = 0;
    string playerInput = null;

    // Start is called before the first frame update
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
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis(playerInput), 0, 0);
        stopPaddleAtWall();
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

    void stopPaddleAtWall()
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
