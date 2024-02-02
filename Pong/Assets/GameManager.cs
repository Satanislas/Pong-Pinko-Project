using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static bool LastScored = false;
    public float TopBound;
    public float BotBound;

    private int scoreLeft;
    private int scoreRight;

    public TextMeshProUGUI textLeft;
    public TextMeshProUGUI textRight;

    public GameObject ballPrefab;
    private GameObject ball;
    private float ballTimer;
    public float respawnTime;
    private bool isRespawning;

    public GameObject LeftWinner;
    public GameObject RightWinner;
    public int maxScore;
    private void Start()
    {
        gm = this;
        ball = Instantiate(ballPrefab);
    }

    public void Score(bool isLeft)
    {
        Debug.Log(isLeft ? "Right scored" : "Left scored");
        if (isLeft)
        {
            LastScored = true;
            scoreLeft++;
            textLeft.text = scoreLeft.ToString("00");
            if (scoreLeft >= maxScore)
            {
                LeftWinner.SetActive(true);
                Destroy(ball);
                return;
            }
        }
        else
        {
            LastScored = false;
            scoreRight++;
            textRight.text = scoreRight.ToString("00");
            if (scoreRight >= maxScore)
            {
                RightWinner.SetActive(true);
                Destroy(ball);
                return;
            }
        }
        
        Destroy(ball);
        ball = null;
        ballTimer = respawnTime;
        isRespawning = true;
    }

    private void Update()
    {
        if (isRespawning)
        { 
            if (ballTimer>0)
                ballTimer -= Time.deltaTime;
            else
            {
                isRespawning = false;
                ball = Instantiate(ballPrefab);
                if (scoreRight == 6 && scoreLeft == 9 || scoreRight == 4 && scoreLeft == 2)
                {
                    Debug.Log("You have amused the gods of this silly game");
                    ball.transform.localScale = new Vector3(3,3,3);
                }            }
        }
    }
}
