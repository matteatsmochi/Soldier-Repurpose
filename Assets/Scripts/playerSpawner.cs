using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerManager;
    Players players;
    PlayersList playersList;

    RaycastHit hit;
    float Reach = 50;

    bool aboveGround = false;


    void Awake()
    {
        playerManager = GameObject.Find("Player Manager");
        players = playerManager.GetComponent<Players>();
        playersList = playerManager.GetComponent<PlayersList>();
    }

    void Start()
    {
        SpawnPlayer();
    }
    

    public void SpawnPlayer()
    {
        bool seeGround = Physics.Raycast (transform.position, Vector3.down, out hit, Reach) && hit.transform.tag == "ground";

        if (aboveGround && seeGround)
        {
            if (playersList.joinedPlayers.Count > 0)
            {
                playerStats stats = new playerStats();
                stats.username = ParseUsername(playersList.joinedPlayers[0]);
                stats.userID = ParseUserID(playersList.joinedPlayers[0]);
                playersList.joinedPlayers.RemoveAt(0);
                
                GameObject soldier = Instantiate(playerPrefab, transform);
                soldier.transform.parent = playerManager.transform;
                stats.soldier = soldier;
                stats.index = players.players.Count;

                players.players.Add(stats);
                players.AlivePlayers++;

                SoldierBrain brain = soldier.GetComponent<SoldierBrain>();
                brain.stats.username = stats.username;
                brain.stats.userID = stats.userID;
                brain.stats.index = stats.index;
                brain.stats.soldier = soldier;
                brain.healthBar.username = stats.username;
            }
        }
        else if (seeGround)
        {
            aboveGround = true;
        }
        else
        {
            aboveGround = false;
        }
        
        
        StartCoroutine(SpawnWait());
    }

    IEnumerator SpawnWait()
    {
        yield return new WaitForSeconds(Random.Range(1,3));
        SpawnPlayer();
    }

    string ParseUsername(string full)
    {
        int split = full.IndexOf("::");
        return full.Substring(0, split);
    }

string ParseUserID(string full)
    {
        int split = full.IndexOf("::");
        return full.Substring(split + 2, full.Length - split - 2);
    }

    
}
