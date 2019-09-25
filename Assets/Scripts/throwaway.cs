using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoolBattleRoyaleZone;

public class throwaway : MonoBehaviour
{
    
    void Start()
    {
        //Debug.Log(ParseUserID("matteatsmochi::12345"));
        
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