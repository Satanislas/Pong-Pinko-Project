using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    public static GameObject cam;
    
    public float duration;
    public float shakePower;
    public float decreaseFactor;
    private Vector3 startingPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = cam.transform.position;
    }

    private void Update()
    {
        if (duration > 0)
        {
            cam.transform.localPosition = startingPosition + Random.insideUnitSphere * shakePower;
			
            duration -= Time.deltaTime;
            shakePower *= 1/decreaseFactor;
        }
        else
        {
            cam.transform.localPosition = startingPosition;
            Destroy(gameObject);
        }
    }
    
}
