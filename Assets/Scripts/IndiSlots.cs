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
    bool check;

    // Start is called before the first frame update
    private void Start()
    {
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        check = true;

    }

    // Update is called once per frame
    private void Update()
    {

        if (transform.childCount <= 0)
        {
            slots.isFull[i] = false;
        }
        if (check)
        {
            PosSwtch();
        }


    }


    private void PosSwtch()
    {
        switch (gameObject.tag)
        {
            case "Slot1":

                /*for (int i = 2; i < 7;i++)
                {
                    if (transform.childCount > 0 && slots.tempoUISlots[i].transform.childCount > 0)
                    {
                        
                        if (slots.tempoUISlots[1].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[i - 1].transform.GetChild(0).GetComponent<Image>().sprite)
                        {
                            if (transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[i].transform.GetChild(0).GetComponent<Image>().sprite)
                            {
                                Debug.Log(1);
                                StartCoroutine(MovePos(slots.tempoUISlots[i].transform.GetChild(0).transform, slots.tempoUISlots[i-1].transform));
                                StartCoroutine(MovePos(slots.tempoUISlots[i-1].transform.GetChild(0).transform, slots.tempoUISlots[i].transform));
                            }
                            else
                            {
                                
                            }
                        }
                    }
                }*/

                if (transform.childCount > 0)
                {
                    if (slots.tempoUISlots[1].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite)
                    {

                        List<GameObject> diffObj = new List<GameObject>();
                        diffObj.Add(slots.tempoUISlots[1].transform.GetChild(0).gameObject);

                        if (slots.tempoUISlots[2].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite)
                        {
                            break;
                        }
                        else if(slots.tempoUISlots[3].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite)
                        {

                            diffObj.Add(slots.tempoUISlots[2].transform.GetChild(0).gameObject);

                            if (slots.tempoUISlots[3].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                /*StartCoroutine(MovePos(GameObject.FindGameObjectWithTag("Slot3").transform.GetChild(0).transform, slots.tempoUISlots[3].transform));
                                StartCoroutine(MovePos(GameObject.FindGameObjectWithTag("Slot4").transform.GetChild(0).transform, slots.tempoUISlots[2].transform));
                                GameObject.FindGameObjectWithTag("Slot4").transform.GetChild(0).transform.SetParent(slots.tempoUISlots[2].transform);
                                GameObject.FindGameObjectWithTag("Slot3").transform.GetChild(0).transform.SetParent(slots.tempoUISlots[3].transform);*/

                                for (int i = 0; i < diffObj.Count; i++)
                                {
                                    StartCoroutine(MovePos(diffObj[i].gameObject.transform, slots.tempoUISlots[3].transform));
                                }

                                break;
                            }
                            else if(slots.tempoUISlots[3].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite)
                            {
                                diffObj.Add(slots.tempoUISlots[3].transform.GetChild(0).gameObject);
                            }

                        }


                    }
                    /*else if (transform.GetChild(0).transform.GetComponent<Image>().sprite != GameObject.FindGameObjectWithTag("Slot2").transform.GetChild(0).GetComponent<Image>().sprite)
                    {

                        if (GameObject.FindGameObjectWithTag("Slot3").transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == GameObject.FindGameObjectWithTag("Slot3").transform.GetChild(0).GetComponent<Image>().sprite)
                        {

                            StartCoroutine(MovePos(GameObject.FindGameObjectWithTag("Slot2").transform.GetChild(0).transform, slots.tempoUISlots[2].transform));
                            StartCoroutine(MovePos(GameObject.FindGameObjectWithTag("Slot3").transform.GetChild(0).transform, slots.tempoUISlots[1].transform));
                            GameObject.FindGameObjectWithTag("Slot2").transform.GetChild(0).transform.SetParent(slots.tempoUISlots[2].transform);
                            GameObject.FindGameObjectWithTag("Slot3").transform.GetChild(0).transform.SetParent(slots.tempoUISlots[1].transform);
                            break;
                        }
                        else
                        {
                            if (GameObject.FindGameObjectWithTag("Slot4").transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == GameObject.FindGameObjectWithTag("Slot4").transform.GetChild(0).GetComponent<Image>().sprite)
                            {
                                StartCoroutine(MovePos(GameObject.FindGameObjectWithTag("Slot3").transform.GetChild(0).transform, slots.tempoUISlots[3].transform));
                                StartCoroutine(MovePos(GameObject.FindGameObjectWithTag("Slot4").transform.GetChild(0).transform, slots.tempoUISlots[2].transform));
                                GameObject.FindGameObjectWithTag("Slot4").transform.GetChild(0).transform.SetParent(slots.tempoUISlots[2].transform);
                                GameObject.FindGameObjectWithTag("Slot3").transform.GetChild(0).transform.SetParent(slots.tempoUISlots[3].transform);
                                break;
                            }
                        }

                    }*/
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

    IEnumerator MovePos(Transform pos1, Transform pos2)
    {
        check = false;
        //Debug.Log(1);
        float f = 0;

        while (f < 1)
        {
            pos1.position = Vector3.Lerp(pos1.position, pos2.position, f);
            f += Time.deltaTime * 1.2f;
            yield return null;
        }

        pos1.position = pos2.position;
        check = true;
    }

}
