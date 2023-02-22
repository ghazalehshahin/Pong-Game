using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float upperBoundary = 3.3f;
    [SerializeField] private float lowerBoundary = -3.3f;

    public GameObject playerOne;
    public GameObject playerTwo;

    private GameObject ball;

    public static int playerOneScore = 0;
    public static int playerTwoScore = 0;
    private static GameObject score1;
    private static GameObject score2;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        score1 = GameObject.FindGameObjectWithTag("Score1");
        score2 = GameObject.FindGameObjectWithTag("Score2");
    }
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

    public static void Score (string wall)
    {
        if (wall == "left")
        {
            playerOneScore += 1;
            score1.GetComponent<TextMeshProUGUI>().SetText(playerOneScore.ToString());
        }
        if (wall == "right")
        {
            playerTwoScore += 1;
            score2.GetComponent<TextMeshProUGUI>().SetText(playerTwoScore.ToString());
        }
    }
}

