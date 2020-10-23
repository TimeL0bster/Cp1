using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject miniObject;

    private Animator anim;
    private Slots slots;

    private bool isObjectAbove = false;

    // Start is called before the first frame update
    void Start()
    {
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
    }

    // Update is called once per frame
    void Update()
    {
        isObjectAbove = Physics.Raycast(transform.position + collOffsetHorizontal, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position - collOffsetHorizontal, Vector3.back, Leight, isObjectLayer)
            || Physics.Raycast(transform.position + collOffsetVertical, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position - collOffsetVertical, Vector3.back, Leight, isObjectLayer)
            || Physics.Raycast(transform.position + collOffsetVertical2, Vector3.back, Leight, isObjectLayer) || Physics.Raycast(transform.position - collOffsetVertical2, Vector3.back, Leight, isObjectLayer);
    }

    private void OnMouseDown()
    {
        if (!isObjectAbove)
        {
            for (int i = 0; i < slots.slots.Length; i++)
            {
                if (slots.isFull[i] == false)
                {
                    slots.isFull[i] = true;
                    Instantiate(miniObject, slots.slots[i].transform, false);
                    Destroy(this.gameObject);
                    break;
                }
            }
        }

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
