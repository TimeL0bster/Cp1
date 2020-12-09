using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public GameObject pauseWindow;
    public Animator pauseWindowAnim;
    private BoxCollider touchBlocker;

    // Start is called before the first frame update
    void Start()
    {
        touchBlocker = GameObject.FindGameObjectWithTag("TouchBlocker").GetComponent<BoxCollider>();
        pauseWindow = GameObject.FindGameObjectWithTag("PauseWindow");
        pauseWindowAnim = pauseWindow.GetComponent<Animator>();
        pauseWindow.SetActive(false);
    }

    public void PausegameOpen()
    {
        pauseWindow.SetActive(true);
        pauseWindowAnim.SetBool("Dark", true);
        touchBlocker.enabled = true;
    }

    public void TurnOffPauseWindow()
    {
        pauseWindowAnim.SetBool("Light", true);
        pauseWindow.SetActive(false);
        touchBlocker.enabled = false;
    }
}
