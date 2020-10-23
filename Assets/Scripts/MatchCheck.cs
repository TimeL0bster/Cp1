using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchCheck : MonoBehaviour
{

    [Header("Distance")]
    public float leight = 0f;
    public Vector3 collOffsetHorizontal;

    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ClearMatch(MatchChecker());
    }

    public List<GameObject> MatchChecker()
    {
        RaycastHit2D objectHit = Physics2D.Raycast(transform.position + collOffsetHorizontal, Vector2.right * leight); ;
        List<GameObject> matchObject = new List<GameObject>();

        while (objectHit.collider != null && objectHit.collider.GetComponent<Image>().sprite == img.sprite)
        {
            matchObject.Add(objectHit.collider.gameObject);
            objectHit = Physics2D.Raycast(objectHit.collider.transform.position + collOffsetHorizontal, Vector2.right * leight);
            //Debug.Log("Match");
        }

        return matchObject;
    }

    public void ClearMatch(List<GameObject> matchChecker)
    {
        List<GameObject> matchObjects = new List<GameObject>();

        for (int i = 0; i < matchChecker.Count; i++)
        {
            matchObjects.AddRange(matchChecker);
        }

        if (matchObjects.Count > 4)
        {
            for (int i = 0; i < matchObjects.Count; i++)
            {
                Debug.Log("Matched");
                matchObjects[i].GetComponent<Image>().sprite = null;
                //Destroy(matchObjects[i].gameObject);
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + collOffsetHorizontal, transform.position + collOffsetHorizontal + Vector3.right * leight);
    }
}
