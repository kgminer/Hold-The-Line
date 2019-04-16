using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private int speed = 30;                     // Changed by unity editor
    [SerializeField]
    private Transform paddle;           // Set by unity editor
    [SerializeField]
    private Transform centerPoint;              // Set by unity editor
    private Vector3 inputVector;
    private int currentPlayer = 0;
    [SerializeField]
    private int powerupTimer = 10;
    private bool inverted;
    private bool canGrabBall;
    string playerInput = null;
    string grabInput = null;
    [SerializeField]
    public List<GameObject> BallsPlayer1;
    public List<GameObject> BallsPlayer2;
    public List<GameObject> BallsPlayer3;
    public List<GameObject> BallsPlayer4;

    public Base Base
    {
        get => default;
        set
        {
        }
    }

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
        grabInput = ("Grab Ball " + currentPlayer.ToString());
        inverted = false;
        BallsPlayer1 = new List<GameObject>();
        BallsPlayer2 = new List<GameObject>();
        BallsPlayer3 = new List<GameObject>();
        BallsPlayer4 = new List<GameObject>();
    }

    // Update is called once per frame
    // Reads input from controller to determine which direction and speed to move the paddle. 
    void Update()
    {
        if(!inverted)
        {
            if(GameManager.topDownCameraMode && (currentPlayer == 1 || currentPlayer == 2))
            {
                inputVector = new Vector3(-Input.GetAxis(playerInput), 0, 0);
            }
            else
            {
                inputVector = new Vector3(Input.GetAxis(playerInput), 0, 0);
            }
            
        }
        else
        {
            if (GameManager.topDownCameraMode && (currentPlayer == 1 || currentPlayer == 2))
            {
                inputVector = new Vector3(Input.GetAxis(playerInput), 0, 0);
            }
            else
            {
                inputVector = new Vector3(-Input.GetAxis(playerInput), 0, 0);
            }
        }
        StopPaddleAtWall();
        //Rotate any of the balls that are in the list
        transform.RotateAround(centerPoint.position, Vector3.up, speed * inputVector.x);
        //Debug.Log("currentPlayer: " + currentPlayer + " centerPoint: " + centerPoint);
        switch (currentPlayer)
        {
            case 1:
                //Grabbing Functionality for Player 1
                if (gameObject.tag == "Player1" && BallsPlayer1.Count != 0 && Input.GetButton(grabInput))
                {
                    //go through each ball in the list and set their speeds to 0
                    foreach (GameObject ball in BallsPlayer1)
                    {
                        
                        ball.GetComponent<Ball>().SetSpeed(0);
                        ball.transform.RotateAround(centerPoint.position, Vector3.up, speed * inputVector.x);
                    }
                }

                if (gameObject.tag == "Player1" && BallsPlayer1.Count != 0 && Input.GetButtonUp(grabInput))
                {
                    //set a new velocity and speed for each of the balls in the list
                    foreach (GameObject ball in BallsPlayer1)
                    { 
                        ball.GetComponent<Ball>().SetVelocity(gameObject.transform.position);
                        ball.GetComponent<Ball>().SetSpeed(15);
                        
                    }
                }
                break;
            case 2:
                //Grabbing Functionality for Player 2
                if (gameObject.tag == "Player2" && BallsPlayer2.Count != 0 && Input.GetButton(grabInput))
                {
                    //go through each ball in the list and set their speeds to 0
                    foreach (GameObject ball in BallsPlayer2)
                    {
                        
                        ball.GetComponent<Ball>().SetSpeed(0);
                        ball.transform.RotateAround(centerPoint.position, Vector3.up, speed * inputVector.x);
                    }
                }

                if (gameObject.tag == "Player2" && BallsPlayer2.Count != 0 && Input.GetButtonUp(grabInput))
                {
                    //set a new velocity and speed for each of the balls in the list
                    foreach (GameObject ball in BallsPlayer2)
                    {
                        ball.GetComponent<Ball>().SetVelocity(gameObject.transform.position);
                        ball.GetComponent<Ball>().SetSpeed(15);
                        
                    }
                }
                break;
            case 3:
                //Grabbing Functionality for Player 3
                if (gameObject.tag == "Player3" && BallsPlayer3.Count != 0 && Input.GetButton(grabInput))
                {
                    //go through each ball in the list and set their speeds to 0
                    foreach (GameObject ball in BallsPlayer3)
                    {
                        
                        ball.GetComponent<Ball>().SetSpeed(0);
                        ball.transform.RotateAround(centerPoint.position, Vector3.up, speed * inputVector.x);
                    }
                }

                if (gameObject.tag == "Player3" && BallsPlayer3.Count != 0 && Input.GetButtonUp(grabInput))
                {
                    //set a new velocity and speed for each of the balls in the list
                    foreach (GameObject ball in BallsPlayer3)
                    {
                        ball.GetComponent<Ball>().SetVelocity(gameObject.transform.position);
                        ball.GetComponent<Ball>().SetSpeed(15);
                        
                    }
                }
                break;
            case 4:
                //Grabbing Functionality for Player 4
                if (gameObject.tag == "Player4" && BallsPlayer4.Count != 0 && Input.GetButton(grabInput))
                {
                    //go through each ball in the list and set their speeds to 0
                    foreach (GameObject ball in BallsPlayer4)
                    {
                        
                        ball.GetComponent<Ball>().SetSpeed(0);
                        ball.transform.RotateAround(centerPoint.position, Vector3.up, speed * inputVector.x);
                    }
                }

                if (gameObject.tag == "Player4" && BallsPlayer4.Count != 0 && Input.GetButtonUp(grabInput))
                {
                    //set a new velocity and speed for each of the balls in the list
                    foreach (GameObject ball in BallsPlayer4)
                    {
                        ball.GetComponent<Ball>().SetVelocity(gameObject.transform.position);
                        ball.GetComponent<Ball>().SetSpeed(15);
                        
                    }
                }
                break;
        }    
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (currentPlayer)
        {
            case 1:
                BallsPlayer1.Add(other.gameObject);
                break;
            case 2:
                BallsPlayer2.Add(other.gameObject);
                break;
            case 3:
                BallsPlayer3.Add(other.gameObject);
                break;
            case 4:
                BallsPlayer4.Add(other.gameObject);
                break;
        }
        //Debug.Log("List size: " + Balls.Count);
        canGrabBall = true;
    }

    public void OnTriggerExit(Collider other)
    {
        switch (currentPlayer)
        {
            case 1:
                BallsPlayer1.Remove(other.gameObject);
                break;
            case 2:
                BallsPlayer2.Remove(other.gameObject);
                break;
            case 3:
                BallsPlayer3.Remove(other.gameObject);
                break;
            case 4:
                BallsPlayer4.Remove(other.gameObject);
                break;
        }
        //Debug.Log("List size: " + Balls.Count);
        canGrabBall = false;
    }

    // Checks if the paddle is to the left or to the right of the pivot point. Positive is right, negative is left.
    float GetRelativePaddlePositionX()
    {
        float relativePaddlePosition = 0;
        relativePaddlePosition = paddle.position.x - centerPoint.position.x;
        return relativePaddlePosition;
    }

    // Checks if the paddle is above or below the pivot point. Positive is above, negative is below.
    float GetRelativePaddlePositionZ()
    {
        float relativePaddlePosition = 0;
        relativePaddlePosition = paddle.position.z - centerPoint.position.z;
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
    public void EnlargePaddle()
    {
        paddle.gameObject.transform.localScale = new Vector3(3, 0.25f, 1);
        Invoke("ResetPaddle", powerupTimer);
    }
    
    public void InvertControls()
    {
        inverted = true;
        Invoke("ResetPaddle", powerupTimer);
    }

    public void ResetPaddle()
    {
        inverted = false;
        paddle.gameObject.transform.localScale = new Vector3(2, 0.25f, 1);
    }
}
