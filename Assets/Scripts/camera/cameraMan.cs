using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMan : MonoBehaviour
{
    public float speed = 5;
    
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }
}
