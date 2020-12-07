using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    [Header("LevelCheck")]
    public bool[] Level;

    [Header("Scene")]
    public string nextLevel;

    public void NextLevel()
    {

        SceneManager.LoadScene(nextLevel);

    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
