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
    public TextMeshProUGUI wordsText; // Assign your Text component here


    [SerializeField] private bool isWordDisplayed = false;

    void Start()
    {
        // Populate the wordsList with word-definition pairs
        wordsList.Add(new WordDefinition { word = "Ubuntu", definition = "A quality that includes the essential human virtues; compassion and humanity; Togetherness." });
        wordsList.Add(new WordDefinition { word = "Lekker", definition = "Afrikaans word meaning nice, good, or pleasant." });
        wordsList.Add(new WordDefinition { word = "Braai", definition = "South African barbecue, an important social event." });
        wordsList.Add(new WordDefinition { word = "Mzansi", definition = "A colloquial name for South Africa." });
        wordsList.Add(new WordDefinition { word = "Sho", definition = "Usually used as a greeting, it can also be used as an agreement, similar to 'sure.'" });

        // Zulu words
        wordsList.Add(new WordDefinition { word = "Sawubona", definition = "Zulu word for 'Hello'." });
        wordsList.Add(new WordDefinition { word = "Ngiyabonga", definition = "Zulu word for 'Thank you'." });
        wordsList.Add(new WordDefinition { word = "Ukhona", definition = "Zulu or Xhosa word for the phrase 'Are you there?'" });
        wordsList.Add(new WordDefinition { word = "Yebo", definition = "Zulu word for Yes." });
        wordsList.Add(new WordDefinition { word = "Hamba kahle", definition = "How to say 'Go well (Goodbye)' in Zulu." });
        wordsList.Add(new WordDefinition { word = "Sala kahle", definition = "How to say 'Stay well (Goodbye)' in Zulu." });
        wordsList.Add(new WordDefinition { word = "Umndeni", definition = "Zulu word for Family." });
        wordsList.Add(new WordDefinition { word = "Umuntu", definition = "Zulu word which means Person." });
        wordsList.Add(new WordDefinition { word = "Inkosi", definition = "Zulu word for King." });
        wordsList.Add(new WordDefinition { word = "Umfana", definition = "Zulu word for Boy." });
        wordsList.Add(new WordDefinition { word = "Intombazane", definition = "ZUlu word for Girl." });
        wordsList.Add(new WordDefinition { word = "Isitolo", definition = "Zulu word for a Shop." });
        wordsList.Add(new WordDefinition { word = "Isikole", definition = "Zulu word  which means School." });
        wordsList.Add(new WordDefinition { word = "Uhambo", definition = "Zulu word for a Journey." });
        wordsList.Add(new WordDefinition { word = "Ubaba", definition = "Zulu word for Father." });
        wordsList.Add(new WordDefinition { word = "Umama", definition = "Zulu or Xhosa word for Mother." });
        wordsList.Add(new WordDefinition { word = "Izandla", definition = "Zulu word (plural) which means Hands ." });
        wordsList.Add(new WordDefinition { word = "Isithembiso", definition = "Zulu or Xhosa word which means a Promise." });
        wordsList.Add(new WordDefinition { word = "Inhliziyo", definition = "Zulu or Xhosa word for a Heart." });
        wordsList.Add(new WordDefinition { word = "Amanzi", definition = "Zulu or Xhosa word for Water." });

        // Xhosa words
        wordsList.Add(new WordDefinition { word = "Molo", definition = "Xhosa word for 'Hello'." });
        wordsList.Add(new WordDefinition { word = "Enkosi", definition = "Xhosa word for 'Thank you'." });
        wordsList.Add(new WordDefinition { word = "Hhayi", definition = "Xhosa or Zulu wor for No." });
        wordsList.Add(new WordDefinition { word = "Ewe", definition = "Xhosa word for Yes." });
        wordsList.Add(new WordDefinition { word = "Ndicela", definition = "How to say Please in Xhosa." });
        wordsList.Add(new WordDefinition { word = "Umhlobo", definition = "Xhosa word for a Friend." });
        wordsList.Add(new WordDefinition { word = "Intsapho", definition = "Xhosa word for Family." });
        wordsList.Add(new WordDefinition { word = "Imfundo", definition = "Xhosa word for Education." });
        wordsList.Add(new WordDefinition { word = "Uthando", definition = "Xhosa or Zulu word for Love." });
        wordsList.Add(new WordDefinition { word = "Ukutya", definition = "Xhosa word for Food." });
        wordsList.Add(new WordDefinition { word = "Inyama", definition = "Xhosa or Zulu word for Meat." });

        // Sotho and Tswana words
        wordsList.Add(new WordDefinition { word = "Dumela", definition = "Tswana word which is used to greet." });
        wordsList.Add(new WordDefinition { word = "Lerato", definition = "Sotho or Tswana word for Love." });
        wordsList.Add(new WordDefinition { word = "Motho", definition = "Sotho or tTswana word for Person." });
        wordsList.Add(new WordDefinition { word = "Mma", definition = "Sotho and Tswana word for Mother." });
        wordsList.Add(new WordDefinition { word = "Rra", definition = "Tswana word, which is a respectful form of Mr." });
        wordsList.Add(new WordDefinition { word = "Lefu", definition = "Sotho word for Death." });
        wordsList.Add(new WordDefinition { word = "Pula", definition = "Tswana or Sotho word for Rain." });

        // Afrikaans words
        wordsList.Add(new WordDefinition { word = "Biltong", definition = "Word which referes to dried, cured meat." });
        wordsList.Add(new WordDefinition { word = "Boerewors", definition = "A type of South African sausage." });
        wordsList.Add(new WordDefinition { word = "Ouma", definition = "Afrikaans word for Grandmother." });
        wordsList.Add(new WordDefinition { word = "Oupa", definition = "Afrikaans word for Grandfather." });
        wordsList.Add(new WordDefinition { word = "Melktert", definition = "Afrikaans translation for Milk tart, a popular dessert." });
        wordsList.Add(new WordDefinition { word = "Padkos", definition = "Afrikaans word for the phrase 'Food for the road' (travel snacks)." });
        wordsList.Add(new WordDefinition { word = "Vrou", definition = "Afrikaans word for Woman." });
        wordsList.Add(new WordDefinition { word = "Kop", definition = "Afrikaans word for Head." });

        // More Zulu, Xhosa, and Sotho words
        wordsList.Add(new WordDefinition { word = "Ngiyaphila", definition = "Zulu word for the phrase 'I am fine.'" });
        wordsList.Add(new WordDefinition { word = "Ngithanda", definition = "Zulu word for the phrase 'I love...'" });
        wordsList.Add(new WordDefinition { word = "Nkosazana", definition = "Zulu word for Miss, or young lady." });
        wordsList.Add(new WordDefinition { word = "Nkwenkwe", definition = "Xhosa word for Boy." });
        wordsList.Add(new WordDefinition { word = "Madoda", definition = "Zulu word (plural) for Men." });
        wordsList.Add(new WordDefinition { word = "Makoti", definition = "Zulu word for Bride." });
        wordsList.Add(new WordDefinition { word = "Fihla", definition = "Zulu word which means to Hide." });
        wordsList.Add(new WordDefinition { word = "Bafana", definition = "Zulu word for Boys." });
        wordsList.Add(new WordDefinition { word = "Nkosi", definition = "Zulu word for God." });
        wordsList.Add(new WordDefinition { word = "Leihlo", definition = "Sotho word for Eye." });
        wordsList.Add(new WordDefinition { word = "Letsatsi", definition = "Sotho word for the Sun." });
        wordsList.Add(new WordDefinition { word = "Bana", definition = "Sotho word (plural) for Children." });
        wordsList.Add(new WordDefinition { word = "Ntlo", definition = "Sotho word for House." });
        wordsList.Add(new WordDefinition { word = "Leoto", definition = "Sotho word for Foot." });


        //Tswana
        wordsList.Add(new WordDefinition { word = "Bogosi", definition = "Tswana word for Kingship." });
        wordsList.Add(new WordDefinition { word = "Morwa", definition = "Tswana word for Son." });
        wordsList.Add(new WordDefinition { word = "Motswana", definition = "A word which refers to a culturally Tswana person" });
        wordsList.Add(new WordDefinition { word = "Lefoko", definition = "A Tswana word which means 'the Word,' usually referring to God's word." });
        wordsList.Add(new WordDefinition { word = "Lefatshe", definition = "Tswana word for Country or land." });
        wordsList.Add(new WordDefinition { word = "Dikgosi", definition = "Tswana word (plural) for Chiefs or kings." });

        // Sesotho
        wordsList.Add(new WordDefinition { word = "Metsi", definition = "Water (Sesotho)." });
        wordsList.Add(new WordDefinition { word = "Lijo", definition = "Food (Sesotho)." });
        wordsList.Add(new WordDefinition { word = "Ntate", definition = "Father (Sesotho)." });
        wordsList.Add(new WordDefinition { word = "Mme", definition = "Mother (Sesotho)." });
        wordsList.Add(new WordDefinition { word = "Thabo", definition = "Happiness (Sesotho)." });
        wordsList.Add(new WordDefinition { word = "Moetsi", definition = "Creator or maker (Sesotho)." });
        wordsList.Add(new WordDefinition { word = "Morena", definition = "Chief or king (Sesotho)." });
        wordsList.Add(new WordDefinition { word = "Motse", definition = "Village (Sesotho)." });

        // Afrikaans (continued)
        wordsList.Add(new WordDefinition { word = "Klein", definition = "Small (Afrikaans)." });
        wordsList.Add(new WordDefinition { word = "Vleis", definition = "Meat (Afrikaans)." });
        wordsList.Add(new WordDefinition { word = "Tafel", definition = "Table (Afrikaans)." });
        wordsList.Add(new WordDefinition { word = "Stoel", definition = "Chair (Afrikaans)." });
        wordsList.Add(new WordDefinition { word = "Blou", definition = "Blue (Afrikaans)." });
        wordsList.Add(new WordDefinition { word = "Groen", definition = "Green (Afrikaans)." });
        wordsList.Add(new WordDefinition { word = "Huis", definition = "House (Afrikaans)." });
        wordsList.Add(new WordDefinition { word = "Dorp", definition = "Town (Afrikaans)." });

        // IsiNdebele
        wordsList.Add(new WordDefinition { word = "Khumbula", definition = "Remember (Ndebele)." });
        wordsList.Add(new WordDefinition { word = "Ngiyabonga", definition = "Thank you (Ndebele)." });
        wordsList.Add(new WordDefinition { word = "Hamba", definition = "Go or walk (Ndebele)." });
        wordsList.Add(new WordDefinition { word = "Sikhuluma", definition = "We speak (Ndebele)." });
        wordsList.Add(new WordDefinition { word = "Abantu", definition = "People (Ndebele)." });
        wordsList.Add(new WordDefinition { word = "Inhloko", definition = "Head (Ndebele)." });
        wordsList.Add(new WordDefinition { word = "Izandla", definition = "Hands (Ndebele)." });

        // Tsonga
        wordsList.Add(new WordDefinition { word = "Avuxeni", definition = "Good morning (Tsonga)." });
        wordsList.Add(new WordDefinition { word = "Ndzheko", definition = "Problem or issue (Tsonga)." });
        wordsList.Add(new WordDefinition { word = "Khensa", definition = "Thank you (Tsonga)." });
        wordsList.Add(new WordDefinition { word = "Loko", definition = "When (Tsonga)." });
        wordsList.Add(new WordDefinition { word = "Vutomi", definition = "Life (Tsonga)." });
        wordsList.Add(new WordDefinition { word = "Rirhandzu", definition = "Love (Tsonga)." });
        wordsList.Add(new WordDefinition { word = "Moya", definition = "Spirit or wind (Tsonga)." });

        // Venda
        wordsList.Add(new WordDefinition { word = "Ndi a livhuwa", definition = "Thank you (Venda)." });
        wordsList.Add(new WordDefinition { word = "Ndaa", definition = "Hello or respect (Venda)." });
        wordsList.Add(new WordDefinition { word = "Mutupo", definition = "Clan name or totem (Venda)." });
        wordsList.Add(new WordDefinition { word = "Mpho", definition = "Gift (Venda)." });
        wordsList.Add(new WordDefinition { word = "U thoma", definition = "Start (Venda)." });
        wordsList.Add(new WordDefinition { word = "Lufu", definition = "Death (Venda)." });
        wordsList.Add(new WordDefinition { word = "Thavha", definition = "Mountain (Venda)." });
        wordsList.Add(new WordDefinition { word = "Nyimele", definition = "Tree (Venda)." });

        // More informal or colloquial
        wordsList.Add(new WordDefinition { word = "Kasi", definition = "Township or urban area (informal)." });
        wordsList.Add(new WordDefinition { word = "Tjovitjo", definition = "An informal greeting used in townships." });
        wordsList.Add(new WordDefinition { word = "Yaz", definition = "You know (informal)." });
        wordsList.Add(new WordDefinition { word = "Skaba", definition = "Don't (informal, often used in youth slang)." });
        wordsList.Add(new WordDefinition { word = "Sgud' snax", definition = "Street food (informal)." });
        wordsList.Add(new WordDefinition { word = "Chommie", definition = "Friend (colloquial, Afrikaans)." });
        wordsList.Add(new WordDefinition { word = "Ekasi", definition = "In the township (informal)." });
        wordsList.Add(new WordDefinition { word = "Phanda", definition = "To hustle (colloquial)." });
        wordsList.Add(new WordDefinition { word = "Mzala", definition = "Cousin or close friend (colloquial)." });

        // Remaining informal and colloquial
        wordsList.Add(new WordDefinition { word = "Ayoba", definition = "Cool, awesome (informal)." });
        wordsList.Add(new WordDefinition { word = "Jo", definition = "Hey! (informal)." });
        wordsList.Add(new WordDefinition { word = "Eita", definition = "An informal greeting, similar to 'hi'." });
        wordsList.Add(new WordDefinition { word = "Sharp", definition = "Alright, okay (informal)." });
        wordsList.Add(new WordDefinition { word = "Laduma", definition = "It thunders! Often used during soccer celebrations." });
        wordsList.Add(new WordDefinition { word = "Tsotsi", definition = "Thug or gangster (informal)." });


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

        AddWordToScrollList(word, definition);
    }

    public void Removepanel()
    {
        wordUIPanel.SetActive(false);
        isWordDisplayed = false;
    }

    private void AddWordToScrollList(string word, string definition)
    {
        wordsText.text += word + ": " + definition + "\n";
    }
}
