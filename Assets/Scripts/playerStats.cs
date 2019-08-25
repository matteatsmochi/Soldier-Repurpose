using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerStats
{
    public string username = "";
    public int index;

    public GameObject soldier;
    
    public int kills = 0;
    public float damage = 0;
    public bool dead = false;

}
