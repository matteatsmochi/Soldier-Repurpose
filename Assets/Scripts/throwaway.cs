using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoolBattleRoyaleZone;

public class throwaway : MonoBehaviour
{
    
    public Zone zone;
    
    void Start()
    {
        StartCoroutine(DelayedStart());
        
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < zone.ZoneCircles.Count; i++)
        {
            Debug.Log(zone.ZoneCircles[i].PositionAndRadius.Position);
        }
        transform.position = zone.ZoneCircles[7].PositionAndRadius.Position;
    }


}