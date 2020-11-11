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

    // Update is called once per frame
    void Update()
    {
        ClearMatch(MatchObjCheck1());
        ClearMatch(MatchObjCheck2());
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

    private void ClearMatch(List<GameObject> matchChecker)
    {
        List<GameObject> matchedObjects = new List<GameObject>();

        for (int i = 0; i < matchChecker.Count; i++)
        {
            matchedObjects.AddRange(matchChecker);
        }

        if (matchedObjects.Count > 4)
        {
            Debug.Log("Matched");
            for (int i = 0; i < matchedObjects.Count; i++)
            {
                //matchObjects[i].GetComponent<Image>().sprite = null;
                //Destroy(matchObjects[i].gameObject);
                StartCoroutine(OnWaitDestroyObject(matchedObjects[i].gameObject));
            }
        }
    }

    IEnumerator OnWaitDestroyObject(GameObject matchObjects)
    {
        yield return new WaitForSeconds(.2f);

        Destroy(matchObjects);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position + collOffSetRay1, transform.position + collOffSetRay1 + Vector3.right * leight);
    }

}
