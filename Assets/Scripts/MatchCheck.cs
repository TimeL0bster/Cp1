using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchCheck : MonoBehaviour
{

    [Header("Distance")]
    public float leight = 0f;
    public Vector3 collOffsetHorizontal;

    private RaycastHit2D objectHit;
    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if (objectHit.collider == null)
        {
            objectHit = Physics2D.Raycast(transform.position + collOffsetHorizontal, Vector2.right * leight);
        }
        else
        {
            MatchChecker(objectHit);
        }

    }

    private void MatchChecker(RaycastHit2D objectHit)
    {
        if (objectHit.collider != null)
        {
            if (objectHit.collider.GetComponent<Image>().sprite == img.sprite)
            {
                Debug.Log("Match");
                objectHit = Physics2D.Raycast(objectHit.collider.transform.position + collOffsetHorizontal, Vector2.right * leight);
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(objectHit.collider.transform.position + collOffsetHorizontal, transform.position + collOffsetHorizontal + Vector3.right * leight);
        
    }
}
