using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    [Header("LevelCheck")]
    public int currentLevel;
    public int levelPass;

    [Header("Scene")]
    public string nextLevel;

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("Currentlv", 1);
    }

    public void SaveWipe()
    {
        currentLevel = 1;
    }

    public void LevelCheck()
    {

        if (currentLevel == 1)
        {
            SceneManager.LoadScene("Level1");
        }
        else if (currentLevel == 2)
        {
            Debug.Log(currentLevel);
        }
        else if (currentLevel == 3)
        {
            Debug.Log(currentLevel);
        }
        else if (currentLevel == 4)
        {
            Debug.Log(currentLevel);
        }
        else if (currentLevel == 5)
        {
            Debug.Log(currentLevel);
        }
        else if (currentLevel == 6)
        {
            Debug.Log(currentLevel);
        }
        else if (currentLevel == 7)
        {
            Debug.Log(currentLevel);
        }

    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Currentlv", levelPass);
        SceneManager.LoadScene(nextLevel);

    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
