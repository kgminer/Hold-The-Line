using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour
{
    private int lastPaddleHit = 0;
    public Ball ball;                   // Set by Unity Editor
    public Paddle player1;              // Set by Unity Editor
    public Paddle player2;              // Set by Unity Editor
    public Paddle player3;              // Set by Unity Editor
    public Paddle player4;              // Set by Unity Editor

    private int powerupType = 0;
    private float powerupSpeed = 5.0f;
    private int powerupTimer = 10;

    public Paddle Paddle
    {
        get => default;
        set
        {
        }
    }

    public Defense Defense
    {
        get => default;
        set
        {
        }
    }

    public Ball Ball1
    {
        get => default;
        set
        {
        }
    }

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
        //Debug.Log("Last paddle hit = " + lastPaddleHit);

    }

    private void OnTriggerEnter(Collider trigger)
    {
        powerupType = Random.Range(1, 5);
		
        if (trigger.tag == "Powerup")
        {
            switch (powerupType)
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
                    ball.SetSpeed(ball.GetSpeed() + powerupSpeed);
                    Invoke("ResetSpeed", powerupTimer);
                    break;

                // Damage increase powerup
                case 3:
                    ball.SetIncreasedDamage(true);
					Invoke("ResetIncBallDmg", powerupTimer);
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
			Destroy(trigger.gameObject);
            //Powerup information here to call the method that performs the powerup
        }
    }
	
	public void ResetIncBallDmg()
    {
        if (!GameManager.suddenDeath)
        {
            ball.SetIncreasedDamage(false);
        }
    }
	
    public void ResetSpeed()
    {
        ball.SetSpeed(ball.GetSpeed() - powerupSpeed);
    }
}
