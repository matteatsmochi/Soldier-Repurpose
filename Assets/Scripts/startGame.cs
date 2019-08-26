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
    

    bool AllSpawned = false;
    public List<GameObject> planes;
    
    void Awake()
    {
        players = playerManager.GetComponent<Players>();
        playersList = playerManager.GetComponent<PlayersList>();
    }
    
    void Start()
    {
        NewPlane();
    }
    
    void StartGame()
    {
        

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

        if (AllSpawned)
        {
            GameObject.Find("ZoneOn").GetComponent<zoneOn>().child.SetActive(true);
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
