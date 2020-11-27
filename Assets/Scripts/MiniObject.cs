using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MiniObject : MonoBehaviour
{

    public Sprite[] miniObjectSprite;

    protected Image img;

    // Start is called before the first frame update
    public void Start()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        detechAdjacientSlot();
    }

    public void detechAdjacientSlot()
    {

        switch (this.gameObject.transform.parent.tag)
        {
            case "Slot1":
                Debug.Log(this.gameObject.name + "at Slot1");
                break;
            case "Slot2":
                Debug.Log(this.gameObject.name + "at Slot2");
                break;
            case "Slot3":
                Debug.Log(this.gameObject.name + "at Slot3");
                break;
            case "Slot4":
                Debug.Log(this.gameObject.name + "at Slot4");
                break;
            case "Slot5":
                Debug.Log(this.gameObject.name + "at Slot5");
                break;
            case "Slot6":
                Debug.Log(this.gameObject.name + "at Slot6");
                break;
            case "Slot7":
                Debug.Log(this.gameObject.name + "at Slot7");
                break;
        }

    }

    protected void SwitchObjectPosition()
    {
        
    }

}
