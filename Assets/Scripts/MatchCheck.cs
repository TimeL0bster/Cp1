using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchCheck : MonoBehaviour
{

    [Header("Distance")]
    public float leight = 0f;
    public Vector3 collOffsetHorizontal;
    public Vector3 collOffsetVertical;

    [Header("Naming")]
    public string signalLog;
    public string matchedLog;


    protected Image img;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        img = GetComponent<Image>();
    }

    protected List<GameObject> MatchChecker()
    {
        RaycastHit2D objectHit = Physics2D.Raycast(transform.position + collOffsetVertical + collOffsetHorizontal, Vector2.right * leight); ;
        List<GameObject> matchObject = new List<GameObject>();

        while (objectHit.collider != null && objectHit.collider.GetComponent<Image>().sprite == img.sprite)
        {
            matchObject.Add(objectHit.collider.gameObject);
            Debug.Log(signalLog);
            objectHit = Physics2D.Raycast(objectHit.collider.transform.position + collOffsetVertical + collOffsetHorizontal, Vector2.right * leight);
        }

        return matchObject;
    }

    protected void ClearMatch(List<GameObject> matchChecker)
    {
        List<GameObject> matchObjects = new List<GameObject>();

        for (int i = 0; i < matchChecker.Count; i++)
        {
            matchObjects.AddRange(matchChecker);
        }

        if (matchObjects.Count > 4)
        {
            Debug.Log(matchedLog);
            for (int i = 0; i < matchObjects.Count; i++)
            {
                //matchObjects[i].GetComponent<Image>().sprite = null;
                //Destroy(matchObjects[i].gameObject);
                StartCoroutine(OnWaitDestroyObject(matchObjects[i].gameObject));
            }
        }
    }

    IEnumerator OnWaitDestroyObject(GameObject matchObjects)
    {
        yield return new WaitForSeconds(.2f);

        Destroy(matchObjects);
    }

}
