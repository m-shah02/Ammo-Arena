using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    void Update()
    {
        // Check if the 'N' key is pressed
        if (Input.GetKeyDown(KeyCode.N))
        {
            ReloadScene();
        }

        // Check if the 'M' key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            ReturnToMainMenu();
        }
    }

    public void ReloadScene()
    {
        // Get the current active scene and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Debug.Log("Scene reloaded");
    }

    // Call this function to return to the main menu
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
