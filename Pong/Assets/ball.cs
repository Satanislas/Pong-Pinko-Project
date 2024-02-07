using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ball : MonoBehaviour
{
    public float paddleWidth;
    public float angle;
    private Rigidbody rb;
    public float speed;
    public float speedIncrease;
    public float colorIncrease;

    public GameObject KillEffect;

    private List<Color> colors = new List<Color>
    {
            new Color(1, 0, 0),    
            new Color(1, 0.5f, 0),     
            new Color(1, 1, 0),      
            new Color(0.5f, 1, 0),     
            new Color(0, 1, 0),     
            new Color(0, 1, 0.5f),      
            new Color(0, 1, 1),                 
            new Color(0, 0.5f, 1),    
            new Color(0, 0, 1),       
            new Color(0.5f, 0, 1),      
            new Color(1, 0, 1),         
            new Color(1, 0, 0.5f),      
            new Color(0.8f, 0, 0.7f),   
            new Color(0.6f, 0, 0),      
    };
    private static int colorIndex;

    public Material Material;
    private static bool isFirst = true;

    [Header("Sound")] public List<AudioClip> sounds;
    private AudioSource audio;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * speed * (GameManager.LastScored ? 1 : -1),ForceMode.Impulse);
        if (isFirst)
        {
            Material.color = Color.red;
            isFirst = false;
        }

        audio = GetComponent<AudioSource>();
        
        GameManager.gm.audio.Play();
    }

    private void OnCollisionEnter(Collision other)
    {
        PlaySound();
    }

    private void PlaySound()
    {
        Debug.Log("Playing sound");
        if (audio.isPlaying)
        {
            AudioSource newAudio = gameObject.AddComponent<AudioSource>();
            newAudio.clip = sounds[Random.Range(0,sounds.Count)];
            newAudio.Play();
            return;
        }
        audio.clip = sounds[Random.Range(0,sounds.Count)];
        audio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            GameManager.gm.Score(other.GetComponent<Goal>().axis == Goal.Axis.Left);
            return;
        }
        bool isLeft = other.GetComponent<PaddlePlayer>().axis == PaddlePlayer.Axis.Left;
        Vector3 bounce = isLeft ? Vector3.right : Vector3.left;

        float angleValue = (transform.position.z - other.transform.position.z)*2 / paddleWidth * (isLeft ? -1 : 1);
        Quaternion rotation = Quaternion.Euler(0, angleValue * angle,0);
        bounce = rotation * bounce;
        rb.velocity = Vector3.zero; 
        rb.AddForce(bounce * speed,ForceMode.Impulse);

        OnHit();
    }

    private void OnHit()
    {
        speed += speedIncrease;
        Material.color = colors[colorIndex++ % colors.Count];
        PlaySound();
    }

    private void OnDestroy()
    {
        GameObject effect = Instantiate(KillEffect);
        effect.transform.position = transform.position;
        GameManager.gm.audio.Pause();
    }
}