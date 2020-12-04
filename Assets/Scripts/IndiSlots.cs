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
    bool check, checker;

    // Start is called before the first frame update
    private void Start()
    {
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        check = true;
        checker = true;
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

                if (transform.childCount > 0)
                {
                    if (slots.tempoUISlots[1].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite)
                    {

                        List<GameObject> diffObj = new List<GameObject>();
                        diffObj.Add(slots.tempoUISlots[1].transform.GetChild(0).gameObject);

                        if (slots.tempoUISlots[2].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite)
                        {

                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[2].transform, 1.2f));
                            StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), slots.tempoUISlots[1].transform, 1.2f));

                            diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[2].transform);
                            slots.tempoUISlots[2].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[1].transform);

                            break;
                        }
                        else if (slots.tempoUISlots[2].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite)
                        {

                            diffObj.Add(slots.tempoUISlots[2].transform.GetChild(0).gameObject);

                            if (slots.tempoUISlots[3].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[2].transform));
                                StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[3].transform));
                                StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), slots.tempoUISlots[1].transform, 1.2f));

                                diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[2].transform);
                                diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);
                                slots.tempoUISlots[3].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[1].transform);

                                RemoveObjFromList(diffObj);

                                break;
                            }
                            else if (slots.tempoUISlots[3].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                diffObj.Add(slots.tempoUISlots[3].transform.GetChild(0).gameObject);

                                if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                                {
                                    StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[2].transform));
                                    StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[3].transform));
                                    StartCoroutine(MovePos(diffObj[2].gameObject.transform, slots.tempoUISlots[4].transform));
                                    StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), slots.tempoUISlots[1].transform, 1.2f));

                                    diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[2].transform);
                                    diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);
                                    diffObj[2].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                    slots.tempoUISlots[4].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[1].transform);

                                    RemoveObjFromList(diffObj);
                                }
                                else if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                                {

                                    diffObj.Add(slots.tempoUISlots[4].transform.GetChild(0).gameObject);

                                    if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                                    {
                                        StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[2].transform));
                                        StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[3].transform));
                                        StartCoroutine(MovePos(diffObj[2].gameObject.transform, slots.tempoUISlots[4].transform));
                                        StartCoroutine(MovePos(diffObj[3].gameObject.transform, slots.tempoUISlots[5].transform));
                                        StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), slots.tempoUISlots[1].transform));

                                        diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[2].transform);
                                        diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);
                                        diffObj[2].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                        diffObj[3].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                        slots.tempoUISlots[5].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[1].transform);

                                        RemoveObjFromList(diffObj);
                                    }
                                    else if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                                    {

                                        diffObj.Add(slots.tempoUISlots[5].transform.GetChild(0).gameObject);

                                        if (slots.tempoUISlots[6].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[6].transform.GetChild(0).GetComponent<Image>().sprite)
                                        {
                                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[2].transform));
                                            StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[3].transform));
                                            StartCoroutine(MovePos(diffObj[2].gameObject.transform, slots.tempoUISlots[4].transform));
                                            StartCoroutine(MovePos(diffObj[3].gameObject.transform, slots.tempoUISlots[5].transform));
                                            StartCoroutine(MovePos(diffObj[4].gameObject.transform, slots.tempoUISlots[6].transform));
                                            StartCoroutine(MovePos(slots.tempoUISlots[6].transform.GetChild(0), slots.tempoUISlots[1].transform));

                                            diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[2].transform);
                                            diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);
                                            diffObj[2].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                            diffObj[3].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                            diffObj[4].gameObject.transform.SetParent(slots.tempoUISlots[6].transform);
                                            slots.tempoUISlots[6].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[1].transform);

                                            RemoveObjFromList(diffObj);
                                        }

                                    }

                                }

                            }

                        }


                    }
                    else if (slots.tempoUISlots[1].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite)
                    {

                        if (slots.tempoUISlots[2].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite)
                        {
                            List<GameObject> diffObj = new List<GameObject>();
                            diffObj.Add(slots.tempoUISlots[2].transform.GetChild(0).gameObject);

                            if (slots.tempoUISlots[3].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[3].transform));
                                StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), slots.tempoUISlots[2].transform));

                                diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);
                                slots.tempoUISlots[3].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[2].transform);

                                RemoveObjFromList(diffObj);

                            }
                            else if (slots.tempoUISlots[3].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                diffObj.Add(slots.tempoUISlots[3].transform.GetChild(0).gameObject);

                                if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                                {
                                    StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[3].transform));
                                    StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[4].transform));
                                    StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), slots.tempoUISlots[2].transform));

                                    diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);
                                    diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                    slots.tempoUISlots[4].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[2].transform);

                                    RemoveObjFromList(diffObj);
                                }
                                else if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                                {

                                    diffObj.Add(slots.tempoUISlots[4].transform.GetChild(0).gameObject);

                                    if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                                    {
                                        StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[3].transform));
                                        StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[4].transform));
                                        StartCoroutine(MovePos(diffObj[2].gameObject.transform, slots.tempoUISlots[5].transform));
                                        StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), slots.tempoUISlots[2].transform));

                                        diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);
                                        diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                        diffObj[2].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                        slots.tempoUISlots[5].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[2].transform);

                                        RemoveObjFromList(diffObj);
                                    }
                                    else if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                                    {

                                        diffObj.Add(slots.tempoUISlots[5].transform.GetChild(0).gameObject);

                                        if (slots.tempoUISlots[6].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[6].transform.GetChild(0).GetComponent<Image>().sprite)
                                        {
                                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[3].transform));
                                            StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[4].transform));
                                            StartCoroutine(MovePos(diffObj[2].gameObject.transform, slots.tempoUISlots[5].transform));
                                            StartCoroutine(MovePos(diffObj[3].gameObject.transform, slots.tempoUISlots[6].transform));
                                            StartCoroutine(MovePos(slots.tempoUISlots[6].transform.GetChild(0), slots.tempoUISlots[2].transform));

                                            diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);
                                            diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                            diffObj[2].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                            diffObj[3].gameObject.transform.SetParent(slots.tempoUISlots[6].transform);
                                            slots.tempoUISlots[6].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[2].transform);

                                            RemoveObjFromList(diffObj);
                                        }

                                    }

                                }

                            }

                            break;
                        }

                    }
                }
                else if (transform.childCount <= 0)
                {
                    List<GameObject> diffObj = new List<GameObject>();


                    if (slots.tempoUISlots[3].transform.childCount > 0 || slots.tempoUISlots[4].transform.childCount > 0 || slots.tempoUISlots[5].transform.childCount > 0 || slots.tempoUISlots[6].transform.childCount > 0)
                    {
                        for (int i = 3; i < 7; i++)
                        {
                            if (slots.tempoUISlots[i].transform.childCount > 0)
                            {
                                diffObj.Add(slots.tempoUISlots[i].transform.GetChild(0).gameObject);
                            }
                        }
                        for (int j = 0; j < diffObj.Count; j++)
                        {
                            StartCoroutine(MovePos(diffObj[j].gameObject.transform, slots.tempoUISlots[j].transform));

                            diffObj[j].gameObject.transform.SetParent(slots.tempoUISlots[j].transform);

                            slots.isFull[j] = true;
                        }
                    }

                }

                break;

            case "Slot2":

                if (transform.childCount > 0)
                {
                    if (slots.tempoUISlots[2].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite)
                    {

                        List<GameObject> diffObj = new List<GameObject>();
                        diffObj.Add(slots.tempoUISlots[2].transform.GetChild(0).gameObject);

                        if (slots.tempoUISlots[3].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite)
                        {

                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[3].transform));
                            StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), slots.tempoUISlots[2].transform));

                            diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);
                            slots.tempoUISlots[3].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[2].transform);

                            break;
                        }
                        else if (slots.tempoUISlots[3].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite)
                        {

                            diffObj.Add(slots.tempoUISlots[3].transform.GetChild(0).gameObject);

                            if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[3].transform));
                                StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[4].transform));
                                StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), slots.tempoUISlots[2].transform));

                                diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);
                                diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                slots.tempoUISlots[4].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[2].transform);

                                RemoveObjFromList(diffObj);

                                break;
                            }
                            else if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                diffObj.Add(slots.tempoUISlots[4].transform.GetChild(0).gameObject);

                                if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                                {
                                    StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[3].transform));
                                    StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[4].transform));
                                    StartCoroutine(MovePos(diffObj[2].gameObject.transform, slots.tempoUISlots[5].transform));
                                    StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), slots.tempoUISlots[2].transform));

                                    diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);
                                    diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                    diffObj[2].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                    slots.tempoUISlots[5].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[2].transform);

                                    RemoveObjFromList(diffObj);
                                }
                                else if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                                {

                                    diffObj.Add(slots.tempoUISlots[5].transform.GetChild(0).gameObject);

                                    if (slots.tempoUISlots[6].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[6].transform.GetChild(0).GetComponent<Image>().sprite)
                                    {
                                        StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[3].transform));
                                        StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[4].transform));
                                        StartCoroutine(MovePos(diffObj[2].gameObject.transform, slots.tempoUISlots[5].transform));
                                        StartCoroutine(MovePos(diffObj[3].gameObject.transform, slots.tempoUISlots[6].transform));
                                        StartCoroutine(MovePos(slots.tempoUISlots[6].transform.GetChild(0), slots.tempoUISlots[2].transform));

                                        diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);
                                        diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                        diffObj[2].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                        diffObj[3].gameObject.transform.SetParent(slots.tempoUISlots[6].transform);
                                        slots.tempoUISlots[6].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[2].transform);

                                        RemoveObjFromList(diffObj);
                                    }

                                }

                            }

                        }


                    }
                    else if (slots.tempoUISlots[2].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite)
                    {

                        if (slots.tempoUISlots[3].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite)
                        {
                            List<GameObject> diffObj = new List<GameObject>();
                            diffObj.Add(slots.tempoUISlots[3].transform.GetChild(0).gameObject);

                            if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[4].transform));
                                StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), slots.tempoUISlots[3].transform));

                                diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                slots.tempoUISlots[4].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[3].transform);

                                RemoveObjFromList(diffObj);

                            }
                            else if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                diffObj.Add(slots.tempoUISlots[4].transform.GetChild(0).gameObject);

                                if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                                {
                                    StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[4].transform));
                                    StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[5].transform));
                                    StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), slots.tempoUISlots[3].transform));

                                    diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                    diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                    slots.tempoUISlots[5].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[3].transform);

                                    RemoveObjFromList(diffObj);
                                }
                                else if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                                {

                                    diffObj.Add(slots.tempoUISlots[5].transform.GetChild(0).gameObject);

                                    if (slots.tempoUISlots[6].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[6].transform.GetChild(0).GetComponent<Image>().sprite)
                                    {
                                        StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[4].transform));
                                        StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[5].transform));
                                        StartCoroutine(MovePos(diffObj[2].gameObject.transform, slots.tempoUISlots[6].transform));
                                        StartCoroutine(MovePos(slots.tempoUISlots[6].transform.GetChild(0), slots.tempoUISlots[3].transform));

                                        diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                        diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                        diffObj[2].gameObject.transform.SetParent(slots.tempoUISlots[6].transform);
                                        slots.tempoUISlots[6].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[3].transform);

                                        RemoveObjFromList(diffObj);
                                    }

                                }

                            }

                            break;
                        }

                    }
                }
                else if (transform.childCount <= 0)
                {
                    List<GameObject> diffObj = new List<GameObject>();

                    if (slots.tempoUISlots[4].transform.childCount > 0 || slots.tempoUISlots[5].transform.childCount > 0 || slots.tempoUISlots[6].transform.childCount > 0)
                    {
                        for (int i = 4; i < 7; i++)
                        {
                            if (slots.tempoUISlots[i].transform.childCount > 0)
                            {
                                diffObj.Add(slots.tempoUISlots[i].transform.GetChild(0).gameObject);
                            }
                        }
                        for (int j = 0; j < diffObj.Count; j++)
                        {
                            StartCoroutine(MovePos(diffObj[j].gameObject.transform, slots.tempoUISlots[j+1].transform));

                            diffObj[j].gameObject.transform.SetParent(slots.tempoUISlots[j+1].transform);

                            slots.isFull[j+1] = true;
                        }

                    }

                }

                break;

            case "Slot3":

                if (transform.childCount > 0)
                {
                    if (slots.tempoUISlots[3].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite)
                    {

                        List<GameObject> diffObj = new List<GameObject>();
                        diffObj.Add(slots.tempoUISlots[3].transform.GetChild(0).gameObject);

                        if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                        {

                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[4].transform));
                            StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), slots.tempoUISlots[3].transform));

                            diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                            slots.tempoUISlots[4].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[3].transform);

                            break;
                        }
                        else if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                        {

                            diffObj.Add(slots.tempoUISlots[4].transform.GetChild(0).gameObject);

                            if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[4].transform));
                                StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[5].transform));
                                StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), slots.tempoUISlots[3].transform));

                                diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                slots.tempoUISlots[5].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[3].transform);

                                RemoveObjFromList(diffObj);

                                break;
                            }
                            else if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                diffObj.Add(slots.tempoUISlots[5].transform.GetChild(0).gameObject);

                                if (slots.tempoUISlots[6].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[6].transform.GetChild(0).GetComponent<Image>().sprite)
                                {
                                    StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[4].transform));
                                    StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[5].transform));
                                    StartCoroutine(MovePos(diffObj[2].gameObject.transform, slots.tempoUISlots[6].transform));
                                    StartCoroutine(MovePos(slots.tempoUISlots[6].transform.GetChild(0), slots.tempoUISlots[3].transform));

                                    diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[4].transform);
                                    diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                    diffObj[2].gameObject.transform.SetParent(slots.tempoUISlots[6].transform);
                                    slots.tempoUISlots[6].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[3].transform);

                                    RemoveObjFromList(diffObj);
                                }

                            }

                        }


                    }
                    else if (slots.tempoUISlots[3].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite)
                    {

                        if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                        {
                            List<GameObject> diffObj = new List<GameObject>();
                            diffObj.Add(slots.tempoUISlots[4].transform.GetChild(0).gameObject);

                            if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[5].transform));
                                StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), slots.tempoUISlots[4].transform));

                                diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                slots.tempoUISlots[5].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[4].transform);

                                RemoveObjFromList(diffObj);

                            }
                            else if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                diffObj.Add(slots.tempoUISlots[5].transform.GetChild(0).gameObject);

                                if (slots.tempoUISlots[6].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[6].transform.GetChild(0).GetComponent<Image>().sprite)
                                {
                                    StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[5].transform));
                                    StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[6].transform));
                                    StartCoroutine(MovePos(slots.tempoUISlots[6].transform.GetChild(0), slots.tempoUISlots[4].transform));

                                    diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                    diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[6].transform);
                                    slots.tempoUISlots[6].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[4].transform);

                                    RemoveObjFromList(diffObj);
                                }

                            }

                            break;
                        }

                    }
                }
                else if (transform.childCount <= 0)
                {
                    List<GameObject> diffObj = new List<GameObject>();

                    if (slots.tempoUISlots[5].transform.childCount > 0 || slots.tempoUISlots[6].transform.childCount > 0)
                    {
                        for (int i = 5; i < 7; i++)
                        {
                            if (slots.tempoUISlots[i].transform.childCount > 0)
                            {
                                diffObj.Add(slots.tempoUISlots[i].transform.GetChild(0).gameObject);
                            }
                        }
                        for (int j = 0; j < diffObj.Count; j++)
                        {
                            StartCoroutine(MovePos(diffObj[j].gameObject.transform, slots.tempoUISlots[j + 2].transform));

                            diffObj[j].gameObject.transform.SetParent(slots.tempoUISlots[j + 2].transform);

                            slots.isFull[j + 2] = true;
                        }

                    }

                }

                break;

            case "Slot4":

                if (transform.childCount > 0)
                {
                    if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                    {

                        List<GameObject> diffObj = new List<GameObject>();
                        diffObj.Add(slots.tempoUISlots[4].transform.GetChild(0).gameObject);

                        if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                        {

                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[5].transform));
                            StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), slots.tempoUISlots[4].transform));

                            diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                            slots.tempoUISlots[5].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[4].transform);

                            break;
                        }
                        else if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                        {

                            diffObj.Add(slots.tempoUISlots[5].transform.GetChild(0).gameObject);

                            if (slots.tempoUISlots[6].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[6].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[5].transform));
                                StartCoroutine(MovePos(diffObj[1].gameObject.transform, slots.tempoUISlots[6].transform));
                                StartCoroutine(MovePos(slots.tempoUISlots[6].transform.GetChild(0), slots.tempoUISlots[4].transform));

                                diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                diffObj[1].gameObject.transform.SetParent(slots.tempoUISlots[6].transform);
                                slots.tempoUISlots[6].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[4].transform);

                                RemoveObjFromList(diffObj);

                                break;
                            }

                        }

                    }
                    else if (slots.tempoUISlots[4].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite)
                    {

                        if (slots.tempoUISlots[5].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite != slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite)
                        {
                            List<GameObject> diffObj = new List<GameObject>();
                            diffObj.Add(slots.tempoUISlots[5].transform.GetChild(0).gameObject);

                            if (slots.tempoUISlots[6].transform.childCount > 0 && transform.GetChild(0).transform.GetComponent<Image>().sprite == slots.tempoUISlots[6].transform.GetChild(0).GetComponent<Image>().sprite)
                            {

                                StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[6].transform));
                                StartCoroutine(MovePos(slots.tempoUISlots[6].transform.GetChild(0), slots.tempoUISlots[5].transform));

                                diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[5].transform);
                                slots.tempoUISlots[6].transform.GetChild(0).transform.SetParent(slots.tempoUISlots[5].transform);

                                RemoveObjFromList(diffObj);

                            }

                            break;
                        }

                    }
                }
                else if (transform.childCount <= 0)
                {
                    List<GameObject> diffObj = new List<GameObject>();

                    if (slots.tempoUISlots[6].transform.childCount > 0)
                    {

                        diffObj.Add(slots.tempoUISlots[6].transform.GetChild(0).gameObject);

                        StartCoroutine(MovePos(diffObj[0].gameObject.transform, slots.tempoUISlots[3].transform));

                        diffObj[0].gameObject.transform.SetParent(slots.tempoUISlots[3].transform);

                        slots.isFull[3] = true;

                    }

                }

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

    private void RemoveObjFromList(List<GameObject> diffObj)
    {

        for (int i = 0; i <= diffObj.Count; i++)
        {

            diffObj.RemoveAt(i);

        }

        Debug.Log(diffObj.Count);
    }

    IEnumerator MovePos(Transform pos1, Transform pos2, float speed = 1.2f)
    {
        check = false;

        float f = 0;

        while (f < 1)
        {
            pos1.position = Vector3.Lerp(pos1.position, pos2.position, f);
            f += Time.deltaTime * speed;
            yield return null;
        }

        pos1.position = pos2.position;
        check = true;
    }

}
