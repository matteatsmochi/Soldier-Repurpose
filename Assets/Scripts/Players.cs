using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public int AlivePlayers = 8;
    public List<playerStats> players;

    
    public void PlayerDied()
    {
        AlivePlayers--;
        
        //if player that died is being spectated, look at who killed them

        if (AlivePlayers == 1)
        {
            string winner = "";
            for (int i = 0; i < players.Count; i++)
            {
                if (!players[i].dead)
                {
                    winner = players[i].username;
                }
            }
            Debug.Log(winner + " is the Winner");
            //winner animation
        }
    }

    public GameObject HighestScore()
    {
        GameObject n = new GameObject();
        float s = 0;
        for (int i = 0; i < players.Count; i++)
            {
                if (players[i].score > s)
                {
                    n = players[i].soldier;
                    s = players[i].score;
                }
            }
        return n;
    }

    public GameObject soldierObject(int index)
    {
        GameObject n = new GameObject();
        for (int i = 0; i < players.Count; i++)
            {
                if (players[i].index == index)
                {
                    n = players[i].soldier;
                }
            }

        return n;
    }
    
}
