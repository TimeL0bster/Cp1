using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MiniObject : MonoBehaviour
{
    [Header("Distance")]
    public int leight = 0;
    public Vector3 collOffsetHorizontal;
    public Vector3 collOffsetVertical;
    public Vector3 collOffsetHorizontal2;
    public Vector3 collOffsetVertical2;
    public Vector3 collOffsetHorizontal3;
    public Vector3 collOffsetVertical3;

    protected Image img;

    private string mySlot = null;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        img = GetComponent<Image>();
    }

    protected void detechAdjacientSlot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + collOffsetVertical + collOffsetHorizontal,Vector3.left * leight);

        while (hit.collider != null && hit.collider.GetComponent<Image>().sprite == img.sprite)
        {
            mySlot = hit.collider.transform.parent.name;
            hit = Physics2D.Raycast(hit.collider.transform.position + collOffsetVertical + collOffsetHorizontal, Vector3.left * leight);
            Debug.Log(mySlot);
        }
    }

    protected void SwitchObjectPosition()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position + collOffsetVertical + collOffsetHorizontal, transform.position + collOffsetVertical + collOffsetHorizontal + Vector3.left * leight);
    }
}
