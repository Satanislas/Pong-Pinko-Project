using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlotTrigger : MonoBehaviour
{
    public int points;
    public TextMeshProUGUI score;
    public static int Score = 0;
    private float scoreToMark;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You won " + points + " points !");
        GameObject player = FollowBall.player;
        FollowBall.player = null;
        Destroy(player);

        scoreToMark = points;
    }

    void Update()
    {
        if (scoreToMark > 0)
        {
            Debug.Log("marked");
            scoreToMark--;
            Score++;
            score.text = "Score : " + Score;
        }
    }
}
