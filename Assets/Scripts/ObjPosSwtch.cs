
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjPosSwtch : MonoBehaviour
{

    [Header("Distance")]
    public int leight = 0;
    public Vector3 collOffSetRay1;
    public Vector3 collOffSetRay2;

    [Header("Sprites")]
    public Sprite[] miniObjectSprite;

    private RaycastHit2D protoHit;
    private Slots slots;

    // Update is called once per frame
    void Update()
    {
        ObjSwtch();
    }

    private void ObjSwtch()
    {
        protoHit = Physics2D.Raycast(transform.position + collOffSetRay1, Vector2.right * leight);
        RaycastHit2D[] objectHit1 = Physics2D.RaycastAll(transform.position + collOffSetRay1, Vector2.right * leight);

<<<<<<< HEAD
        if (protoHit.collider != null)
        {
            /*if (objectHit1[0].collider.GetComponent<Image>().sprite == miniObjectSprt[0])
            {

                Debug.Log("Green first");

                if (objectHit1[1].collider != null && objectHit1[1].collider.GetComponent<Image>().sprite == miniObjectSprt[0])
                {
                    Debug.Log("Green seccond");
                }
                else
                {
                    Debug.Log("missmatch");
                    for (int i = 2; i < 7;i++)
                    {
                        if (objectHit1[i].collider.GetComponent<Image>().sprite == miniObjectSprt[0])
                        {
                            float f = 0;
                            while (f < 1)
                            {
                                f += Time.deltaTime / 10;
                                objectHit1[1].collider.transform.position = Vector3.Lerp(objectHit1[1].collider.transform.position, slots.tempoSlots[i].transform.position, 1);
                                objectHit1[i].collider.transform.position = Vector3.Lerp(objectHit1[i].collider.transform.position, slots.tempoSlots[1].transform.position, 1);
                            }
                        }
                    }
                }
            }
            else if (objectHit1[0].collider.GetComponent<Image>().sprite == miniObjectSprt[1])
            {
                Debug.Log("Red first");
            }*/
        }
=======

>>>>>>> parent of 56ea4e80... obj move pos (Complete) & mini obj swtch (In progress)

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position + collOffSetRay1, transform.position + collOffSetRay1 + Vector3.right * leight);
    }
}
