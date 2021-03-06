﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    Rigidbody ball;
    [SerializeField]
    GameObject ballObject;
    static readonly int NUMBER_OF_SECONDS_IN_MINUTE = 60;
    static readonly float BALL_RADIUS = 0.75f;
    private bool increasedDamage;
    [SerializeField]
    Paddle paddle1;
    [SerializeField]
    Paddle paddle2;
    [SerializeField]
    Paddle paddle3;
    [SerializeField]
    Paddle paddle4;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        ball.velocity = BallStartDirectionVector() * speed;

        if (!GameManager.suddenDeath)
        {
            increasedDamage = false;
        }
        else
        {
            increasedDamage = true;
        }
    }

    private void Update()
    {
        ResetBallVelocity();
    }
    // Ensures that the ball is moving with a constant velocity and rotation.
    // These can be set in either order.
    private void LateUpdate()
    {
        ball.velocity = ball.velocity.normalized * speed;
        SetRotation();
        
    }

    // Supplies the random direction for a new ball to start moving in
    Vector3 BallStartDirectionVector()
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

    /* Sets the ball rotation to be perpendicular to axis of translation.
    X and Z axises need to be flipped so that rotation is perpendicular 
    to translation rather than rotating around the axis of translation.
    Z axis of rotation needs to be inverted due to right hand rule.
    */
    private void SetRotation()
    {
        Vector3 rotation = ball.velocity.normalized * speed;
        //Time.deltaTime is a Unity Function that returns time since last frame update.
        rotation *= Time.deltaTime * NUMBER_OF_SECONDS_IN_MINUTE / BALL_RADIUS;
        float tempRotationX = rotation.x;
        rotation.x = rotation.z;
        rotation.z = -tempRotationX;
        transform.Rotate(rotation, Space.World);
    }

    public float SetSpeed(float s)
    {
        return speed = s;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public Vector3 GetVelocity()
    {
        return ball.velocity;
    }

    public void SetVelocity(Vector3 newVelocity)
    {
        ball.velocity = newVelocity;
    }

    public bool GetIncreasedDamage()
    {
        return increasedDamage;
    }

    public void SetIncreasedDamage(bool newValue)
    {
        increasedDamage = newValue;
    }

    private void ResetBallVelocity()
    {
        if (!paddle1.BallsPlayer1.Contains(ballObject) && !paddle2.BallsPlayer2.Contains(ballObject) && !paddle3.BallsPlayer3.Contains(ballObject) && !paddle4.BallsPlayer4.Contains(ballObject) && speed <= 0)
        {
            speed = 15;
            ball.velocity = BallStartDirectionVector() * speed;
        }
    }
}
