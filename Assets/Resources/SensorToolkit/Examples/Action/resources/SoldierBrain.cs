using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SensorToolkit.Example;

public class SoldierBrain : MonoBehaviour
{
    
    public playerStats stats;
    public GameObject parachute;
    public int teamMat;

    bool falling = true;
    Vector3 stuck = new Vector3(0,0,0);
    Rigidbody rb;
    SoldierAI ai;
    Players playerManager;
    Killfeed killfeed;

    
    
    void Awake()
    {
        teamMat = Random.Range(0,10);
        GetComponent<TeamMember>().matIndex = teamMat;
        rb = GetComponent<Rigidbody>();
        ai = GetComponent<SoldierAI>();
        playerManager = GameObject.Find("Player Manager").GetComponent<Players>();
        killfeed = GameObject.Find("Killfeed").GetComponent<Killfeed>();
    }

    void Start()
    {
        rb.mass = 5;
    }


    void Update()
    {
        if (falling)
        {
            if (transform.position.y < 3)
            {
                DropPlayer();
            }
        }
        
    }

    void FixedUpdate()
    {
        if (falling)
        {
            if (stuck == transform.position)
            {
                Debug.Log("Stuck: " + stuck + " & Pos: " + transform.position);
                DropPlayer();
            }
            stuck = transform.position;
        }
    }

    void DropPlayer()
    {
        rb.mass = 60;
        Destroy(parachute);
        falling = false;
        ai.enabled = true;
    }

    public void ImDead(int fromIndex)
    {
        string myUsername = "";
        string killerUsername = "The Zone";
        
        for (int i = 0; i < playerManager.players.Count; i++)
        {
            if (i == stats.index)
            {
                playerManager.players[i].dead = true;
                myUsername = playerManager.players[i].username;
            }

            if (i == fromIndex)
            {
                playerManager.players[i].kills++;
                killerUsername = playerManager.players[i].username;
            }
        }

        

        Debug.Log(killerUsername + " killed " + myUsername);
        killfeed.SpawnKillfeedItem(killerUsername, myUsername);
        playerManager.PlayerDied();
    }



    

}
