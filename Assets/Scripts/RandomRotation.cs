using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{

    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(Random.Range(-78,-120), 0, Random.Range(120, 65));
        transform.eulerAngles = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
