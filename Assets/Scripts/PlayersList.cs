using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersList : MonoBehaviour
{
    
    public List<string> joinedPlayers;
    twitchPlayerList tpl;

    void Awake()
    {
        tpl = GameObject.Find("Twitch API").GetComponent<twitchPlayerList>();
    }

    void Start()
    {
        for (int i = 0; i < tpl.twitchPlayers.Count; i++)
        {
            joinedPlayers.Add(tpl.twitchPlayers[i]);
        }

        Shuffle();
    }

    
    public void Shuffle()
    {  
        for (int i = 0; i < joinedPlayers.Count; i++)
        {
            string temp = joinedPlayers[i];
            int randomIndex = Random.Range(i, joinedPlayers.Count);
            joinedPlayers[i] = joinedPlayers[randomIndex];
            joinedPlayers[randomIndex] = temp;
        }
    }
}