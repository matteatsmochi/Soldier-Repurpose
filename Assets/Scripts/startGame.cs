using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    
    public GameObject playerManager;
    Players players;
    PlayersList playersList;
    
    public GameObject planePrefab;

    public List<GameObject> planeStart;

    public cameraController cc;
    

    bool AllSpawned = false;
    bool NotTwice = true;
    public List<GameObject> planes;
    
    void Awake()
    {
        players = playerManager.GetComponent<Players>();
        playersList = playerManager.GetComponent<PlayersList>();
    }
    
    void Start()
    {
        StartCoroutine(StartGame());
    }
    
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(5);
        NewPlane();
    }

    void NewPlane()
    {
        StartCoroutine(SpawnPlane());
    }



    IEnumerator SpawnPlane()
    {
        TwoPoints tp = GetPoints();
        GameObject plane = Instantiate(planePrefab, tp.point1.transform.position, Quaternion.identity);
        planes.Add(plane);
        plane.GetComponent<planeFly>().Setup(tp.point2.transform);
        if (cc.plane == null)
        {
            cc.plane = plane;
        }
            
        
        yield return new WaitForSeconds(10);
        

        if (playersList.joinedPlayers.Count == 0)
        {
            AllSpawned = true;
        }
        else
        {
            NewPlane();
        }
        
    }

    void Update()
    {
        if (planes.Count != 0)
        {
            for (int i = planes.Count - 1; i >= 0; i--)
            {
                if (planes[i] == null)
                {
                    planes.RemoveAt(i);
                }
            }
        }

        if (AllSpawned & NotTwice)
        {
            zoneOn ZoneOn = GameObject.Find("ZoneOn").GetComponent<zoneOn>();
            ZoneOn.child.SetActive(true);
            ZoneOn.CurViz.SetActive(true);
            ZoneOn.NextViz.SetActive(true);
            ZoneOn.on = true;
            NotTwice = false;
        }
    }

    TwoPoints GetPoints()
    {
        TwoPoints t = new TwoPoints();

Redo:
        t.point1 = planeStart[Random.Range(0,planeStart.Count)];
        t.point2 = planeStart[Random.Range(0,planeStart.Count)];

        if (t.point1.transform.position.x == t.point2.transform.position.x || t.point1.transform.position.z == t.point2.transform.position.z)
        {
            goto Redo;
        }
        
        return t;
    }
}


public class TwoPoints
{
    public GameObject point1;
    public GameObject point2;
}
