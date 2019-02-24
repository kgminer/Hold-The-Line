using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    Rigidbody ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        ball.velocity = BallStartVeloctiy() * speed;
    }

    // Ensures that the ball is moving with a constant velocity
    private void LateUpdate()
    {
        ball.velocity = ball.velocity.normalized * speed;
    }

    // Supplies the random direction for a new ball to start moving in
    Vector3 BallStartVeloctiy()
    {
        Vector3 startVelocity;
        startVelocity.x = Random.Range(.1f, 1);
        startVelocity.y = 0;
        startVelocity.z = Random.Range(.1f, 1);
        int startQuadrant = 0;
        startQuadrant = Random.Range(0, 4);
        switch (startQuadrant)
        {
            case 0:
                startVelocity.x *= -1;
                startVelocity.z *= -1;
                break;
            case 1:
                startVelocity.x *= -1;
                break;
            case 2:
                break;
            case 3:
                startVelocity.z *= -1;
                break;
            default:
                break;
        }
        startVelocity = Vector3.Normalize(startVelocity);
        return startVelocity;
    }
}