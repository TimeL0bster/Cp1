using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCheck : MatchCheck
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.ClearMatch(base.MatchChecker());
    }

    private void ClearMatchRed(List<GameObject> matchChecker)
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
                //matchObjects[i].GetComponent<Image>().sprite = null;
                Destroy(matchObjects[i].gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + collOffsetHorizontal, transform.position + collOffsetHorizontal + Vector3.right * leight);
    }
}
