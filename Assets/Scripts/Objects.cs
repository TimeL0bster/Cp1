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

    [Header("Materials")]
    public Material[] matDark;
    public Material[] mat;

    private SpriteRenderer sprt;
    private MeshRenderer render;
    private bool isObjectAbove = false;

    protected BoxCollider touchBlocker;
    protected bool check;
    protected Slots slots;
    protected MiniObjectPool objectPooler;

    protected virtual void Start()
    {
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        sprt = GetComponent<SpriteRenderer>();
        render = transform.GetChild(0).GetComponent<MeshRenderer>();
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
            switch (this.gameObject.tag)
            {
                case "Object1":
                    render.material = mat[0];
                    break;
                case "Object2":
                    render.material = mat[1];
                    break;
                case "Object3":
                    render.material = mat[2];
                    break;
                case "Object4":
                    render.material = mat[3];
                    break;
                case "Object5":
                    render.material = mat[4];
                    break;
            }
        }
        else
        {
            switch (this.gameObject.tag)
            {
                case "Object1":
                    render.material = matDark[0];
                    break;
                case "Object2":
                    render.material = matDark[1];
                    break;
                case "Object3":
                    render.material = matDark[2];
                    break;
                case "Object4":
                    render.material = matDark[3];
                    break;
                case "Object5":
                    render.material = matDark[4];
                    break;
            }
        }

    }

    protected void Touched(float destroyTime)
    {
        //touchBlocker.enabled = true;
        if (!isObjectAbove)
        {
            
            if (slots.tempoUISlots[0].transform.childCount <= 0 && slots.isFull[0] == false)
            {
                StartCoroutine(Move(0, destroyTime));
                //StartCoroutine(spwnMiniObject(0, destroyTime));
            }
            else if (slots.tempoUISlots[1].transform.childCount <= 0 && slots.isFull[1] == false)
            {
                StartCoroutine(Move(1, destroyTime));
                //StartCoroutine(spwnMiniObject(1, destroyTime));
            }
            else if (slots.tempoUISlots[2].transform.childCount <= 0 && slots.isFull[2] == false)
            {
                if (slots.tempoUISlots[0].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                    && slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                {
                    StartCoroutine(MovePos(slots.tempoUISlots[1].transform.GetChild(0), 2));

                    StartCoroutine(Move(1, destroyTime));
                   // StartCoroutine(spwnMiniObject(1, destroyTime));
                }
                else
                {
                    StartCoroutine(Move(2, destroyTime));
                    //StartCoroutine(spwnMiniObject(2, destroyTime));
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

                        StartCoroutine(Move(1, destroyTime));
                        //StartCoroutine(spwnMiniObject(1, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));

                        StartCoroutine(Move(2, destroyTime));
                        //StartCoroutine(spwnMiniObject(2, destroyTime));
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
                        StartCoroutine(Move(3, destroyTime));
                        //StartCoroutine(spwnMiniObject(3, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));

                        StartCoroutine(Move(2, destroyTime));
                        //tartCoroutine(spwnMiniObject(2, destroyTime));
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

                        StartCoroutine(Move(1, destroyTime));
                        //StartCoroutine(spwnMiniObject(1, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));

                        StartCoroutine(Move(2, destroyTime));
                        //StartCoroutine(spwnMiniObject(2, destroyTime));
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
                        StartCoroutine(Move(4, destroyTime));
                        //StartCoroutine(spwnMiniObject(4, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));

                        StartCoroutine(Move(2, destroyTime));
                        //StartCoroutine(spwnMiniObject(2, destroyTime));
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

                        StartCoroutine(Move(3, destroyTime));
                        //StartCoroutine(spwnMiniObject(3, destroyTime));
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

                        StartCoroutine(Move(1, destroyTime));
                        //StartCoroutine(spwnMiniObject(1, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));
                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));

                        StartCoroutine(Move(2, destroyTime));
                        //StartCoroutine(spwnMiniObject(2, destroyTime));
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
                        StartCoroutine(Move(5, destroyTime));
                        //StartCoroutine(spwnMiniObject(5, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[2].transform.GetChild(0), 3));
                        StartCoroutine(MovePos(slots.tempoUISlots[3].transform.GetChild(0), 4));
                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));

                        StartCoroutine(Move(2, destroyTime));
                        //StartCoroutine(spwnMiniObject(2, destroyTime));
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

                        StartCoroutine(Move(3, destroyTime));
                        //StartCoroutine(spwnMiniObject(3, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {

                        StartCoroutine(MovePos(slots.tempoUISlots[4].transform.GetChild(0), 5));

                        StartCoroutine(Move(4, destroyTime));
                        //StartCoroutine(spwnMiniObject(4, destroyTime));
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

                        StartCoroutine(Move(1, destroyTime));
                        //StartCoroutine(spwnMiniObject(1, destroyTime));
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

                        StartCoroutine(Move(2, destroyTime));
                        //StartCoroutine(spwnMiniObject(2, destroyTime));
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
                        StartCoroutine(Move(6, destroyTime));
                        //StartCoroutine(spwnMiniObject(6, destroyTime));
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

                        StartCoroutine(Move(2, destroyTime));
                        //StartCoroutine(spwnMiniObject(2, destroyTime));
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

                        StartCoroutine(Move(3, destroyTime));
                        //StartCoroutine(spwnMiniObject(3, destroyTime));
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

                        StartCoroutine(Move(4, destroyTime));
                        //StartCoroutine(spwnMiniObject(4, destroyTime));
                    }

                    else if (slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        ||
                        slots.tempoUISlots[1].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[2].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[3].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite
                        && slots.tempoUISlots[4].transform.GetChild(0).GetComponent<Image>().sprite == sprt.sprite
                        && slots.tempoUISlots[5].transform.GetChild(0).GetComponent<Image>().sprite != sprt.sprite)
                    {
                        StartCoroutine(MovePos(slots.tempoUISlots[5].transform.GetChild(0), 6));

                        StartCoroutine(Move(5, destroyTime));
                        //StartCoroutine(spwnMiniObject(5, destroyTime));
                    }

                }
            }

        }

    }

    IEnumerator Move(int index, float destroyTime)
    {

        float f = 0;
        bool spwnCheck = true;

        boxCollider.enabled = !boxCollider.enabled;

        while (f < 1)
        {

            f += Time.deltaTime / 2f;
            if (transform.localScale.x >= .5f)
            {
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * 2.5f;
            }
            transform.position = Vector3.Lerp(transform.position, slots.tempoSlots[index].transform.position, f);

            if (f > .2f && f < .21f && spwnCheck == true)
            {
                spwnCheck = false;
                StartCoroutine(spwnMiniObject(index, destroyTime));
                //touchBlocker.enabled = false;
                Destroy(this.gameObject);
            }

            yield return null;

        }

        //StartCoroutine(spwnMiniObject(index, destroyTime));

    }

    IEnumerator MovePos(Transform slotChildIndex, int slotIndex, float speed = 1.2f)
    {
        check = false;
        //touchBlocker.enabled = true;

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
        
        if (slots.isFull[0] != true)
        {
            slots.isFull[0] = true;
            Instantiate(miniObj, slots.tempoUISlots[0].transform, false);
        }
        else if (slots.isFull[1] != true)
        {
            slots.isFull[1] = true;
            Instantiate(miniObj, slots.tempoUISlots[1].transform, false);
        }
        else if (slots.isFull[2] != true)
        {
            slots.isFull[2] = true;
            Instantiate(miniObj, slots.tempoUISlots[2].transform, false);
        }
        else if (slots.isFull[3] != true)
        {
            slots.isFull[3] = true;
            Instantiate(miniObj, slots.tempoUISlots[3].transform, false);
        }
        else if (slots.isFull[4] != true)
        {
            slots.isFull[4] = true;
            Instantiate(miniObj, slots.tempoUISlots[4].transform, false);
        }
        else if (slots.isFull[5] != true)
        {
            slots.isFull[5] = true;
            Instantiate(miniObj, slots.tempoUISlots[5].transform, false);
        }
        else if (slots.isFull[6] != true)
        {
            slots.isFull[6] = true;
            Instantiate(miniObj, slots.tempoUISlots[6].transform, false);
        }

        yield return new WaitForSeconds(.3f);

        
        //StartCoroutine(DestroySelf(destroyTime));
    }

    IEnumerator WaitForItemSpwn(int i, int index)
    {

        //StartCoroutine(Move(index));

        yield return new WaitForSeconds(.6f);

        slots.isFull[i] = true;
        Instantiate(miniObj, slots.tempoUISlots[i].transform, false);

    }

    IEnumerator DestroySelf(float destroyTime = 0.1f)
    {
        yield return new WaitForSeconds(destroyTime);

        //touchBlocker.enabled = false;
        Destroy(this.gameObject);
    }



}
