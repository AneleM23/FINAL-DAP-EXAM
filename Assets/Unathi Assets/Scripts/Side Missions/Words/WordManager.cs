using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class WordDefinition
{
    public string word;
    public string definition;
}

public class WordManager : MonoBehaviour
{
    [SerializeField] private List<WordDefinition> wordsList = new List<WordDefinition>(); // List to hold word and definition pairs

    private Dictionary<string, string> wordsDictionary = new Dictionary<string, string>(); // Dictionary to be populated at runtime
    public GameObject wordUIPanel; // UI Panel to display the word and definition
    public TextMeshProUGUI wordUIText; // TMP Text field

    [SerializeField] private bool isWordDisplayed = false;

    void Start()
    {
        // Populate the wordsList with word-definition pairs
        wordsList.Add(new WordDefinition { word = "Ubuntu", definition = "A quality that includes the essential human virtues; compassion and humanity; Togetherness." });
        wordsList.Add(new WordDefinition { word = "Lekker", definition = "Afrikaans word meaning nice, good, or pleasant." });
        wordsList.Add(new WordDefinition { word = "Braai", definition = "South African barbecue, an important social event." });
        wordsList.Add(new WordDefinition { word = "Mzansi", definition = "A colloquial name for South Africa." });
        wordsList.Add(new WordDefinition { word = "Sho", definition = "Usually used as a greeting, it can also be used as an agreement, similar to 'sure.'" });

        // Populate the dictionary from the list
        foreach (var wordDef in wordsList)
        {
            if (!wordsDictionary.ContainsKey(wordDef.word))
            {
                wordsDictionary.Add(wordDef.word, wordDef.definition);
            }
        }

        // Log the contents of the dictionary for debugging
        foreach (var kvp in wordsDictionary)
        {
            Debug.Log($"Word: {kvp.Key}, Definition: {kvp.Value}");
        }

        if (wordsDictionary.Count == 0)
        {
            Debug.LogWarning("No words in the dictionary.");
        }
    }

    // Method to assign a word and definition to the prefab
    public KeyValuePair<string, string> AssignWordToPrefab()
    {
        if (wordsDictionary.Count == 0)
        {
            Debug.LogWarning("No more words available in the dictionary.");
            return new KeyValuePair<string, string>("", "");
        }

        // Get a random word and definition from the dictionary
        List<KeyValuePair<string, string>> wordList = new List<KeyValuePair<string, string>>(wordsDictionary);
        KeyValuePair<string, string> randomWord = wordList[Random.Range(0, wordList.Count)];

        // Remove the selected word from the dictionary
        wordsDictionary.Remove(randomWord.Key);

        return randomWord;
    }

    // Method to display the word and definition
    public void DisplayWord(string word, string definition)
    {
        wordUIText.text = "Word: " + word + "\nDefinition: " + definition;
        wordUIPanel.SetActive(true);
        isWordDisplayed = true;
    }

    public void Removepanel()
    {
        wordUIPanel.SetActive(false);
        isWordDisplayed = false;
    }
}
