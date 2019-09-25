using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoolBattleRoyaleZone;

public class WaypointManager : MonoBehaviour
{
    public List<GameObject> waypoints;

    public Vector3 zoneCenter;
    bool zoneExists = false;
    float wait = 2f;

    public GameObject zoneCenterGO;
    
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
        int finiteLoops = 0;

    badPoint:
        int rnd = Random.Range(0, waypoints.Count);

        if (waypoints[rnd] && waypoints[rnd].GetComponent<WaypointValue>().Val(zoneCenter) > curVal)
        {
            temp.waypoint = waypoints[rnd];
            temp.value = waypoints[rnd].GetComponent<WaypointValue>().Val(zoneCenter);
        }
        else
        {
            if (finiteLoops > 20)
            {
                Debug.Log("Way Too Many Loops");
                temp.waypoint = zoneCenterGO;
                temp.value = 100;
            }
            else
            {
                finiteLoops++;
                goto badPoint;
            }
            
        }
        
        return temp;
    }

    
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
            var zonePos = Zone.Instance.CurrentSafeZone.Position;
            var zoneRadius = Zone.Instance.CurrentSafeZone.Radius;
            // Checking distance between player and circle
            var dstToZone = Vector3.Distance (new Vector3 (transform.position.x, zonePos.y, transform.position.z), zonePos);
            // Send info to children
            for (int i = 0; i < transform.childCount; i++)
            {
                waypointHealth wh = transform.GetChild(i).gameObject.GetComponent<waypointHealth>();
                wh.p = zonePos;
                wh.r = zoneRadius;
            }

            zoneCenterGO.transform.position = zonePos;
            
        }
        else
        {
            if (GameObject.Find("ZonePrefab"))
            {
                zoneExists = true;
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.GetComponent<waypointHealth>().zoneExists = true;
                    CheckZone();
                }
            }
            
        }
    }
}
