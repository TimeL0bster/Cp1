using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndiSlots : MonoBehaviour
{

    public int i;
    public GameObject[] previousSlots;
    public GameObject[] miniObj;

    private Slots slots;
    private GameObject thisChild;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        if (transform.childCount <= 0)
        {
            slots.isFull[i] = false;
        }

    }

}
