using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    [Header("Scene")]
    public string sceneStageName;

    public void SceneChange()
    {
        SceneManager.LoadScene(sceneStageName);
    }
}
