using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    public static GameObject cam;
    
    public float shakeDuration;
    public float shakePower;
    public float decreaseFactor;

    private float shakeTimer;
    private Vector3 startingPosition;
    public Material mat;
    public static Color color = Color.white;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = cam.transform.position;
        shakeTimer = shakeDuration;
        mat.color = color;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            cam.transform.localPosition = startingPosition + Random.insideUnitSphere * shakePower;
			
            shakeDuration -= Time.deltaTime;
            shakePower *= 1/decreaseFactor;
        }
        else
        {
            cam.transform.localPosition = startingPosition;
            mat.color = Color.white;
            color = Color.white;
            Destroy(gameObject);
        }
    }
    
}
