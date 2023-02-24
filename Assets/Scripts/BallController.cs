using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private static Rigidbody2D ballRgbd;

    private void Start()
    {
        ballRgbd = GetComponent<Rigidbody2D>();

        //Ball starts moving after 2 seconds
        GoBall(0);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = ballRgbd.velocity.x;
            vel.y = (ballRgbd.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            ballRgbd.velocity = vel;
        }

        if (coll.collider.CompareTag("Right"))
        {
            GameController.Score("right");
            ResetBall();
            if (GameController.playerTwoScore != 5)
            {
                GoBall(0);
            }
        }

        if (coll.collider.CompareTag("Left"))
        {
            GameController.Score("left");
            ResetBall();
            if (GameController.playerOneScore != 5)
            {
                GoBall(0);
            }
        }
    }

    //Moving the ball for the first time
    void GoBall(int x)
    {
        if (x == 1)
        {
            GameController.playerOneScore = 0;
            GameController.playerTwoScore = 0;
        }
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            ballRgbd.AddForce(new Vector2(20, -15));
        }
        else
            ballRgbd.AddForce(new Vector2(-20, -15));
    }

    void ResetBall()
    {
        ballRgbd.velocity = Vector2.zero;
        ballRgbd.transform.position = Vector2.zero;
    }
}
