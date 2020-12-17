using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    //Handles scene changes
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
