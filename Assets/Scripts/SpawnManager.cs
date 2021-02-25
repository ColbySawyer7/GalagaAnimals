using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRangex = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    public GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.S)){
            SpawnRandomAnimal();
        }*/

        
    }

    void SpawnRandomAnimal(){
        int animalIndex = Random.Range(0,prefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangex,spawnRangex + 1),0,spawnPosZ);
        Instantiate(prefabs[animalIndex], spawnPos, prefabs[animalIndex].transform.rotation);
    }
}
