using UnityEngine;

public class WaypointValue : MonoBehaviour
{
    public float Val(Vector3 zoneCenter)
    {
        float a = 1000 - Vector3.Distance(transform.position, zoneCenter);
        Debug.Log(a);
        return a;
    }
}
