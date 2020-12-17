using System.Collections;
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

    private RaycastHit2D protoHit;
    private BoxCollider touchBlocker;
    private Slots slots;

    private void Start()
    {
        slots = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        touchBlocker = GameObject.FindGameObjectWithTag("TouchBlocker").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        ClearMatch(MatchObjCheck1());
        ClearMatch(MatchObjCheck2());
        ClearMatch(MatchObjCheck3());
        ClearMatch(MatchObjCheck4());
        ClearMatch(MatchObjCheck5());
    }

    private List<GameObject> MatchObjCheck1()
    {
        protoHit = Physics2D.Raycast(transform.position + collOffSetRay1, Vector2.right * leight);
        RaycastHit2D[] objectHit1 = Physics2D.RaycastAll(transform.position + collOffSetRay1, Vector2.right * leight);
        List<GameObject> matchObject1 = new List<GameObject>();

        if (protoHit.collider != null)
        {
            foreach (RaycastHit2D hit in objectHit1)
            {
                if (hit.collider.GetComponent<Image>().sprite == spr[0])
                {
                    matchObject1.Add(hit.collider.gameObject);
                }
            }
        }

        return matchObject1;
    }

    private List<GameObject> MatchObjCheck2()
    {
        protoHit = Physics2D.Raycast(transform.position + collOffSetRay1, Vector2.right * leight);
        RaycastHit2D[] objectHit2 = Physics2D.RaycastAll(transform.position + collOffSetRay1, Vector2.right * leight);
        List<GameObject> matchObject2 = new List<GameObject>();

        if (protoHit.collider != null)
        {
            foreach (RaycastHit2D hit in objectHit2)
            {
                if (hit.collider.GetComponent<Image>().sprite == spr[1])
                {
                    matchObject2.Add(hit.collider.gameObject);
                }
            }
        }

        return matchObject2;
    }

    private List<GameObject> MatchObjCheck3()
    {
        protoHit = Physics2D.Raycast(transform.position + collOffSetRay1, Vector2.right * leight);
        RaycastHit2D[] objectHit3 = Physics2D.RaycastAll(transform.position + collOffSetRay1, Vector2.right * leight);
        List<GameObject> matchObject3 = new List<GameObject>();

        if (protoHit.collider != null)
        {
            foreach (RaycastHit2D hit in objectHit3)
            {
                if (hit.collider.GetComponent<Image>().sprite == spr[2])
                {
                    matchObject3.Add(hit.collider.gameObject);
                }
            }
        }

        return matchObject3;
    }

    private List<GameObject> MatchObjCheck4()
    {
        protoHit = Physics2D.Raycast(transform.position + collOffSetRay1, Vector2.right * leight);
        RaycastHit2D[] objectHit4 = Physics2D.RaycastAll(transform.position + collOffSetRay1, Vector2.right * leight);
        List<GameObject> matchObject4 = new List<GameObject>();

        if (protoHit.collider != null)
        {
            foreach (RaycastHit2D hit in objectHit4)
            {
                if (hit.collider.GetComponent<Image>().sprite == spr[3])
                {
                    matchObject4.Add(hit.collider.gameObject);
                }
            }
        }

        return matchObject4;
    }

    private List<GameObject> MatchObjCheck5()
    {
        protoHit = Physics2D.Raycast(transform.position + collOffSetRay1, Vector2.right * leight);
        RaycastHit2D[] objectHit5 = Physics2D.RaycastAll(transform.position + collOffSetRay1, Vector2.right * leight);
        List<GameObject> matchObject5 = new List<GameObject>();

        if (protoHit.collider != null)
        {
            foreach (RaycastHit2D hit in objectHit5)
            {
                if (hit.collider.GetComponent<Image>().sprite == spr[4])
                {
                    matchObject5.Add(hit.collider.gameObject);
                }
            }
        }

        return matchObject5;
    }

    private void ClearMatch(List<GameObject> matchChecker)
    {
        List<GameObject> matchedObjects = new List<GameObject>();

        matchedObjects.AddRange(matchChecker);

        if (matchedObjects.Count >= 3)
        {
            
            for (int i = 0; i < matchedObjects.Count; i++)
            {
                //StartCoroutine(ShrunkMatchedObj(matchedObjects[i].gameObject));
                StartCoroutine(OnWaitDestroyObject(matchedObjects[i].gameObject));
            }

        }
    }

    IEnumerator OnWaitDestroyObject(GameObject matchObjects)
    {

        StartCoroutine(ShrunkMatchedObj(matchObjects));

        yield return new WaitForSeconds(.5f);

        touchBlocker.enabled = false;
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
                if (touchBlocker.enabled == false)
                {
                    touchBlocker.enabled = true;
                }
            }
            yield return null;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position + collOffSetRay1, transform.position + collOffSetRay1 + Vector3.right * leight);
    }

}
