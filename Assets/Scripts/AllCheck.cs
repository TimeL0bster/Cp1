using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllCheck : MonoBehaviour
{

    [Header("Distance")]
    public float leight = 0f;
    public Vector3 collOffsetHorizontal;
    public Vector3 collOffsetVertical;

    [Header("Sprites")]
    public Sprite[] spr;

    // Update is called once per frame
    void Update()
    {
        ClearMatch(MatchObj1Checker());
    }

    private List<GameObject> MatchObj1Checker()
    {
        RaycastHit2D object1Hit = Physics2D.Raycast(transform.position + collOffsetVertical + collOffsetHorizontal, Vector2.right * leight);
        List<GameObject> matchObject1 = new List<GameObject>();

        while (object1Hit.collider != null && object1Hit.collider.GetComponent<Image>().sprite == spr[0])
        {
            matchObject1.Add(object1Hit.collider.gameObject);
            Debug.Log("Obj1 match found");
            object1Hit = Physics2D.Raycast(object1Hit.collider.transform.position + collOffsetVertical + collOffsetHorizontal, Vector2.right * leight);
        }

        return matchObject1;
    }

    private List<GameObject> MatchObj2Check()
    {
        RaycastHit2D object2Hit = Physics2D.Raycast(transform.position + collOffsetVertical + collOffsetHorizontal, Vector2.right * leight);
        List<GameObject> matchObject2 = new List<GameObject>();

        while (object2Hit.collider != null && object2Hit.collider.GetComponent<Image>().sprite == spr[1])
        {
            matchObject2.Add(object2Hit.collider.gameObject);
            Debug.Log("Obj2 match found");
            object2Hit = Physics2D.Raycast(object2Hit.collider.transform.position + collOffsetVertical + collOffsetHorizontal, Vector2.right * leight);
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
        Gizmos.DrawLine(transform.position + collOffsetVertical + collOffsetHorizontal, transform.position + collOffsetVertical + collOffsetHorizontal + Vector3.right * leight);
    }

}
