using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchCheck : MonoBehaviour
{

    [Header("Distance")]
    public float Leight = 0f;

    [Header("Collider and Layermask")]
    public LayerMask isObjectLayer;

    private bool isObjectHit = false;
    private RaycastHit objectHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,transform.position + Vector3.right * Leight);
    }
}
