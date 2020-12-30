using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{

    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(Random.Range(-60, -120), 0, Random.Range(50, 130));
        transform.eulerAngles = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotationReturnToOrigin()
    {
        var desireRotation = Quaternion.Euler(-90, 0, 90);
        transform.rotation = Quaternion.Lerp(transform.rotation, desireRotation, Time.deltaTime * 5f);
    }
}
