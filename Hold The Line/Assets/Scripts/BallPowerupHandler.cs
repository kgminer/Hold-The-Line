using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPowerupHandler : MonoBehaviour
{
    private int lastPaddleHit = 0;
    public Paddle player1;
    public Paddle player2;
    public Paddle player3;
    public Paddle player4;

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
        if (trigger.tag == "Powerup")
        {
            Destroy(trigger.gameObject);
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
            //Powerup information here to call the method that performs the powerup
        }
    }
}
