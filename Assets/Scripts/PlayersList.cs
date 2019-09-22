using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersList : MonoBehaviour
{
    
    public List<string> joinedPlayers;

    void Start()
    {
        joinedPlayers.Add("Cua::12345");
        joinedPlayers.Add("Izabela::12345");
        joinedPlayers.Add("Linda::12345");
        joinedPlayers.Add("Zora::12345");
        joinedPlayers.Add("Yahweh::12345");
        joinedPlayers.Add("Jozsef::12345");
        joinedPlayers.Add("Fergus::12345");
        joinedPlayers.Add("Kamil::12345");
        joinedPlayers.Add("Irene::12345");
        joinedPlayers.Add("Dovydas::12345");
        joinedPlayers.Add("Borja::12345");
        joinedPlayers.Add("Semyon::12345");
        joinedPlayers.Add("Alekto::12345");
        joinedPlayers.Add("Barnabas::12345");
        joinedPlayers.Add("Agar::12345");
        joinedPlayers.Add("Brygida::12345");
        joinedPlayers.Add("Ioanna::12345");
        joinedPlayers.Add("Finnagan::12345");
        joinedPlayers.Add("Carles::12345");
        joinedPlayers.Add("Helga::12345");
        joinedPlayers.Add("Kallistos::12345");
        joinedPlayers.Add("Melle::12345");
        joinedPlayers.Add("Rene::12345");
        joinedPlayers.Add("Evie::12345");
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