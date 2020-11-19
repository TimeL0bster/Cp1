using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniObjectPool : MonoBehaviour
{

    public static MiniObjectPool SharedInstance;
    public GameObject[] objectToPool;
    public int amountToPool;

    private Slots slots;
    private List<GameObject> pooledObject1;
    private List<GameObject> pooledObject2;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();

        pooledObject1 = SetPoolObject1();
        pooledObject2 = SetPoolObject2();

    }

    public List<GameObject> SetPoolObject1()
    {
        List<GameObject> pooledObject1 = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj1 = Instantiate(objectToPool[0], slots.slots[i].transform, false);
            obj1.SetActive(false);
            pooledObject1.Add(obj1);
        }

        return pooledObject1;
    }

    public List<GameObject> SetPoolObject2()
    {
        List<GameObject> pooledObject2 = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj2 = Instantiate(objectToPool[1], slots.slots[i].transform, false);
            obj2.SetActive(false);
            pooledObject2.Add(obj2);
        }

        return pooledObject2;
    }

    public GameObject GetPooledObject1()
    {
        for (int i = 0; i < 7; i++)
        {
            if (slots.isFull[i] == false)
            {
                return pooledObject1[i];
            }

        }

        return null;
    }

    public GameObject GetPooledObject2()
    {
        for (int i = 0; i < 7; i++)
        {
            if (slots.isFull[i] == false)
            {

                return pooledObject2[i];

            }

        }

        return null;
    }

}
