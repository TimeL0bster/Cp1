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
    private BoxCollider touchBlocker;
    private GameObject thisChild;
    private bool check;

    // Start is called before the first frame update
    private void Start()
    {
        slots = GameObject.FindWithTag("Slots").GetComponent<Slots>();
        touchBlocker = GameObject.FindGameObjectWithTag("TouchBlocker").GetComponent<BoxCollider>();
        check = true;
    }

    // Update is called once per frame
    private void Update()
    {

        if (transform.childCount <= 0)
        {
            slots.isFull[i] = false;
        }
        else if (transform.childCount > 0)
        {
            slots.isFull[i] = true;
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

                if (transform.childCount <= 0)
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

                if (transform.childCount <= 0)
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

                if (transform.childCount <= 0)
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
                
                if (transform.childCount <= 0)
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

                break;

            case "Slot5":

                break;

            case "Slot6":

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
