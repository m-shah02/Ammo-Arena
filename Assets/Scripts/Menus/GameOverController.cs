using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    // Boolean to check if the game over screen is active
    private bool isGameOverActive = false;

    void Update()
    {
        // Check if the 'N' key is pressed and the game over screen is active
        if (Input.GetKeyDown(KeyCode.N) && isGameOverActive)
        {
            RetryGame();
        }
    }

    public void ShowGameOverScreen()
    {
        // Activate the game over screen
        isGameOverActive = true;
        // You might also handle other UI visibility or functionality here
    }

    public void HideGameOverScreen()
    {
        // Deactivate the game over screen
        isGameOverActive = false;
        // Additional cleanup or UI adjustments can be handled here
    }

    public void ButtonHandlerRetry()
    {
        RetryGame();
    }

    private void RetryGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void ButtonHandlerExit()
    {
        SceneManager.LoadScene(0);
    }
}
