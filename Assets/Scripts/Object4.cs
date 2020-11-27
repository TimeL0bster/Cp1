using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object4 : Objects
{
    void Update()
    {
        base.CastRay();
    }

    private void OnMouseDown()
    {
        base.Touched(destroyTimer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position + collOffset1, transform.position + collOffset1 + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position + collOffset2, transform.position + collOffset2 + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position + collOffset3, transform.position + collOffset3 + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position + collOffset4, transform.position + collOffset4 + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position + collOffset5, transform.position + collOffset5 + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position + collOffset6, transform.position + collOffset6 + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position + collOffset7, transform.position + collOffset7 + Vector3.back * Leight);
        Gizmos.DrawLine(transform.position + collOffset8, transform.position + collOffset8 + Vector3.back * Leight);
    }
}
