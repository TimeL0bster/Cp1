using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object1 : Object
{

    //float t = 0f;

    // Update is called once per frame
    void Update()
    {
        base.CastRay();
        /*t = Time.deltaTime / 2f;
        Debug.Log(t.ToString());
        transform.position = Vector3.Lerp(transform.position, new Vector3(0,0,0), t);*/
    }

    private void OnMouseDown()
    {
        base.Touched();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position + collOffsetHorizontal, transform.position + collOffsetHorizontal + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position - collOffsetHorizontal, transform.position - collOffsetHorizontal + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position + collOffsetVertical, transform.position + collOffsetVertical + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position - collOffsetVertical, transform.position - collOffsetVertical + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position + collOffsetVertical2, transform.position + collOffsetVertical2 + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position - collOffsetVertical2, transform.position - collOffsetVertical2 + Vector3.back * Leight);
    }
}
