using UnityEngine;

public class planePropeller : MonoBehaviour
{
    float speed;
    int dir;
    
    void Start()
    {
        speed = 2000;
    }
    
    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
