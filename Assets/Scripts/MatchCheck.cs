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

    protected Image img;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    protected List<GameObject> MatchChecker()
    {
        RaycastHit2D objectHit = Physics2D.Raycast(transform.position + collOffsetHorizontal, Vector2.right * leight); ;
        List<GameObject> matchObject = new List<GameObject>();

        while (objectHit.collider != null && objectHit.collider.GetComponent<Image>().sprite == img.sprite)
        {
            matchObject.Add(objectHit.collider.gameObject);
            Debug.Log("Green hit");
            objectHit = Physics2D.Raycast(objectHit.collider.transform.position + collOffsetHorizontal, Vector2.right * leight);
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
            Debug.Log("Matched");
            for (int i = 0; i < matchObjects.Count; i++)
            {
                //matchObjects[i].GetComponent<Image>().sprite = null;
                Destroy(matchObjects[i].gameObject);
            }
        }
    }

}
