using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassSpawner : MonoBehaviour
{
    public GameObject[] grassPrefab;
    
    
    void Start()
    {
        for (int i = 0; i < Random.Range(20, 30); i++)
        {
            GameObject tempGrass = Instantiate(grassPrefab[Random.Range(0, 2)], new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y, transform.position.z + Random.Range(-10, 10)), Quaternion.identity);
            tempGrass.transform.localScale *= 0.2f; 
            tempGrass.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            
        }

        for (int i = 0; i < Random.Range(5, 8); i++)
        {
            GameObject tempFlower = Instantiate(grassPrefab[Random.Range(3, 10)], new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y, transform.position.z + Random.Range(-10, 10)), Quaternion.identity);
            tempFlower.transform.localScale *= 0.3f; 
            tempFlower.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            
        }

        for (int i = 0; i < Random.Range(1, 8); i++)
        {
            GameObject tempBush = Instantiate(grassPrefab[Random.Range(11, 16)], new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y, transform.position.z + Random.Range(-10, 10)), Quaternion.identity);
            tempBush.transform.localScale *= 0.3f; 
            tempBush.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
            
        }
    }


}
