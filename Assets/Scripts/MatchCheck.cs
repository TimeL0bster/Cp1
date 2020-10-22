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

    private List<GameObject> MatchChecker()
    {
        RaycastHit2D objectHit = Physics2D.Raycast(transform.position + collOffsetHorizontal, Vector2.right * leight); ;
        List<GameObject> matchObject = new List<GameObject>();

        if (objectHit.collider != null && objectHit.collider.GetComponent<Image>().sprite == img.sprite)
        {
            matchObject.Add(objectHit.collider.gameObject);
            //objectHit.collider.GetComponent<BoxCollider2D>().enabled = false;
            objectHit = Physics2D.Raycast(objectHit.collider.transform.position + collOffsetHorizontal, Vector2.right * leight);
            Debug.Log("Match");
        }

        return matchObject;
    }

    private void ClearMatch(List<GameObject> matchChecker)
    {
        List<GameObject> matchObjects = new List<GameObject>();

        for (int i = 0; i < matchChecker.Count; i++)
        {
            matchObjects.Add(matchChecker[i]);
        }

        if (matchObjects.Count >= 2)
        {
            for (int i = 0; i < matchObjects.Count; i++)
            {
                //Destroy(matchObjects[i].gameObject);
                matchObjects[i].GetComponent<Image>().sprite = null;
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + collOffsetHorizontal, transform.position + collOffsetHorizontal + Vector3.right * leight);

    }
}
