using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{

    [Header("Distance")]
    public float Leight = 0f;
    public Vector3 collOffsetHorizontal;
    public Vector3 collOffsetVertical;
    public Vector3 collOffsetHorizontal2;
    public Vector3 collOffsetVertical2;

    [Header("Collider and Layermask")]
    public LayerMask isObjectLayer;

    [Header("This object")]
    public GameObject miniObj;

    private BoxCollider boxCollider;
    private Animator anim;
    private Image img;
    private SpriteRenderer sprt;
    private bool isObjectAbove = false;

    protected Slots slots;
    protected MiniObjectPool objectPooler;

    protected virtual void Start()
    {
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        img = GetComponent<Image>();
        sprt = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void CastRay()
    {
        isObjectAbove = Physics.Raycast(transform.position + collOffsetHorizontal, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position - collOffsetHorizontal, Vector3.back, Leight, isObjectLayer)
            || Physics.Raycast(transform.position + collOffsetVertical, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position - collOffsetVertical, Vector3.back, Leight, isObjectLayer)
            || Physics.Raycast(transform.position + collOffsetVertical2, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position - collOffsetVertical2, Vector3.back, Leight, isObjectLayer);

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

    public void Touched()
    {

        if (!isObjectAbove)
        {
            for (int i = 0; i < slots.slots.Length; i++)
            {
                
                if (slots.isFull[i] == false)
                {

                    slots.isFull[i] = true;
                    StartCoroutine(Move(10,i));
                    StartCoroutine(spwnMiniObject(i));
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

        boxCollider.enabled = !boxCollider.enabled;

        while (f < 1)
        {
            f += Time.deltaTime / time;
            transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * 3f;
            transform.position = Vector3.Lerp(transform.position, slots.tempoSlots[i].transform.position, f);
            yield return 0;
        }
    }

    IEnumerator spwnMiniObject(int i)
    {
        

        yield return new WaitForSeconds(.5f);

        Instantiate(miniObj, slots.slots[i].transform, false);
        StartCoroutine(DestroySelf(.2f));
    }

    IEnumerator DestroySelf(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);

        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position + collOffsetHorizontal, transform.position + collOffsetHorizontal + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position - collOffsetHorizontal, transform.position - collOffsetHorizontal + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position + collOffsetVertical, transform.position + collOffsetVertical + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position - collOffsetVertical, transform.position - collOffsetVertical + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position + collOffsetVertical2, transform.position + collOffsetVertical2 + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position - collOffsetVertical2, transform.position - collOffsetVertical2 + Vector3.back * Leight);
    }
}
