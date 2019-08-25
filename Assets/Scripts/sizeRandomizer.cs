using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeRandomizer : MonoBehaviour
{
    //random variation on scale on rotation
    void Start()
    {
        float randScale = Random.Range(0.5f, 0.7f);
        float randRotation = Random.Range(0f, 360f);
        transform.localScale = new Vector3(transform.localScale.x * randScale, transform.localScale.y * randScale, transform.localScale.z * randScale);
        transform.eulerAngles = new Vector3(0, randRotation, 0);
    }
}
