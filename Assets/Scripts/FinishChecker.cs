using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishChecker : MonoBehaviour
{

    private GameObject darkScreen;
    private GameObject levelComplete;
    private Animator darkScreenAnim;
    private Animator levelCompleteAnim;
    private Slots slot;
    private BoxCollider touchBlocker;
    private float i = 0;
    private float k = 0;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("FinishChecker");
        slot = GameObject.FindGameObjectWithTag("Slots").GetComponent<Slots>();
        touchBlocker = GameObject.FindGameObjectWithTag("TouchBlocker").GetComponent<BoxCollider>();
        darkScreen = GameObject.FindGameObjectWithTag("DarkScreen");
        levelComplete = GameObject.FindGameObjectWithTag("LevelComplete");
        darkScreenAnim = darkScreen.GetComponent<Animator>();
        levelCompleteAnim = levelComplete.GetComponent<Animator>();
        darkScreen.SetActive(false);
        levelComplete.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        GameoverCheck();
    }

    private void GameoverCheck()
    {
        if (slot.isFull[0] == true &&
            slot.isFull[1] == true &&
            slot.isFull[2] == true &&
            slot.isFull[3] == true &&
            slot.isFull[4] == true &&
            slot.isFull[5] == true &&
            slot.isFull[6] == true)
        {

            if (i <= 2f)
            {
                i += Time.deltaTime;
            }
            
            if (i > 2 && i < 3)
            {
                Debug.Log("Gameover");
                touchBlocker.enabled = true;
                darkScreen.SetActive(true);
                darkScreenAnim.SetBool("Dark",true);
                i = 4;
            }

        }

        if (GameObject.FindGameObjectWithTag("Object1") == null 
            && GameObject.FindGameObjectWithTag("Object2") == null 
            && GameObject.FindGameObjectWithTag("Object3") == null 
            && GameObject.FindGameObjectWithTag("Object4") == null
            && GameObject.FindGameObjectWithTag("MiniObj") == null)
        {

            if (k <= .8f)
            {
                k += Time.deltaTime;
            }

            if (k > .8f && k < 2)
            {
                Debug.Log("Win");
                touchBlocker.enabled = true;
                levelComplete.SetActive(true);
                levelCompleteAnim.SetBool("Dark", true);
                k = 4;
            }

        }

    }

}
