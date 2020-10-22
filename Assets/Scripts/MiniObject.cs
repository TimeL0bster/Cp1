using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MiniObject : MonoBehaviour
{
    [Header("Distance")]
    public float leight = 0f;
    public Vector3 collOffsetHorizontal;

    [Header("Collider and Layermask")]
    public LayerMask isObjectLayer;

    private Image img;
    private RaycastHit2D objectHit;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (objectHit.collider == null)
        {
            objectHit = Physics2D.Raycast(transform.position + collOffsetHorizontal, Vector2.right * leight);
            Debug.Log("Nothing is hit by me");
        }
        else
        {
            MatchingObject(objectHit);
        }*/
    }

    private void MatchingObject(RaycastHit2D objectHit)
    {
        /*if (objectHit.collider != null && objectHit.collider.GetComponent<Image>().sprite == img.sprite)
        {
            Debug.Log("Match");
            objectHit = Physics2D.Raycast(objectHit.collider.transform.position + collOffsetHorizontal, Vector2.right * leight);
        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position + collOffsetHorizontal, transform.position + collOffsetHorizontal + Vector3.right * leight);
    }

}
