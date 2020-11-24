using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniObject2 : MiniObject
{

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.detechAdjacientSlot();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + collOffsetVertical + collOffsetHorizontal, transform.position + collOffsetVertical + collOffsetHorizontal + Vector3.left * leight1);
        Gizmos.DrawLine(transform.position + collOffsetVertical2 + collOffsetHorizontal2, transform.position + collOffsetVertical2 + collOffsetHorizontal2 + Vector3.left * leight2);
    }
}
