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
        
    }

    private List<GameObject> MatchChecker()
    {
        RaycastHit2D objectHit = Physics2D.Raycast(transform.position + collOffsetVertical + collOffsetHorizontal, Vector2.right * leight);
        List<GameObject> matchGreenObject = new List<GameObject>();

        while (objectHit.collider != null && objectHit.collider.GetComponent<Image>().sprite == spr[0])
        {
            matchGreenObject.Add(objectHit.collider.gameObject);
            Debug.Log("Green match found");
            objectHit = Physics2D.Raycast(objectHit.collider.transform.position + collOffsetVertical + collOffsetHorizontal, Vector2.right * leight);
        }

        return matchGreenObject;
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

}
