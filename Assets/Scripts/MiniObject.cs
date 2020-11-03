using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MiniObject : MonoBehaviour
{
    [Header("Distance")]
    public int leight1 = 0;
    public int leight2 = 0;
    public Vector3 collOffsetHorizontal;
    public Vector3 collOffsetVertical;
    public Vector3 collOffsetHorizontal2;
    public Vector3 collOffsetVertical2;
    public Vector3 collOffsetHorizontal3;
    public Vector3 collOffsetVertical3;

    [Header("Sprites")]
    public Sprite[] miniObjectSprite;

    protected Image img;

    private string mySlot = null;
    private float i = 0f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        img = GetComponent<Image>();
    }

    protected void detechAdjacientSlot()
    {
        RaycastHit2D miniObjectHitUpperLeft = Physics2D.Raycast(transform.position + collOffsetVertical + collOffsetHorizontal, Vector3.left * leight1);
        RaycastHit2D miniObjectHitLowerLeft = Physics2D.Raycast(transform.position + collOffsetVertical2 + collOffsetHorizontal2, Vector3.left * leight2);
        List<GameObject> objectHit = new List<GameObject>();

        if (miniObjectHitLowerLeft.collider != null && miniObjectHitLowerLeft.collider.GetComponent<Image>().sprite == miniObjectSprite[0])
        {
            /*objectHit.Add(miniObjectHit.collider.gameObject);
            mySlot = miniObjectHit.collider.transform.parent.name;
            Debug.Log(mySlot);
            */
            if (miniObjectHitUpperLeft.collider != null && miniObjectHitUpperLeft.collider.GetComponent<Image>().sprite == img.sprite)
            {
                i = Time.deltaTime / .2f;
                transform.SetParent(miniObjectHitLowerLeft.collider.transform.parent);
                transform.position = Vector3.Lerp(transform.position, miniObjectHitLowerLeft.collider.transform.position, i);
            }

        }

    }

    protected void SwitchObjectPosition()
    {
        //transform.position = Vector3.Lerp();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position + collOffsetVertical + collOffsetHorizontal, transform.position + collOffsetVertical + collOffsetHorizontal + Vector3.left * leight1);
    }
}
