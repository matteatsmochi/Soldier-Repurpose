using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersList : MonoBehaviour
{
    public List<string> joinedPlayers;

    void Start()
    {
        joinedPlayers.Add("Cua");
        joinedPlayers.Add("Izabela");
        joinedPlayers.Add("Linda");
        joinedPlayers.Add("Zora");
        joinedPlayers.Add("Yahweh");
        joinedPlayers.Add("Jozsef");
        joinedPlayers.Add("Fergus");
        joinedPlayers.Add("Kamil");
        joinedPlayers.Add("Irene");
        joinedPlayers.Add("Dovydas");
        joinedPlayers.Add("Borja");
        joinedPlayers.Add("Semyon");
        joinedPlayers.Add("Alekto");
        joinedPlayers.Add("Barnabas");
        joinedPlayers.Add("Agar");
        joinedPlayers.Add("Brygida");
        joinedPlayers.Add("Ioanna");
        joinedPlayers.Add("Finnagan");
        joinedPlayers.Add("Carles");
        joinedPlayers.Add("Helga");
        joinedPlayers.Add("Kallistos");
        joinedPlayers.Add("Melle");
        joinedPlayers.Add("Rene");
        joinedPlayers.Add("Evie");
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
