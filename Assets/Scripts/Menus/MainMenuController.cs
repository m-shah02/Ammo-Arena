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

    public void ButtonHandlerPlay2()
    {
        SceneManager.LoadScene(2);
    }
    public void ButtonHandlerPlay3()
    {
        SceneManager.LoadScene(3);

    }

    public void ButtonHandlerPlay4()
    {
        SceneManager.LoadScene(4);
    }

    public void ButtonHandlerExit() 
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
