using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] GameObject itemsPanel;

    public GameObject pauseMenuUI; // Assign this in the inspector for your Pause Menu
    public GameObject gameOverUI;  // Assign this in the inspector for your Game Over Menu

    public List<GameObject> menuPanels;

    private bool isPaused = false;

    // Function to pause the game
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu UI
        Time.timeScale = 0f;         // Freeze the game
        isPaused = true;             // Set pause flag
    }

    // Function to resume the game
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu UI
        Time.timeScale = 1f;          // Resume the game
        isPaused = false;             // Reset pause flag
    }

    // Function to toggle between pause and resume
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    // Function to restart the game/scene
    public void RestartGame()
    {
        Time.timeScale = 1f; // Ensure the game runs at normal speed
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    // Function to quit the game (for builds)
    public void QuitGame()
    {
        Application.Quit(); // Quits the game application
        Debug.Log("Game is quitting..."); // Just for testing in the Unity Editor
    }

    // Example function for game over
    public void GameOver()
    {
        gameOverUI.SetActive(true);  // Show the Game Over screen
        Time.timeScale = 0f;         // Freeze the game
    }

    // For detecting the Escape key to trigger pause in Update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void SetActiveGameObject(int index)
    {
        // Loop through the list of GameObjects
        for (int i = 0; i < menuPanels.Count; i++)
        {
            if (i == index)
            {
                // Activate the selected GameObject
                menuPanels[i].SetActive(true);
            }
            else
            {
                // Deactivate all other GameObjects
                menuPanels[i].SetActive(false);
            }
        }
    }

    public void ActivateOptionsPanel()
    {
        SetActiveGameObject(1);
    }

    public void ActivateItemsPanel()
    {
        SetActiveGameObject(0);
    }
}
