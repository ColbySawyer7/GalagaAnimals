using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRangex = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = .5f;

    public GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPrefab", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.S)){
            SpawnRandomPrefab();
        }*/

        
    }

    void SpawnRandomPrefab(){
        int prefabIndex = Random.Range(0,prefabs.Length-1);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangex,spawnRangex + 1),0,spawnPosZ);
        Instantiate(prefabs[prefabIndex], spawnPos, prefabs[prefabIndex].transform.rotation);
    }
}
