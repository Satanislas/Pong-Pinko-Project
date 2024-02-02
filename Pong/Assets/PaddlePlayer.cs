using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePlayer : MonoBehaviour
{  
    public enum Axis
    {
        Left,
        Right,
    }

    public float speed;
    public Axis axis;

    private void Update()
    {
        float input = Input.GetAxis(axis == Axis.Left ? "LeftPaddle" : "RightPaddle");

        
        if (input != 0)
        {
            //Boundaries
            if (input > 0 && transform.position.z >= GameManager.gm.TopBound) return;
            if (input < 0 && transform.position.z <= GameManager.gm.BotBound) return;
            
            //Inside bounds
            transform.position += new Vector3(0, 0, input * speed * Time.deltaTime);
        }
    }
}
