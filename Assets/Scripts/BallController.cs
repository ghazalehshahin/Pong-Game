using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ballRgbd;

    private void Start()
    {
        ballRgbd = GetComponent<Rigidbody2D>();

        //Ball starts moving after 2 seconds
        Invoke("GoBall", 2);
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
    }

    //Moving the ball for the first time
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            ballRgbd.AddForce(new Vector2(20, -15));
        }
        else
            ballRgbd.AddForce(new Vector2(-20, -15));
    }
}
