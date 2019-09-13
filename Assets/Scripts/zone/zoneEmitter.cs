using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoolBattleRoyaleZone;
using DG.Tweening;


public class zoneEmitter : MonoBehaviour
{
    GameObject cam;
    Zone zone;
    float radius;
    bool shrinking = false;
    Vector3 center;
    
    void Awake()
    {
        cam = GameObject.Find("Main Camera");
        zone = Zone.Instance;
    }

    void Start()
    {
        radius = zone.ZoneCircles[0].PositionAndRadius.Radius;
        center = zone.ZoneCircles[0].PositionAndRadius.Position;
    }

    
    void Update()
    {
        Vector3 heading = cam.transform.position - zone.ZoneCircles[zone.CurStep].PositionAndRadius.Position;
        
        if (!shrinking && zone.IsShrinking)
        {
            StartCoroutine(Shrink(zone.ZoneCircles[zone.CurStep].ShrinkingTime, zone.ZoneCircles[zone.CurStep + 1].PositionAndRadius.Radius, zone.ZoneCircles[zone.CurStep + 1].PositionAndRadius.Position));
            shrinking = true;
        }

        Vector3 pos = (heading.normalized * radius) + center;
        transform.position = new Vector3(pos.x, 25, pos.z);
        
    }

    IEnumerator Shrink(float duration, float size, Vector3 middle)
    {
        DOTween.To(()=> radius, x=> radius = x, size, duration).SetEase(Ease.Linear);
        DOTween.To(()=> center, x=> center = x, middle, duration).SetEase(Ease.Linear);
        yield return new WaitForSeconds(duration);
        shrinking = false;
    }
}
