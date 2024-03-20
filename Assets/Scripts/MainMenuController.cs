using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void ButtonHandlerPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonHandlerExit() 
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
