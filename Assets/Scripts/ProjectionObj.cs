using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionObj : MonoBehaviour
{

    private Slots slot;

    // Start is called before the first frame update
    void Start()
    {
        slot = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        for (int i = 0; i < slot.tempoSlots.Length; i++)
        {
            if (slot.isFull[i] == false)
            {
                StartCoroutine(Move(10, i));
                break;
            }
        }

    }

    IEnumerator Move(float time, int i)
    {
        float f = 0;

        while (f < 1)
        {
            f += Time.deltaTime / time;
            transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * 3f;
            transform.position = Vector3.Lerp(transform.position, slot.tempoSlots[i].transform.position, f);
            yield return 0;
        }

        //StartCoroutine(DestroySelf(0.5f));

    }

    IEnumerator DestroySelf(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);

        Destroy(this.gameObject);
    }


}
