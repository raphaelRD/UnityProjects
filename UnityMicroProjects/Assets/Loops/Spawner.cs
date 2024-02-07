using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
 public GameObject spawnPreFab;
 public int spawnCount = 5;
 public float spawnOffSet = 1.5f;

 void Start()
 {
    if (spawnPreFab != null)
    {
        spawnEnemies();
    }
    else
    {
        Debug.LogError("PreFab missing");
    }

 }

 void spawnEnemies()
 {
    for(int i = 0; i < spawnCount ; i++)
    {
        float xPos = i * spawnOffSet;
        Vector3 spawnPos = new Vector3(xPos,0,0);
        Instantiate(spawnPreFab,spawnPos, Quaternion.identity);
    }


 }
}
