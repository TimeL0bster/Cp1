using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndiSlots : MonoBehaviour
{

    public int i;
    public GameObject[] otherSlots;
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

        switch (gameObject.tag)
        {
            case "Slot1":

                if (transform.GetChild(0).transform.GetComponent<Image>().sprite == otherSlots[1].transform.GetChild(0).GetComponent<Image>().sprite)
                {
                    Debug.Log("Match1");
                }
                break;

            case "Slot2":

                Debug.Log("Name:" + transform.name);
                break;

            case "Slot3":

                Debug.Log("Name:" + transform.name);
                break;

            case "Slot4":

                Debug.Log("Name:" + transform.name);
                break;

            case "Slot5":

                Debug.Log("Name:" + transform.name);
                break;

            case "Slot6":

                Debug.Log("Name:" + transform.name);
                break;

            case "Slot7":

                Debug.Log("Name:" + transform.name);
                break;

        }

    }

}
