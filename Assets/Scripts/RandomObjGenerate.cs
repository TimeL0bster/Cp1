using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjGenerate : MonoBehaviour
{

    private GameObject[] objSpawn;

    // Start is called before the first frame update
    void Start()
    {
        objSpawn = GameObject.FindGameObjectsWithTag("ObjRandomSpawner");
        foreach (GameObject rando in objSpawn)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObjects()
    {
       
    }

}
