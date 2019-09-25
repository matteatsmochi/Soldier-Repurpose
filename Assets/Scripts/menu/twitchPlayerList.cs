using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twitchPlayerList : MonoBehaviour
{
    public List<string> twitchPlayers;
    List<string> bots;

    void Start()
    {
        RefreshBotList();
    }

    public void AddBot()
    {
        if (bots.Count == 0)
        {
            RefreshBotList();
        }

        int rand = Random.Range(0, bots.Count);
        twitchPlayers.Add(bots[rand]);
        bots.RemoveAt(rand);
    }

    void RefreshBotList()
    {
        //bots.Add("Cua::0");
        //bots.Add("Izabela::0");
        //bots.Add("Linda::0");
        //bots.Add("Zora::0");
        //bots.Add("Yahweh::0");
        //bots.Add("Jozsef::0");
        //bots.Add("Fergus::0");
        //bots.Add("Kamil::0");
        //bots.Add("Irene::0");
        //bots.Add("Dovydas::0");
        //bots.Add("Borja::0");
        //bots.Add("Semyon::0");
        //bots.Add("Alekto::0");
        //bots.Add("Barnabas::0");
        //bots.Add("Agar::0");
        //bots.Add("Brygida::0");
        //bots.Add("Ioanna::0");
        //bots.Add("Finnagan::0");
        //bots.Add("Carles::0");
        //bots.Add("Helga::0");
        //bots.Add("Kallistos::0");
        //bots.Add("Melle::0");
        //bots.Add("Rene::0");
        //bots.Add("Evie::0");
    }

}
