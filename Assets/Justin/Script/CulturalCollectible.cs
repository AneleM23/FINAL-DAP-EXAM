using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CulturalCollectible : MonoBehaviour
{
    public string collectibleInfo;  // Text to display about the collectible
    public GameObject infoPanel;    // Panel to display the collectible information
    public Text infoText;           // Text component for the info panel
    public string letter;           // The letter or item that will be collected
    public WordTracker wordTracker; // Reference to the WordTracker component

    private void Start()
    {
        infoPanel.SetActive(false); // Hide the panel initially
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player collides with the collectible
        {
            ShowCollectibleInfo();    // Show the collectible info
            wordTracker.AddLetter(letter); // Update the word tracker with the collected letter
            HideCollectible();        // Hide the collectible (PNG image)
        }
    }

    // Show the collectible information (about the culture item)
    private void ShowCollectibleInfo()
    {
        infoText.text = collectibleInfo; // Display the collectible information
        infoPanel.SetActive(true);       // Show the info panel

        // Ensure the coroutine starts correctly to hide the panel after 3 seconds
        StartCoroutine(HideInfoPanelAfterDelay(3f));
    }

    // Hide the info panel after a specified delay
    private IEnumerator HideInfoPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified time
        infoPanel.SetActive(false); // Hide the info panel
    }

    // Hide the collectible (PNG image) when it is collected
    private void HideCollectible()
    {
        gameObject.SetActive(false); // Disable the collectible object (PNG image)

        // Optional: Reactivate the collectible after some time (e.g., 10 seconds)
        StartCoroutine(ReappearCollectibleAfterDelay(10f));
    }

    // Reactivate the collectible (PNG image) after a delay
    private IEnumerator ReappearCollectibleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified time
        gameObject.SetActive(true); // Reactivate the collectible (PNG image)
    }
}
