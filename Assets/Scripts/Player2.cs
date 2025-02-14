using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player2 : MonoBehaviour
{
    public float racketSpeed;

    private Rigidbody2D rb;
    private Vector2 racketDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Called once per frame (Timer and detection of inputs)
    void Update()
    {
        //Edit -> Project Settings -> Input Manager -> Axes
        //Gets the preset inputs from ^ and brings them into the code \/
        float directionY = Input.GetAxisRaw("Vertical 2");

        racketDirection = new Vector2(0, directionY).normalized;
    }

    // Called once per physics frame (Anything that needs to change in the RB)
    private void FixedUpdate()
    {
        rb.linearVelocity = racketDirection * racketSpeed;
    }
}
