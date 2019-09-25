using UnityEngine;

public class WaypointValue : MonoBehaviour
{
    public bool destroyed = false;

    public float Val(Vector3 zoneCenter)
    {
        float a = 1000 - Vector3.Distance(transform.position, zoneCenter);
        return a;
    }
}
