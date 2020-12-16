using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimation : MonoBehaviour
{

    private Animator emotionAnim;

    // Start is called before the first frame update
    void Start()
    {
        emotionAnim = GetComponent<Animator>();
        emotionAnim.SetInteger("Emotion", Random.Range(0, 10));
;    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
