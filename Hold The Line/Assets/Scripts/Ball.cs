using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    Rigidbody ball;
    static readonly int NUMBER_OF_SECONDS_IN_MINUTE = 60;
    static readonly float BALL_RADIUS = 0.75f;
    private int lastPaddleHit = 0;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        ball.velocity = BallStartDirectionVector() * speed;
    }

    // Called at the start of every frame
    private void Update()
    {
        
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
}
