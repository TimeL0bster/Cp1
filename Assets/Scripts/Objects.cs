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

    protected Slots slots;
    protected MiniObjectPool objectPooler;

    protected virtual void Start()
    {
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        sprt = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void CastRay()
    {
        isObjectAbove = Physics.Raycast(transform.position + collOffset1, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position + collOffset7, Vector3.back, Leight, isObjectLayer)
            || Physics.Raycast(transform.position + collOffset2, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position + collOffset8, Vector3.back, Leight, isObjectLayer)
            || Physics.Raycast(transform.position + collOffset4, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position + collOffset5, Vector3.back, Leight, isObjectLayer)
            || Physics.Raycast(transform.position + collOffset3, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position + collOffset6, Vector3.back, Leight, isObjectLayer);

        if (!isObjectAbove)
        {
            //img.color = new Color32(255,255,255,255);
            sprt.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            //img.color = new Color32(80, 80, 80, 255);
            sprt.color = new Color32(80, 80, 80, 255);
        }

    }

    protected void Touched(float destroyTime)
    {

        if (!isObjectAbove)
        {
            for (int i = 0; i < slots.tempoUISlots.Length; i++)
            {
                if (slots.isFull[i] == false)
                {
                    StartCoroutine(Move(5,i));
                    StartCoroutine(spwnMiniObject(i,destroyTime));
                    //Instantiate(miniObj, slots.slots[i].transform, false);
                    //Destroy(this.gameObject);
                    break;
                }
            }
        }

    }

    IEnumerator Move(float time, int i)
    {

        float f = 0;
        
        /*GameObject[] obj = GameObject.FindGameObjectsWithTag("Object");
        BoxCollider[] box = new BoxCollider[obj.Length];

        for (int k = 0; k < obj.Length; k++)
        {
            box[k] = obj[k].GetComponent<BoxCollider>();
            box[k].enabled = !box[k].enabled;
        }*/

        boxCollider.enabled = !boxCollider.enabled;

        while (f < 1)
        {
            f += Time.deltaTime / time;
            transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * 3f;
            transform.position = Vector3.Lerp(transform.position, slots.tempoSlots[i].transform.position, f);
            yield return 0;
        }
    }

    IEnumerator spwnMiniObject(int i,float destroyTime)
    {
        slots.isFull[i] = true;
        Instantiate(miniObj, slots.tempoUISlots[i].transform, false);

        yield return new WaitForSeconds(.5f);

        StartCoroutine(DestroySelf(destroyTime));
    }

    IEnumerator DestroySelf(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);

        Destroy(this.gameObject);
    }



}
