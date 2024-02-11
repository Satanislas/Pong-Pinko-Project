using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public static PickUpManager Manager;
    public List<GameObject> pickups;
    public float timeBetweenPickUps;
    private float spawnTimer;
    private AudioSource audio;
    [Header("Bounds")]
    public float leftBound;
    public float rightBound;
    public float topBound;
    public float botBound;
    
    // Start is called before the first frame update
    void Start()
    {
        Manager = this;
        spawnTimer = timeBetweenPickUps;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            int i = Random.Range(0, pickups.Count);
            GameObject pickup = Instantiate(pickups[i]);
            pickup.transform.position = new Vector3(Random.Range(leftBound,rightBound),0,Random.Range(botBound,topBound));
            
            spawnTimer = timeBetweenPickUps;
        }
        
    }

    public void playSound(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
}
