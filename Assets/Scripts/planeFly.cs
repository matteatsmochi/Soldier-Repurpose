using UnityEngine;

public class planeFly : MonoBehaviour
{
    public float speed = 20f;
    Transform target = null;
    
    public void Setup(Transform t)
    {
        target = t;
        transform.LookAt(t);
    }
    
    void Update()
    {
        if (target != null)
        {
            float step =  speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

        if (Vector3.Distance(transform.position,target.position) < 1)
        {
            Destroy(gameObject);
        }
    }
}
