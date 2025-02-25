﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchCheck : MonoBehaviour
{

    [Header("Distance")]
    public float leight = 0f;
    public Vector3 collOffsetHorizontal;
    public Vector3 collOffsetVertical;

    [Header("Log signal")]
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
        RaycastHit2D objectHit = Physics2D.Raycast(transform.position + collOffsetVertical + collOffsetHorizontal, Vector2.right * leight);
        List<GameObject> matchObject = new List<GameObject>();

        while (objectHit.collider != null && objectHit.collider.GetComponent<Image>().sprite == img.sprite)
        {
            Debug.Log("Match found");
            matchObject.Add(objectHit.collider.gameObject);
            objectHit = Physics2D.Raycast(objectHit.collider.transform.position + collOffsetVertical + collOffsetHorizontal, Vector2.right * leight);
        }

        return matchObject;
    }

    protected void ClearMatch(List<GameObject> matchChecker)
    {
        List<GameObject> matchedObjects = new List<GameObject>();

        for (int i = 0; i < matchChecker.Count; i++)
        {
            matchedObjects.AddRange(matchChecker);
        }

        if (matchedObjects.Count > 4)
        {
            Debug.Log(matchedLog);
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
