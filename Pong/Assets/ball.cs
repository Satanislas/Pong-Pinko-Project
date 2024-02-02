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
        Color.yellow,
        Color.blue,
        Color.cyan,
        Color.green,
        Color.magenta,
        Color.red,
        Color.black,
        Color.white,
    };

    public Material Material;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * speed * (GameManager.LastScored ? 1 : -1),ForceMode.Impulse);
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
        Material.color = colors[Random.Range(0,colors.Count)];
        CameraShake.color = Material.color;
    }

    private void OnDestroy()
    {
        GameObject effect = Instantiate(KillEffect);
        effect.transform.position = transform.position;
        Material.color = Color.white;
    }
}