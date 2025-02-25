﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AllCheck : MonoBehaviour
{

    [Header("Distance")]
    public float leight = 0f;
    public Vector3 collOffSetRay1;

    [Header("Sprites")]
    public Sprite[] spr;

    [Header("Completion bar")]
    public CompletionBar completionBar;

    private float point = 0;
    private RaycastHit protoHit;
    private BoxCollider touchBlocker;
    private Slots slots;

    private void Start()
    {
        point = 0;
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        touchBlocker = GameObject.FindGameObjectWithTag("TouchBlocker").GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        ClearMatch(MatchObjCheck1());
        ClearMatch(MatchObjCheck2());
        ClearMatch(MatchObjCheck3());
        ClearMatch(MatchObjCheck4());
        ClearMatch(MatchObjCheck5());
    }

    private List<GameObject> MatchObjCheck1()
    {
        bool isObjHit = Physics.Raycast(transform.position + collOffSetRay1, Vector2.right * leight);
        RaycastHit[] objectHit1 = Physics.RaycastAll(transform.position + collOffSetRay1, Vector2.right * leight);
        List<GameObject> matchObject1 = new List<GameObject>();

        if (isObjHit == true)
        {
            foreach (RaycastHit hit in objectHit1)
            {
                
                if (hit.collider.GetComponent<SpriteRenderer>().sprite == spr[0])
                {
                    Debug.Log("hit");
                    if (matchObject1.Count < 3)
                    {
                        matchObject1.Add(hit.collider.gameObject);
                    }
                }
            }
        }

        return matchObject1;
    }

    private List<GameObject> MatchObjCheck2()
    {
        bool isObjHit = Physics.Raycast(transform.position + collOffSetRay1, Vector2.right * leight);
        RaycastHit[] objectHit2 = Physics.RaycastAll(transform.position + collOffSetRay1, Vector2.right * leight);
        List<GameObject> matchObject2 = new List<GameObject>();

        if (isObjHit == true)
        {
            foreach (RaycastHit hit in objectHit2)
            {
                
                if (hit.collider.GetComponent<SpriteRenderer>().sprite == spr[1])
                {
                    Debug.Log("hit");
                    if (matchObject2.Count < 3)
                    {
                        matchObject2.Add(hit.collider.gameObject);
                    }
                }
            }
        }

        return matchObject2;
    }

    private List<GameObject> MatchObjCheck3()
    {
        bool isObjHit = Physics.Raycast(transform.position + collOffSetRay1, Vector2.right * leight);
        RaycastHit[] objectHit3 = Physics.RaycastAll(transform.position + collOffSetRay1, Vector2.right * leight);
        List<GameObject> matchObject3 = new List<GameObject>();

        if (isObjHit == true)
        {
            foreach (RaycastHit hit in objectHit3)
            {
                if (hit.collider.GetComponent<SpriteRenderer>().sprite == spr[2])
                {
                    if (matchObject3.Count < 3)
                    {
                        matchObject3.Add(hit.collider.gameObject);
                    }
                }
            }
        }

        return matchObject3;
    }

    private List<GameObject> MatchObjCheck4()
    {
        bool isObjHit = Physics.Raycast(transform.position + collOffSetRay1, Vector2.right * leight);
        RaycastHit[] objectHit4 = Physics.RaycastAll(transform.position + collOffSetRay1, Vector2.right * leight);
        List<GameObject> matchObject4 = new List<GameObject>();

        if (isObjHit == true)
        {
            foreach (RaycastHit hit in objectHit4)
            {
                if (hit.collider.GetComponent<SpriteRenderer>().sprite == spr[3])
                {
                    if (matchObject4.Count < 3)
                    {
                        matchObject4.Add(hit.collider.gameObject);
                    }
                }
            }
        }

        return matchObject4;
    }

    private List<GameObject> MatchObjCheck5()
    {
        bool isObjHit = Physics.Raycast(transform.position + collOffSetRay1, Vector2.right * leight);
        RaycastHit[] objectHit5 = Physics.RaycastAll(transform.position + collOffSetRay1, Vector2.right * leight);
        List<GameObject> matchObject5 = new List<GameObject>();

        if (isObjHit == true)
        {
            
            foreach (RaycastHit hit in objectHit5)
            {
                if (hit.collider.GetComponent<SpriteRenderer>().sprite == spr[4])
                {
                    if (matchObject5.Count < 3)
                    {
                        matchObject5.Add(hit.collider.gameObject);
                    }
                }
            }
        }

        return matchObject5;
    }

    private void ClearMatch(List<GameObject> matchChecker)
    {
        List<GameObject> matchedObjects = new List<GameObject>();
        GameObject[] matchedObj = new GameObject[3];

        matchedObjects.AddRange(matchChecker);
        
        if (matchedObjects.Count == 3)
        {
            
            for (int i = 0; i < 3; i++)
            {
                matchedObj[i] = matchedObjects[i];
                //StartCoroutine(ShrunkMatchedObj(matchedObj[i].gameObject));
                StartCoroutine(OnWaitDestroyObject(matchedObj[i].gameObject));
            }

        }
    }

    IEnumerator OnWaitDestroyObject(GameObject matchObjects)
    {

        
        //StartCoroutine(ShrunkMatchedObj(matchObjects));
        StartCoroutine(onWaitShruckObj(matchObjects));

        yield return new WaitForSeconds(.8f);

        //touchBlocker.enabled = false;
        Destroy(matchObjects);
    }

    IEnumerator ShrunkMatchedObj(GameObject matchObject)
    {
        
        float f = 0;

        while (f < 1)
        {
            f += Time.deltaTime / 10f;
            if (matchObject != null && matchObject.transform.localScale.x >= 0)
            {
                matchObject.transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime /2f;
            }
            yield return null;
        }

    }

    IEnumerator onWaitShruckObj(GameObject matchObj)
    {

        yield return new WaitForSeconds(.6f);

        StartCoroutine(ShrunkMatchedObj(matchObj));

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position + collOffSetRay1, transform.position + collOffSetRay1 + Vector3.right * leight);
    }

}
