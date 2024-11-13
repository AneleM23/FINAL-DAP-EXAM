using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Set the time delay before transitioning to the next scene
    public float delayTime = 6f;

    void Start()
    {
        // Start the coroutine that will handle the scene transition
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    // Coroutine to handle the time delay and scene transition
    IEnumerator LoadNextSceneAfterDelay()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(delayTime);

        // Load the next scene by its name or index (replace "NextScene" with your scene name)
        SceneManager.LoadScene("Main Menu");
    }
}
