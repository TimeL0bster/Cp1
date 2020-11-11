using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniObjectPool : MonoBehaviour
{

    public static MiniObjectPool SharedInstance;
    public GameObject objectToPool;
    public int amountToPool;

    private Slots slots;
    private List<GameObject> pooledObject;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObject = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObject.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObject.Count;i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                return pooledObject[i];
            }
        }

        return null;
    }

}
