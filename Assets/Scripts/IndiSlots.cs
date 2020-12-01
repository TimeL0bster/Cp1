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

                if (transform.childCount > 0 && GameObject.FindGameObjectWithTag("Slot2").transform.childCount > 0)
                {
                    if (transform.GetChild(0).transform.GetComponent<Image>().sprite == GameObject.FindGameObjectWithTag("Slot2").transform.GetChild(0).GetComponent<Image>().sprite)
                    {
                        if (transform.childCount > 0 && GameObject.FindGameObjectWithTag("Slot3").transform.childCount > 0)
                        {

                            if (transform.GetChild(0).transform.GetComponent<Image>().sprite != GameObject.FindGameObjectWithTag("Slot3").transform.GetChild(0).GetComponent<Image>().sprite)
                            {
                                for (int i = 0; i < otherSlots.Length; i++)
                                {
                                    if (transform.childCount > 0 && otherSlots[i].transform.childCount > 0)
                                    {
                                        if (transform.GetChild(0).transform.GetComponent<Image>().sprite == otherSlots[i].transform.GetChild(0).GetComponent<Image>().sprite)
                                        {
                                            StartCoroutine(MovePos(otherSlots[i].transform.GetChild(0).transform, slots.tempoSlots[2].transform));
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        if (transform.childCount > 0 && GameObject.FindGameObjectWithTag("Slot3").transform.childCount > 0)
                        {

                            if (transform.GetChild(0).transform.GetComponent<Image>().sprite == GameObject.FindGameObjectWithTag("Slot3").transform.GetChild(0).GetComponent<Image>().sprite)
                            {
                                StartCoroutine(MovePos(GameObject.FindGameObjectWithTag("Slot3").transform.GetChild(0).transform, slots.tempoSlots[1].transform));
                            }
                            else
                            {
                                for (int i = 0; i < otherSlots.Length; i++)
                                {
                                    if (transform.childCount > 0 && otherSlots[i].transform.childCount > 0)
                                    {
                                        if (transform.GetChild(0).transform.GetComponent<Image>().sprite == otherSlots[i].transform.GetChild(0).GetComponent<Image>().sprite)
                                        {
                                            StartCoroutine(MovePos(otherSlots[i].transform.GetChild(0).transform, slots.tempoSlots[1].transform));
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                }

                

                break;

            case "Slot2":

                for (int i = 0; i < otherSlots.Length; i++)
                {
                    if (transform.childCount > 0 && otherSlots[i].transform.childCount > 0)
                    {
                        if (transform.GetChild(0).transform.GetComponent<Image>().sprite == otherSlots[i].transform.GetChild(0).GetComponent<Image>().sprite)
                        {
                            Debug.Log("Match2");
                            break;
                        }
                    }
                }

                //Debug.Log("Name:" + transform.name);
                break;

            case "Slot3":

                /*for (int i = 0; i < otherSlots.Length; i++)
                {
                    if (transform.childCount > 0 && otherSlots[i].transform.childCount > 0)
                    {
                        if (transform.GetChild(0).transform.GetComponent<Image>().sprite == otherSlots[i].transform.GetChild(0).GetComponent<Image>().sprite)
                        {
                            Debug.Log("Match3");
                            break;
                        }
                    }
                }*/

                //Debug.Log("Name:" + transform.name);
                break;

            case "Slot4":

                //Debug.Log("Name:" + transform.name);
                break;

            case "Slot5":

                //Debug.Log("Name:" + transform.name);
                break;

            case "Slot6":

                //Debug.Log("Name:" + transform.name);
                break;

        }

    }

    IEnumerator MovePos(Transform pos1,Transform pos2)
    {

        float f = 0;

        while (f < 1)
        {
            f += Time.deltaTime / 10;
            pos1.position = Vector3.Lerp(pos1.position, pos2.position, f);
            yield return 0;
        }

    }

}
