using UnityEngine;

public class spin : MonoBehaviour
{
    float speed;
    int dir;
    
    void Start()
    {
        speed = Random.Range(10, 15);
        dir = Random.Range(0,2) * 2 - 1;
    }
    
    void Update()
    {
        transform.Rotate(Vector3.up, speed * dir * Time.deltaTime);
    }
}
