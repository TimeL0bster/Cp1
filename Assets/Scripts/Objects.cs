using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objects : MonoBehaviour
{

    [Header("Distance")]
    public float Leight = 0f;
    public Vector3 collOffset1;
    public Vector3 collOffset2;
    public Vector3 collOffset3;
    public Vector3 collOffset4;
    public Vector3 collOffset5;
    public Vector3 collOffset6;
    public Vector3 collOffset7;
    public Vector3 collOffset8;

    [Header("Collider and Layermask")]
    public LayerMask isObjectLayer;

    [Header("Other setting")]
    public GameObject miniObj;
    public BoxCollider boxCollider;
    public float destroyTimer;

    private Animator anim;
    private SpriteRenderer sprt;
    private bool isObjectAbove = false;

    protected BoxCollider touchBlocker;
    protected bool check;
    protected Slots slots;
    protected MiniObjectPool objectPooler;

    protected virtual void Start()
    {
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        sprt = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        touchBlocker = GameObject.FindGameObjectWithTag("TouchBlocker").GetComponent<BoxCollider>();
        touchBlocker.enabled = false;
        check = true;
    }

    public void CastRay()
    {
        isObjectAbove = Physics.Raycast(transform.position + collOffset1, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position + collOffset7, Vector3.back, Leight, isObjectLayer)
            || Physics.Raycast(transform.position + collOffset2, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position + collOffset8, Vector3.back, Leight, isObjectLayer)
            || Physics.Raycast(transform.position + collOffset4, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position + collOffset5, Vector3.back, Leight, isObjectLayer)
            || Physics.Raycast(transform.position + collOffset3, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position + collOffset6, Vector3.back, Leight, isObjectLayer);

        if (!isObjectAbove)
        {
            sprt.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            sprt.color = new Color32(80, 80, 80, 255);
        }

    }

    protected void Touched(float destroyTime)
    {

        if (!isObjectAbove)
        {
            /*for (int i = 0; i < slots.tempoUISlots.Length; i++)
            {
                if (slots.isFull[i] == false)
                {
                    StartCoroutine(Move(5, i));
                    StartCoroutine(spwnMiniObject(i, destroyTime));
                    break;
                }
            }*/

            if (slots.tempoUISlots[0].transform.childCount <= 0 && slots.isFull[0] == false)
            {
                StartCoroutine(Move(5, 0));
                StartCoroutine(spwnMiniObject(0, destroyTime));
            }
            else if (slots.tempoUISlots[1].transform.childCount <= 0 && slots.isFull[1] == false)
            {
                StartCoroutine(Move(5, 1));
                StartCoroutine(spwnMiniObject(1, destroyTime));
            }
            else if (slots.tempoUISlots[2].transform.childCount <= 0 && slots.isFull[2] == false)
            {
                if (slots.tempoUISlots[0].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite 
                    && slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                {
                    StartCoroutine(MovePos(slots.tempoUISlots[1].transform.GetChild(0), 2));

                    StartCoroutine(Move(5, 1));
                    StartCoroutine(spwnMiniObject(1, destroyTime));
                }
                else
                {
                    StartCoroutine(Move(5, 2));
                    StartCoroutine(spwnMiniObject(2, destroyTime));
                }
            }
            else if (slots.tempoUISlots[3].transform.childCount <= 0 && slots.isFull[3] == false)
            {
                if (slots.tempoUISlots[0].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite)
                {

                    if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite 
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[1].transform.GetChild(0), 2));
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));

                        StartCoroutine(Move(5, 1));
                        StartCoroutine(spwnMiniObject(1, destroyTime));
                    }
                    
                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite 
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));

                        StartCoroutine(Move(5, 2));
                        StartCoroutine(spwnMiniObject(2, destroyTime));
                    }

                    

                }
                else
                {
                    if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite 
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite)
                    {
                        StartCoroutine(Move(5, 3));
                        StartCoroutine(spwnMiniObject(3, destroyTime));
                    }
                    
                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite 
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));

                        StartCoroutine(Move(5, 2));
                        StartCoroutine(spwnMiniObject(2, destroyTime));
                    }
                    
                }
            }
            else if (slots.tempoUISlots[4].transform.childCount <= 0 && slots.isFull[4] == false)
            {
                if (slots.tempoUISlots[0].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite)
                {

                    if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite 
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite 
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[1].transform.GetChild(0), 2));
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));

                        StartCoroutine(Move(5, 1));
                        StartCoroutine(spwnMiniObject(1, destroyTime));
                    }
                    
                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite 
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite 
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));

                        StartCoroutine(Move(5, 2));
                        StartCoroutine(spwnMiniObject(2, destroyTime));
                    }
                    
                }
                else
                {
                    if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite 
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite 
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite)
                    {
                        StartCoroutine(Move(5, 4));
                        StartCoroutine(spwnMiniObject(4, destroyTime));
                    }
                    
                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite 
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite 
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));

                        StartCoroutine(Move(5, 2));
                        StartCoroutine(spwnMiniObject(2, destroyTime));
                    }
                    
                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite 
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite 
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        || 
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));

                        StartCoroutine(Move(5, 3));
                        StartCoroutine(spwnMiniObject(3, destroyTime));
                    }

                }
            }
            else if (slots.tempoUISlots[5].transform.childCount <= 0 && slots.isFull[5] == false)
            {
                if (slots.tempoUISlots[0].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite)
                {

                    if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[1].transform.GetChild(0), 2));
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));
                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));

                        StartCoroutine(Move(5, 1));
                        StartCoroutine(spwnMiniObject(1, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));
                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));

                        StartCoroutine(Move(5, 2));
                        StartCoroutine(spwnMiniObject(2, destroyTime));
                    }

                }
                else
                {
                    if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite)
                    {
                        StartCoroutine(Move(5, 5));
                        StartCoroutine(spwnMiniObject(5, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));
                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));

                        StartCoroutine(Move(5, 2));
                        StartCoroutine(spwnMiniObject(2, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));
                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));

                        StartCoroutine(Move(5, 3));
                        StartCoroutine(spwnMiniObject(3, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {

                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));

                        StartCoroutine(Move(5, 4));
                        StartCoroutine(spwnMiniObject(4, destroyTime));
                    }

                }
            }
            else if (slots.tempoUISlots[6].transform.childCount <= 0 && slots.isFull[6] == false)
            {
                if (slots.tempoUISlots[0].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite)
                {

                    if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[1].transform.GetChild(0), 2));
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));
                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));
                        StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), 6));

                        StartCoroutine(Move(5, 1));
                        StartCoroutine(spwnMiniObject(1, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));
                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));
                        StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), 6));

                        StartCoroutine(Move(5, 2));
                        StartCoroutine(spwnMiniObject(2, destroyTime));
                    }

                }
                else
                {
                    if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite)
                    {
                        StartCoroutine(Move(5, 6));
                        StartCoroutine(spwnMiniObject(6, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));
                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));
                        StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), 6));

                        StartCoroutine(Move(5, 2));
                        StartCoroutine(spwnMiniObject(2, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));
                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));
                        StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), 6));

                        StartCoroutine(Move(5, 3));
                        StartCoroutine(spwnMiniObject(3, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));
                        StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), 6));

                        StartCoroutine(Move(5, 4));
                        StartCoroutine(spwnMiniObject(4, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), 6));

                        StartCoroutine(Move(5, 5));
                        StartCoroutine(spwnMiniObject(5, destroyTime));
                    }

                }
            }

        }

    }

    IEnumerator Move(float time, int index)
    {

        touchBlocker.enabled = true;

        float f = 0;

        boxCollider.enabled = !boxCollider.enabled;

        while (f < 1)
        {
            f += Time.deltaTime / time;
            if (transform.localScale.x >= 0)
            {
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * 2f;
            }
            transform.position = Vector3.Lerp(transform.position, slots.tempoSlots[index].transform.position, f);
            yield return null;
        }

        touchBlocker.enabled = false;

    }

    IEnumerator MovePos(Transform slotChildIndex, int slotIndex, float speed = 1.2f)
    {

        check = false;

        float f = 0;

        slotChildIndex.transform.SetParent(slots.tempoUISlots[slotIndex].transform);

        while (f < 1)
        {
            slotChildIndex.transform.position = Vector3.Lerp(slotChildIndex.transform.position, slots.tempoUISlots[slotIndex].transform.position, f);
            f += Time.deltaTime * speed;
            yield return null;
        }

        slotChildIndex.transform.position = slots.tempoUISlots[slotIndex].transform.position;

        slots.isFull[slotIndex] = true;

        check = true;

    }

    IEnumerator spwnMiniObject(int i, float destroyTime)
    {
        slots.isFull[i] = true;
        Instantiate(miniObj, slots.tempoUISlots[i].transform, false);

        yield return new WaitForSeconds(.5f);

        touchBlocker.enabled = false;
        StartCoroutine(DestroySelf(destroyTime));
    }

    IEnumerator DestroySelf(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);

        Destroy(this.gameObject);
    }



}
