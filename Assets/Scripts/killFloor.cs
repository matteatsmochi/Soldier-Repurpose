using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        GameObject g = collision.gameObject;
        var health = g.GetComponent<newHealth>();
        var damage = 100;

        if (health != null)
        {
            health.Impact(damage, Vector3.zero, Vector3.zero, 101);
        }
    }
}
