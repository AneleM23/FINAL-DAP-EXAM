using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPaper : MonoBehaviour
{
    public string word;        // Word displayed on the paper
    public string definition;  // Definition displayed with the word

    private bool isCollected = false;
    private WordManager wordManager;

    void Start()
    {
        wordManager = FindObjectOfType<WordManager>();

        // Assign a random word and definition from the WordManager
        KeyValuePair<string, string> wordData = wordManager.AssignWordToPrefab();
        word = wordData.Key;
        definition = wordData.Value;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get a random word and definition from the WordManager
            var randomWord = wordManager.AssignWordToPrefab();

            // Check if the word is empty and log for debugging
            if (string.IsNullOrEmpty(randomWord.Key) || string.IsNullOrEmpty(randomWord.Value))
            {
                Debug.LogWarning("The word or definition is empty.");
            }
            else
            {
                // Display the word and definition using the WordManager
                wordManager.DisplayWord(randomWord.Key, randomWord.Value);
            }

            // Destroy the paper after collection
            Destroy(gameObject);
        }
    }
}
