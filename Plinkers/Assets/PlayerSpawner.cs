using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public float leftBound;
    public float rightBound;
    void Start()
    {
        Debug.Log("Spawning a new player ...");
        GameObject player = Instantiate(playerPrefab);
        player.transform.SetPositionAndRotation(
            new Vector3(Random.Range(leftBound, rightBound), playerPrefab.transform.position.y,playerPrefab.transform.position.z),
            playerPrefab.transform.rotation);

        deathTimer = respawnTime;
    }

    // Update is called once per frame
    public float respawnTime;
    private float deathTimer;
    void Update()
    {
        if (FollowBall.player is not null) return;
        
        Debug.Log("Time until respawn :" + deathTimer);
        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0)
        {
            Start();
        }
    }
}
