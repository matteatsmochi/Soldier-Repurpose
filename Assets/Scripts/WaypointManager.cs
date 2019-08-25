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

    public GameObject NextDest(GameObject current)
    {
        GameObject nextDest = current;
        GameObject nextBest = current;
        float score = nextDest.GetComponent<WaypointValue>().Val(zoneCenter);
        
        for (int i = 0; i < waypoints.Count; i++)
        {
            if (waypoints[i])
            {
                float s = waypoints[i].GetComponent<WaypointValue>().Val(zoneCenter);
                if (s > score)
                {
                    nextBest = nextDest;
                    nextDest = waypoints[i];
                    score = s;
                }
            }
        }

        if (current.transform.position == nextDest.transform.position)
        {
            nextDest = nextBest;
        }

        return nextDest;
    }
}
