using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewButtonManager : MonoBehaviour
{
    //Loads the next level
    public void ButtonMoveScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}
