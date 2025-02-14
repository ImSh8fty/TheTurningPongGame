using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BallBounce : MonoBehaviour
{
    public BallMovement ballMovement; //Gets info from Ball Movement script (Reference!)
    public ScoreManager scoreManager;

    private void Bounce(Collider2D collision)
    {
        Vector3 ballPosition = transform.position; //Takes the position of the ball (transform.position gets the position and put in into ballPos)
        Vector3 racketPosition = collision.transform.position; //Takes position of the racket when it hits the ball 

        float racketHeight = collision.GetComponent<Collider2D>().bounds.size.y;
                           // Finds the specific collider        Gets the height of the racket

        float positionX;
        if(collision.gameObject.name == "Player 1") // Making sure we are looking for a specific game object
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y -  racketPosition.y) / racketHeight; // the .y makes sure we are only focusing on the y value out of the Vectors

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            Bounce(collision);
        }
        else if(collision.gameObject.name == "Right Border")
        {
            scoreManager.Player1Goal();
            StartCoroutine(ballMovement.Launch());
        }
        else if(collision.gameObject.name == "Left Border")
        {
            scoreManager.Player2Goal();
            StartCoroutine(ballMovement.Launch());
        }
    }

    private void Bounce(Collision2D collision)
    {
        throw new NotImplementedException();
    }
}
