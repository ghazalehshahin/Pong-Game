using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float upperBoundary = 2f;
    [SerializeField] private float lowerBoundary = -2f;

    public GameObject playerOne;
    public GameObject playerTwo;

    void Update()
    {
        Movement();
        LimitMovement(playerOne);
        LimitMovement(playerTwo);
    }

    //Set limitation to users movements
    void LimitMovement(GameObject player)
    {
        if (player.transform.position.y <= lowerBoundary)
        {
            player.transform.position = new Vector2(player.transform.position.x, lowerBoundary);
        }
        if (player.transform.position.y >= upperBoundary)
        {
            player.transform.position = new Vector2(player.transform.position.x, upperBoundary);
        }
    }

    //Player controller function
    void Movement()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerOne.transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerOne.transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            playerTwo.transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerTwo.transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
    }
}

