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

        // Zulu words
        wordsList.Add(new WordDefinition { word = "Sawubona", definition = "Zulu word for 'Hello'." });
        wordsList.Add(new WordDefinition { word = "Ngiyabonga", definition = "Zulu word for 'Thank you'." });
        wordsList.Add(new WordDefinition { word = "Ukhona", definition = "Are you there?" });
        wordsList.Add(new WordDefinition { word = "Yebo", definition = "Yes." });
        wordsList.Add(new WordDefinition { word = "Hamba kahle", definition = "Go well (Goodbye)." });
        wordsList.Add(new WordDefinition { word = "Sala kahle", definition = "Stay well (Goodbye)." });
        wordsList.Add(new WordDefinition { word = "Umndeni", definition = "Family." });
        wordsList.Add(new WordDefinition { word = "Umuntu", definition = "Person." });
        wordsList.Add(new WordDefinition { word = "Inkosi", definition = "King." });
        wordsList.Add(new WordDefinition { word = "Umfana", definition = "Boy." });
        wordsList.Add(new WordDefinition { word = "Intombazane", definition = "Girl." });
        wordsList.Add(new WordDefinition { word = "Isitolo", definition = "Shop." });
        wordsList.Add(new WordDefinition { word = "Isikole", definition = "School." });
        wordsList.Add(new WordDefinition { word = "Uhambo", definition = "Journey." });
        wordsList.Add(new WordDefinition { word = "Ubaba", definition = "Father." });
        wordsList.Add(new WordDefinition { word = "Umama", definition = "Mother." });
        wordsList.Add(new WordDefinition { word = "Izandla", definition = "Hands." });
        wordsList.Add(new WordDefinition { word = "Ithembiso", definition = "Promise." });
        wordsList.Add(new WordDefinition { word = "Inhliziyo", definition = "Heart." });
        wordsList.Add(new WordDefinition { word = "Amanzi", definition = "Water." });

        // Xhosa words
        wordsList.Add(new WordDefinition { word = "Molo", definition = "Xhosa word for 'Hello'." });
        wordsList.Add(new WordDefinition { word = "Enkosi", definition = "Xhosa word for 'Thank you'." });
        wordsList.Add(new WordDefinition { word = "Hayi", definition = "No." });
        wordsList.Add(new WordDefinition { word = "Ewe", definition = "Yes." });
        wordsList.Add(new WordDefinition { word = "Ndicela", definition = "Please." });
        wordsList.Add(new WordDefinition { word = "Umhlobo", definition = "Friend." });
        wordsList.Add(new WordDefinition { word = "Intsapho", definition = "Family." });
        wordsList.Add(new WordDefinition { word = "Imfundo", definition = "Education." });
        wordsList.Add(new WordDefinition { word = "Uthando", definition = "Love." });
        wordsList.Add(new WordDefinition { word = "Ukutya", definition = "Food." });
        wordsList.Add(new WordDefinition { word = "Inyama", definition = "Meat." });

        // Sotho and Tswana words
        wordsList.Add(new WordDefinition { word = "Dumela", definition = "A Tswana word meaning 'Hello'." });
        wordsList.Add(new WordDefinition { word = "Lerato", definition = "Love (Sotho & Tswana)." });
        wordsList.Add(new WordDefinition { word = "Motho", definition = "Person (Sotho & Tswana)." });
        wordsList.Add(new WordDefinition { word = "Mma", definition = "Mother (Sotho & Tswana)." });
        wordsList.Add(new WordDefinition { word = "Rra", definition = "Father (Sotho & Tswana)." });
        wordsList.Add(new WordDefinition { word = "Lefu", definition = "Death (Sotho)." });
        wordsList.Add(new WordDefinition { word = "Pula", definition = "Rain (Tswana)." });

        // Afrikaans words
        wordsList.Add(new WordDefinition { word = "Biltong", definition = "Dried, cured meat." });
        wordsList.Add(new WordDefinition { word = "Boerewors", definition = "A type of South African sausage." });
        wordsList.Add(new WordDefinition { word = "Ouma", definition = "Grandmother." });
        wordsList.Add(new WordDefinition { word = "Oupa", definition = "Grandfather." });
        wordsList.Add(new WordDefinition { word = "Melktert", definition = "Milk tart, a popular dessert." });
        wordsList.Add(new WordDefinition { word = "Padkos", definition = "Food for the road, travel snacks." });
        wordsList.Add(new WordDefinition { word = "Vrou", definition = "Woman." });
        wordsList.Add(new WordDefinition { word = "Kop", definition = "Head." });

        // More Zulu, Xhosa, and Sotho words
        wordsList.Add(new WordDefinition { word = "Ngiyaphila", definition = "I am fine (Zulu)." });
        wordsList.Add(new WordDefinition { word = "Ngithanda", definition = "I love (Zulu)." });
        wordsList.Add(new WordDefinition { word = "Nkosazana", definition = "Miss, or young lady (Zulu)." });
        wordsList.Add(new WordDefinition { word = "Nkwenkwe", definition = "Boy (Xhosa)." });
        wordsList.Add(new WordDefinition { word = "Madoda", definition = "Men (Zulu)." });
        wordsList.Add(new WordDefinition { word = "Makoti", definition = "Bride (Zulu)." });
        wordsList.Add(new WordDefinition { word = "Fihla", definition = "Hide (Zulu)." });
        wordsList.Add(new WordDefinition { word = "Bafana", definition = "Boys (Zulu)." });
        wordsList.Add(new WordDefinition { word = "Nkosi", definition = "God (Zulu)." });
        wordsList.Add(new WordDefinition { word = "Leihlo", definition = "Eye (Sotho)." });
        wordsList.Add(new WordDefinition { word = "Letsatsi", definition = "Sun (Sotho)." });
        wordsList.Add(new WordDefinition { word = "Bana", definition = "Children (Sotho)." });
        wordsList.Add(new WordDefinition { word = "Ntlo", definition = "House (Sotho)." });
        wordsList.Add(new WordDefinition { word = "Leoto", definition = "Foot (Sotho)." });


        //Tswana
        wordsList.Add(new WordDefinition { word = "Bogosi", definition = "Kingship (Tswana)." });
        wordsList.Add(new WordDefinition { word = "Morwa", definition = "Son (Tswana)." });
        wordsList.Add(new WordDefinition { word = "Motho", definition = "Human (Tswana)." });// Tswana (continued)
        wordsList.Add(new WordDefinition { word = "Motswana", definition = "A person from Botswana (Tswana)." });
        wordsList.Add(new WordDefinition { word = "Lefoko", definition = "Word (Tswana)." });
        wordsList.Add(new WordDefinition { word = "Lefatshe", definition = "Country or land (Tswana)." });
        wordsList.Add(new WordDefinition { word = "Pula", definition = "Rain, but also a symbol of blessing (Tswana)." });
        wordsList.Add(new WordDefinition { word = "Dikgosi", definition = "Chiefs or kings (Tswana)." });

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
    }

    public void Removepanel()
    {
        wordUIPanel.SetActive(false);
        isWordDisplayed = false;
    }
}
