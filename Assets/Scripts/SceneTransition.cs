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
            SceneManager.LoadScene("Level2");
        }
        else if (currentLevel == 3)
        {
            SceneManager.LoadScene("Level3");
        }
        else if (currentLevel == 4)
        {
            SceneManager.LoadScene("Level4");
        }
        else if (currentLevel == 5)
        {
            SceneManager.LoadScene("Level5");
        }
        else if (currentLevel == 6)
        {
            SceneManager.LoadScene("Level6");
        }
        else if (currentLevel == 7)
        {
            SceneManager.LoadScene("Level7");
        }
        else if (currentLevel == 8)
        {
            SceneManager.LoadScene("Level8");
        }
        else if (currentLevel == 9)
        {
            SceneManager.LoadScene("Level9");
        }
        else if (currentLevel == 10)
        {
            SceneManager.LoadScene("Level10");
        }

    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Currentlv", levelPass);
        SceneManager.LoadScene(nextLevel);

    }

    public void ResetLevel()
    {
        Debug.Log("Reset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToStartScene()
    {
        SceneManager.LoadScene("Start");
    }

}
