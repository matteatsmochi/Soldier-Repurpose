using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public List<GameObject> waypoints;

    public Vector3 zoneCenter;
    
    void Start()
    {
        RefreshWaypoints();
    }


    public void RefreshWaypoints()
    {
        waypoints.Clear();
        int children = transform.childCount;
        for (int i = 0; i < children; i++)
        {
            waypoints.Add(transform.GetChild(i).gameObject);
        }
    }

    public wp NextDest(float curVal)
    {
        wp temp = new wp();
        
        
        int rnd = Random.Range(0, waypoints.Count);
        if (waypoints[rnd] && waypoints[rnd].GetComponent<WaypointValue>().Val(zoneCenter) > curVal)
        {
            temp.waypoint = waypoints[rnd];
            temp.value = waypoints[rnd].GetComponent<WaypointValue>().Val(zoneCenter);
        }
        
        return temp;
    }
}
