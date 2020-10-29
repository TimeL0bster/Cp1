using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCheck : MatchCheck
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.ClearMatch(base.MatchChecker());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + collOffsetVertical + collOffsetHorizontal, transform.position + collOffsetVertical + collOffsetHorizontal + Vector3.right * leight);
    }
}
