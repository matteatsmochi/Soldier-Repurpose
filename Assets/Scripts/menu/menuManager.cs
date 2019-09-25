using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class menuManager : MonoBehaviour
{
    public joinedSpawner js;
    public TwitchAPI api;
    public twitchPlayerList playerList;
    public TMP_InputField channelIF;

    public void ifChannelTextChange(string str)
    {
        PlayerPrefs.SetString("channel", str);
        api.AssignChannel(str);
    }

    public void AddPlayer(string username, string userID)
    {
        if (playerList.twitchPlayers.Count > 0)
        {
            bool alreadyJoined = false;
            for (int i = 0; i < playerList.twitchPlayers.Count; i++)
            {
                if (username + "::" + userID == playerList.twitchPlayers[i])
                {
                    alreadyJoined = true;
                }
            }

            if (!alreadyJoined)
            {
                playerList.twitchPlayers.Add(username + "::" + userID);
                js.PlayerJoined(username);
            }
        }
        else
        {
            playerList.twitchPlayers.Add(username + "::" + userID);
            js.PlayerJoined(username);
        }
    }

    void Start()
    {
        channelIF.text = PlayerPrefs.GetString("channel", "");
    }
}
