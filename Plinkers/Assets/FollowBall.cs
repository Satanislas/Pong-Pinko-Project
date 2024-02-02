using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    private float StartY;
    [CanBeNull] public static GameObject player;
    public float TopY;
    public float BottomY;

    
    void Start()
    {
        StartY = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player is null)
        {
            var position = transform.position;
            if (Math.Abs(position.y - StartY) > 1)
            {
                transform.SetPositionAndRotation(new Vector3(transform.position.x,StartY,transform.position.z),transform.rotation);
            }
            
            return;
        }
        if (player.transform.position.y < TopY && player.transform.position.y > BottomY)
        {
            //Debug.Log("following the player");
            transform.SetPositionAndRotation(new Vector3(transform.position.x,player.transform.position.y,transform.position.z),transform.rotation);
        }
        //Debug.Log("Player position on Y :" + player.transform.position.y);
    }
}
