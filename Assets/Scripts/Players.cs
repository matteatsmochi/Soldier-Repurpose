using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public int AlivePlayers = 0;
    public List<playerStats> players;

    public cameraController cam;
    public HUDConroller hud;

    public AlivePlayerCount aliveCount;
    public bool GameOver = false;

    void Awake()
    {
        
    }

    
    public void PlayerDied(int deadIndex, int killerIndex)
    {
        AlivePlayers--;
        aliveCount.SetPlayerCount(AlivePlayers.ToString());

        cam.PlayerDiedCheckCurrent(deadIndex, killerIndex);
        if (killerIndex < 101)
        {
            hud.NewKill(killerIndex, players[killerIndex].kills);
        }

        players[deadIndex].score = -100;


        if (AlivePlayers == 1)
        {
            int lastAlive = 0;
            for (int i = 0; i < players.Count; i++)
            {
                if (!players[i].dead)
                    lastAlive = i;
            }

            Debug.Log(players[lastAlive].username + " is the Winner");
            cam.ForceChangeFocus(players[lastAlive].soldier, players[lastAlive].username, players[lastAlive].userID, players[lastAlive].index);
            GameOver = true;
            //winner animation

            StartCoroutine(BackToMenu());
        }
    }

    public int HighestScore()
    {
        int n = 0;
        float s = -1;
        for (int i = 0; i < players.Count; i++)
            {
                if (players[i].score > s)
                {
                    n = players[i].index;
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

    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(5);
        GameObject.Find("SceneManager").GetComponent<sceneManager>().LoadS(0);
    }
    
}
