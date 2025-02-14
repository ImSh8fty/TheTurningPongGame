using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Serialization;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    private int hitCounter = 0;

    private Rigidbody2D rb;

    private void Start()
    {
       // Im assuming this brings the physics the sprite from the get-go
       rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
    }

    private void RestartBall()
    {
        rb.linearVelocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }

    //IEnumerator is something for the program to go back to when the game needs to be reset
    //Launch() means "When the game starts, I will do this..."

    public IEnumerator Launch() 
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        int randomX = Random.Range(0, 2) * 2 - 1;
        int randomY = Random.Range(0, 2) * 2 - 1;

        MoveBall(new Vector2(randomX, randomY)); //new changes the direction from the initial state
    }

    public void MoveBall(Vector2 direction) //Vector2 = Values for X and Y 
    {
        direction = direction.normalized;  //normalized makes sure user input is always at consistent speed no matter what 

        float ballSpeed = startSpeed + hitCounter * extraSpeed; //determines ball speed throughout the game

        rb.linearVelocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if(hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}
