using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenCheck : MatchCheck
{


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //ClearMatchGreen(GreenChecker());
        base.ClearMatch(base.MatchChecker());
    }

    private List<GameObject> GreenChecker()
    {
        RaycastHit2D objectHit = Physics2D.Raycast(transform.position + collOffsetHorizontal, Vector2.right * leight); ;
        List<GameObject> matchGreens = new List<GameObject>();

        while (objectHit.collider != null && objectHit.collider.GetComponent<Image>().sprite == img.sprite)
        {
            matchGreens.Add(objectHit.collider.gameObject);
            Debug.Log("Green hit");
            objectHit = Physics2D.Raycast(objectHit.collider.transform.position + collOffsetHorizontal, Vector2.right * leight);
        }

        return matchGreens;
    }

    private void ClearMatchGreen(List<GameObject> matchGreens)
    {
        List<GameObject> matchGreen = new List<GameObject>();

        for (int i = 0; i < matchGreens.Count; i++)
        {
            matchGreen.AddRange(matchGreens);
        }

        if (matchGreen.Count > 4)
        {
            for (int i = 0; i < matchGreen.Count; i++)
            {
                Debug.Log("Matched");
                //matchObjects[i].GetComponent<Image>().sprite = null;
                Destroy(matchGreen[i].gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position + collOffsetHorizontal, transform.position + collOffsetHorizontal + Vector3.right * leight);
    }
}
