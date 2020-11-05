using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndiSlot : MonoBehaviour
{

    public int i;

    private Slots slots;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            slots.isFull[i] = false;
        }
    }

}
