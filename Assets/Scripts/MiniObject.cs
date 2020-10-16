using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniObject : MonoBehaviour
{
    [Header("Distance")]
    public float Leight = 0f;
    public Vector3 collOffsetHorizontal;
    public Vector3 collOffsetVertical;

    [Header("Collider and Layermask")]
    public LayerMask isObjectLayer;

    private SpriteRenderer render;
    private Image img;
    private bool isObjectHit = false;
    private RaycastHit2D objectHit;
    private List<GameObject> matchObject = new List<GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        objectHit = Physics2D.Raycast(transform.position + collOffsetHorizontal, Vector2.right * Leight);
        if (objectHit.collider != null && objectHit.collider.GetComponent<Image>().sprite == img.sprite)
        {
            Debug.Log("Match");
        }
        /*while (objectHit.collider != null && objectHit.collider.GetComponent<SpriteRenderer>().sprite == render.sprite)
        {

        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + collOffsetHorizontal, transform.position + collOffsetHorizontal + Vector3.right * Leight);
        Gizmos.DrawLine(transform.position - collOffsetHorizontal, transform.position - collOffsetHorizontal + Vector3.left * Leight);
    }

}
