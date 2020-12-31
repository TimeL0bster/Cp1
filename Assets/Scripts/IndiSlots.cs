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
        if (transform.childCount == 0)
        {
            slots.isFull[i] = false;
        }
        else if (transform.childCount > 0)
        {
            slots.isFull[i] = true;
        }

        if (check)
        {
            //PosSwtch();
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


                    if (slots.tempoSlots[3].transform.childCount > 0 
                        || slots.tempoSlots[4].transform.childCount > 0 
                        || slots.tempoSlots[5].transform.childCount > 0 
                        || slots.tempoSlots[6].transform.childCount > 0)
                    {
                        for (int i = 3; i < 7; i++)
                        {
                            if (slots.tempoSlots[i].transform.childCount > 0)
                            {
                                diffObj.Add(slots.tempoSlots[i].transform.GetChild(0).gameObject);
                            }
                        }

                        for (int j = 0; j < diffObj.Count; j++)
                        {

                            StopCoroutine(MovePos(diffObj[j].gameObject.transform, j));
                            StartCoroutine(MovePos(diffObj[j].gameObject.transform, j));

                            diffObj[j].gameObject.transform.SetParent(slots.tempoSlots[j].transform);

                            slots.isFull[j] = true;
                        }

                        //touchBlocker.enabled = false;
                        /*StartCoroutine(TouchBlockerDisable());

                        if (diffObj.Count == 1)
                        {
                            StopCoroutine(MovePos(diffObj[0].gameObject.transform, 0));
                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, 0));
                        }
                        else if (diffObj.Count == 2)
                        {
                            StopCoroutine(MovePos(diffObj[0].gameObject.transform, 0));
                            StopCoroutine(MovePos(diffObj[1].gameObject.transform, 1));
                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, 0));
                            StartCoroutine(MovePos(diffObj[1].gameObject.transform, 1));
                        }
                        else if (diffObj.Count == 3)
                        {
                            StopCoroutine(MovePos(diffObj[0].gameObject.transform, 0));
                            StopCoroutine(MovePos(diffObj[1].gameObject.transform, 1));
                            StopCoroutine(MovePos(diffObj[2].gameObject.transform, 2));
                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, 0));
                            StartCoroutine(MovePos(diffObj[1].gameObject.transform, 1));
                            StartCoroutine(MovePos(diffObj[2].gameObject.transform, 2));
                            
                        }
                        else if (diffObj.Count == 4)
                        {
                            StopCoroutine(MovePos(diffObj[0].gameObject.transform, 0));
                            StopCoroutine(MovePos(diffObj[1].gameObject.transform, 1));
                            StopCoroutine(MovePos(diffObj[2].gameObject.transform, 2));
                            StopCoroutine(MovePos(diffObj[3].gameObject.transform, 3));
                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, 0));
                            StartCoroutine(MovePos(diffObj[1].gameObject.transform, 1));
                            StartCoroutine(MovePos(diffObj[2].gameObject.transform, 2));
                            StartCoroutine(MovePos(diffObj[3].gameObject.transform, 3));
                        }*/

                    }

                }

                break;

            case "Slot2":

                if (transform.childCount <= 0)
                {
                    List<GameObject> diffObj = new List<GameObject>();

                    if (slots.tempoSlots[4].transform.childCount > 0 || slots.tempoSlots[5].transform.childCount > 0 || slots.tempoSlots[6].transform.childCount > 0)
                    {

                        for (int i = 4; i < 7; i++)
                        {
                            if (slots.tempoSlots[i].transform.childCount > 0)
                            {
                                diffObj.Add(slots.tempoSlots[i].transform.GetChild(0).gameObject);
                            }
                        }

                        for (int j = 0; j < diffObj.Count; j++)
                        {
                            StopCoroutine(MovePos(diffObj[j].gameObject.transform, j + 1));
                            StartCoroutine(MovePos(diffObj[j].gameObject.transform, j + 1));

                            diffObj[j].gameObject.transform.SetParent(slots.tempoSlots[j+1].transform);

                            slots.isFull[j+1] = true;
                        }

                        /*StartCoroutine(TouchBlockerDisable());

                        if (diffObj.Count == 1)
                        {
                            StopCoroutine(MovePos(diffObj[0].gameObject.transform, 1));
                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, 1));
                        }
                        else if (diffObj.Count == 2)
                        {
                            StopCoroutine(MovePos(diffObj[0].gameObject.transform, 1));
                            StopCoroutine(MovePos(diffObj[1].gameObject.transform, 2));
                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, 1));
                            StartCoroutine(MovePos(diffObj[1].gameObject.transform, 2));
                        }
                        else if (diffObj.Count == 3)
                        {
                            StopCoroutine(MovePos(diffObj[0].gameObject.transform, 1));
                            StopCoroutine(MovePos(diffObj[1].gameObject.transform, 2));
                            StopCoroutine(MovePos(diffObj[2].gameObject.transform, 3));
                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, 1));
                            StartCoroutine(MovePos(diffObj[1].gameObject.transform, 2));
                            StartCoroutine(MovePos(diffObj[2].gameObject.transform, 3));
                        }*/

                    }

                }

                break;

            case "Slot3":

                if (transform.childCount <= 0)
                {
                    List<GameObject> diffObj = new List<GameObject>();

                    if (slots.tempoSlots[5].transform.childCount > 0 || slots.tempoSlots[6].transform.childCount > 0)
                    {
                        for (int i = 5; i < 7; i++)
                        {
                            if (slots.tempoSlots[i].transform.childCount > 0)
                            {
                                diffObj.Add(slots.tempoSlots[i].transform.GetChild(0).gameObject);
                            }
                        }

                        for (int j = 0; j < diffObj.Count; j++)
                        {

                            StopCoroutine(MovePos(diffObj[j].gameObject.transform, j + 2));
                            StartCoroutine(MovePos(diffObj[j].gameObject.transform, j + 2));

                            diffObj[j].gameObject.transform.SetParent(slots.tempoSlots[j + 2].transform);

                            slots.isFull[j + 2] = true;
                        }

                        /*StartCoroutine(TouchBlockerDisable());

                        if (diffObj.Count == 1)
                        {
                            StopCoroutine(MovePos(diffObj[0].gameObject.transform, 2));
                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, 2));
                        }
                        else if (diffObj.Count == 2)
                        {
                            StopCoroutine(MovePos(diffObj[0].gameObject.transform, 2));
                            StopCoroutine(MovePos(diffObj[1].gameObject.transform, 3));
                            StartCoroutine(MovePos(diffObj[0].gameObject.transform, 2));
                            StartCoroutine(MovePos(diffObj[1].gameObject.transform, 3));
                        }*/

                    }

                }

                break;

            case "Slot4":
                
                if (transform.childCount <= 0)
                {
                    List<GameObject> diffObj = new List<GameObject>();

                    if (slots.tempoSlots[6].transform.childCount > 0)
                    {

                        diffObj.Add(slots.tempoSlots[6].transform.GetChild(0).gameObject);

                        StopCoroutine(MovePos(diffObj[0].gameObject.transform, 3));
                        StartCoroutine(MovePos(diffObj[0].gameObject.transform, 3));

                    }

                    //StartCoroutine(TouchBlockerDisable());

                }

                break;

            case "Slot5":

                if (transform.childCount > 0)
                {
                    //StartCoroutine(TouchBlockerDisable());
                }

                break;

            case "Slot6":

                if (transform.childCount > 0)
                {
                    //StartCoroutine(TouchBlockerDisable());
                }

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

    IEnumerator MovePos(Transform pos1, int PosIndex, float speed = 1.2f)
    {
        check = false;
        //touchBlocker.enabled = true;

        float f = 0;
        Vector3 velocity = Vector3.zero;

        pos1.SetParent(slots.tempoSlots[PosIndex].transform);

        while (f < 1)
        {
            f += Time.deltaTime / 20f;
            pos1.position = Vector3.SmoothDamp(pos1.position, slots.tempoSlots[PosIndex].transform.position,ref velocity, .2f);
                //Vector3.Lerp(pos1.position, slots.tempoSlots[PosIndex].transform.position, f);
            //touchBlocker.enabled = true;
            yield return null;
        }

        pos1.position = slots.tempoSlots[PosIndex].transform.position;

        slots.isFull[PosIndex] = true;

        check = true;
    }

    IEnumerator TouchBlockerDisable()
    {


        yield return new WaitForSeconds(.3f);

        //touchBlocker.enabled = false;

    }

}
