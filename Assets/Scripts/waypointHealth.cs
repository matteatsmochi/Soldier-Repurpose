using UnityEngine;

public class waypointHealth : MonoBehaviour
{
    public bool zoneExists = false;
    float wait = 2f;

    public Vector3 p;
    public float r;

    void Update ( )
    {
        if (wait <= 0)
        {
            wait = 2;
            CheckZone();
        }
        else
        {
            wait -= Time.deltaTime;
        }
    }

    void CheckZone()
    {
        if (zoneExists)
        {
            // Getting zone current safe zone values
            //var zonePos = Zone.Instance.CurrentSafeZone.Position;
            //var zoneRadius = Zone.Instance.CurrentSafeZone.Radius;
            // Checking distance between player and circle
            var dstToZone = Vector3.Distance (new Vector3 (transform.position.x, p.y, transform.position.z), p);
            // Checking if we inner of circle or not by radius and if not, start applying damage to health
            //if (dstToZone > r) gameObject.GetComponent<WaypointValue>().destroyed = true;
            if (dstToZone > r) Destroy(gameObject);
        }
    }
}
