using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCheck : MatchCheck
{
    
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        base.ClearMatch(base.MatchChecker());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + collOffsetVertical + collOffsetHorizontal, transform.position + collOffsetVertical + collOffsetHorizontal + Vector3.right * leight);
    }
}
