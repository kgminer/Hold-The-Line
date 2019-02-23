using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed;
    Rigidbody ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        ball.velocity = Vector3.one * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
