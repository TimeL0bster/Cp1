using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPosSwtch : MonoBehaviour
{

    [Header("Distance")]
    public int leight = 0;
    public Vector3 collOffSetRay1;
    public Vector3 collOffSetRay2;

    [Header("Sprites")]
    public Sprite[] miniObjectSprite;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ObjSwtch()
    {
        RaycastHit2D[] objectHit2 = Physics2D.RaycastAll(transform.position + collOffSetRay1, Vector2.right * leight);

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position + collOffSetRay1, transform.position + collOffSetRay1 + Vector3.right * leight);
    }
}
