using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CameraShake.cam = this.gameObject;
    }
}
