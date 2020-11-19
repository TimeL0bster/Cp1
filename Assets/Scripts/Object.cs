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

    [Header("Mini Gameobject")]
    public GameObject miniObject;
    public GameObject[] miniObjs;

    private BoxCollider boxCollider;
    private Animator anim;
    private Image img;
    private bool isObjectAbove = false;

    protected Slots slots;
    protected MiniObjectPool objectPooler;

    protected virtual void Start()
    {
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        img = GetComponent<Image>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void CastRay()
    {
        isObjectAbove = Physics.Raycast(transform.position + collOffsetHorizontal, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position - collOffsetHorizontal, Vector3.back, Leight, isObjectLayer)
            || Physics.Raycast(transform.position + collOffsetVertical, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position - collOffsetVertical, Vector3.back, Leight, isObjectLayer)
            || Physics.Raycast(transform.position + collOffsetVertical2, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position - collOffsetVertical2, Vector3.back, Leight, isObjectLayer);

        if (!isObjectAbove)
        {
            img.color = new Color32(255,255,255,255);
        }
        else
        {
            img.color = new Color32(80, 80, 80, 255);
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
                    StartCoroutine(Move(10,i));   
                    break;
                }
            }
        }
    }

    IEnumerator Move(float time, int i)
    {
        float f = 0;

        while (f < 1)
        {
            f += Time.deltaTime/time;
            boxCollider.enabled = !boxCollider.enabled;
            transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * 2.5f;
            transform.position = Vector3.Lerp(transform.position, slots.tempoSlots[i].transform.position, f);
            StartCoroutine(spwnMiniObject(i));
            StartCoroutine(DestroySelf(.5f));
            yield return 0;
        }
    }

    IEnumerator spwnMiniObject(int i)
    {
        slots.isFull[i] = true;

        yield return new WaitForSeconds(.5f);

        Instantiate(miniObject, slots.slots[i].transform, false);

        /*if (gameObject.CompareTag("Obj1"))
        {
            GameObject mnObj = MiniObjectPool.SharedInstance.GetPooledObject1();
            mnObj.SetActive(true);
        }
        else if (gameObject.CompareTag("Obj2"))
        {
            GameObject mnObj = MiniObjectPool.SharedInstance.GetPooledObject2();
            mnObj.SetActive(true);
        }*/

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
