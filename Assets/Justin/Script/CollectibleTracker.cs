using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollectibleTracker : MonoBehaviour
{
    public Text progressText;        // Text component to show progress
    public int totalCollectibles = 5; // Total number of collectibles in the game
    private int collectiblesCollected = 0; // Number of collectibles collected

    private void Start()
    {
        // Initialize the progress text
        UpdateProgressText();
        progressText.gameObject.SetActive(false); // Hide the progress text initially
    }

    // Call this function whenever a collectible is collected
    public void UpdateProgress()
    {
        collectiblesCollected++; // Increase the number of collectibles collected
        UpdateProgressText();    // Update the progress text

        // Show progress text for 3 seconds and then hide it
        StartCoroutine(ShowProgressForDuration(3f));
    }

    // Update the progress text to show the current collection status
    private void UpdateProgressText()
    {
        progressText.text = "Collecting: " + collectiblesCollected + " / " + totalCollectibles;
    }

    // Coroutine to show progress text for a few seconds
    private IEnumerator ShowProgressForDuration(float duration)
    {
        progressText.gameObject.SetActive(true); // Show the progress text
        yield return new WaitForSeconds(duration); // Wait for the specified duration
        progressText.gameObject.SetActive(false); // Hide the progress text
    }
}
