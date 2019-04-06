using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPowerupHandler : MonoBehaviour
{
    private int lastPaddleHit = 0;
    public Ball Ball;
    public Paddle player1;
    public Paddle player2;
    public Paddle player3;
    public Paddle player4;

    private int PowerupType;
    private float PowerupSpeed = 5.0f;

    public void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player1":
                lastPaddleHit = 1;
                break;
            case "Player2":
                lastPaddleHit = 2;
                break;
            case "Player3":
                lastPaddleHit = 3;
                break;
            case "Player4":
                lastPaddleHit = 4;
                break;
            default:
                break;
        }
        Debug.Log("Last paddle hit = " + lastPaddleHit);

    }

    private void OnTriggerEnter(Collider trigger)
    {
        PowerupType = Random.Range(1, 5);
        
        if (trigger.tag == "Powerup")
        {
            Destroy(trigger.gameObject);
            switch (PowerupType)
            {
                // Enlarge Paddle Powerup
                case 1:
                    switch (lastPaddleHit)
                    {
                        case 1:
                            player1.EnlargePaddle();
                            break;
                        case 2:
                            player2.EnlargePaddle();
                            break;
                        case 3:
                            player3.EnlargePaddle();
                            break;
                        case 4:
                            player4.EnlargePaddle();
                            break;
                        default:
                            break;
                    }
                    break;

                // Ball speed increase powerup
                case 2:
                    Ball.SetSpeed(Ball.GetSpeed() + PowerupSpeed);
                    Invoke("ResetSpeed", 10.0f);
                    break;

                // Damage increase powerup
                case 3:

                    break;

                // Control inversion powerup
                case 4:
                    switch (lastPaddleHit)
                    {
                        case 1:
                            player2.InvertControls();
                            player3.InvertControls();
                            player4.InvertControls();
                            break;
                        case 2:
                            player1.InvertControls();
                            player3.InvertControls();
                            player4.InvertControls();
                            break;
                        case 3:
                            player1.InvertControls();
                            player2.InvertControls();
                            player4.InvertControls();
                            break;
                        case 4:
                            player1.InvertControls();
                            player2.InvertControls();
                            player3.InvertControls();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
            //Powerup information here to call the method that performs the powerup
        }
    }

    public void ResetSpeed()
    {
        Ball.SetSpeed(Ball.GetSpeed() - PowerupSpeed);
    }
}
