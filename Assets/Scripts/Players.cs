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
        if (AlivePlayers == 1)
        {
            for (int i = 0; i < players.Count; i++)
            {
                string winner = "";
                if (!players[i].dead)
                {
                    winner = players[i].username;
                }

                Debug.Log(winner + " is the Winner");
            }
        }
    }
    
}
