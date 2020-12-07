using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjGenerate : MonoBehaviour
{

    public GameObject[] objects;

    private GameObject[] objSpawn;

    // Start is called before the first frame update
    void Start()
    {

        objSpawn = GameObject.FindGameObjectsWithTag("ObjRandomSpawner");

        Debug.Log(GameObject.FindGameObjectsWithTag("Object1").Length);
        Debug.Log(GameObject.FindGameObjectsWithTag("Object2").Length);
        Debug.Log(GameObject.FindGameObjectsWithTag("Object3").Length);
        Debug.Log(GameObject.FindGameObjectsWithTag("Object4").Length);

        /*if (numCheck < 1)
        {
            for (int i = 0; i < 96; i++)
            {
                int a = Random.Range(i, objSpawn.Length);

                if (GameObject.FindGameObjectsWithTag("Object1").Length <= 24)
                {
                    if (objSpawn[a].transform.childCount <= 0)
                    {
                        Instantiate(objects[0], objSpawn[a].transform);
                    }
                }
            }

            for (int i = 0; i < 96; i++)
            {
                int a = Random.Range(i, objSpawn.Length);

                if (GameObject.FindGameObjectsWithTag("Object2").Length <= 24)
                {
                    if (objSpawn[a].transform.childCount <= 0)
                    {
                        Instantiate(objects[1], objSpawn[a].transform);
                    }
                }
            }

            for (int i = 0; i < 96; i++)
            {
                int a = Random.Range(i, objSpawn.Length);

                if (GameObject.FindGameObjectsWithTag("Object3").Length <= 24)
                {
                    if (objSpawn[a].transform.childCount <= 0)
                    {
                        Instantiate(objects[2], objSpawn[a].transform);
                    }
                }
            }

            for (int i = 0; i < 96; i++)
            {
                int a = Random.Range(i, objSpawn.Length);

                if (GameObject.FindGameObjectsWithTag("Object4").Length <= 24)
                {
                    if (objSpawn[a].transform.childCount <= 0)
                    {
                        Instantiate(objects[3], objSpawn[a].transform);
                    }
                }
            }

        }*/

    }

}
