using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneEmitterSpawner : MonoBehaviour
{
    public GameObject emitterPrefab;
    public int totalEmitters = 40;
    public float radius = 300;
    public int MaxHealth;
    public int MinHealth;

    void Start()
    {
        int h = MaxHealth;
        float deltaTheta = (2f * Mathf.PI) / totalEmitters;
        float theta = 0f;

        for (int i = 0; i < totalEmitters; i++)
        {
            GameObject e = Instantiate(emitterPrefab, this.transform);
            
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), transform.position.y, radius * Mathf.Sin(theta));
            e.transform.position = pos;

            theta += deltaTheta;
            
            
            e.GetComponent<zoneEmitterHealth>().MaxHP = h;
            h--;
            if (h < MinHealth) h = MaxHealth;
                
        }
    }

    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        float deltaTheta = (2f * Mathf.PI) / totalEmitters;
        float theta = 0f;

        Vector3 oldPos = transform.position;

        for (int i = 0; i < totalEmitters; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), transform.position.y, radius * Mathf.Sin(theta));
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;

            theta += deltaTheta;
        }
    }

    #endif

}
