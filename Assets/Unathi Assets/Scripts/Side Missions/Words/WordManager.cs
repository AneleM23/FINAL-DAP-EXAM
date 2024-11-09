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
        wordsList.Add(new WordDefinition { word = "Metsi", definition = "Sotho word for Water." });
        wordsList.Add(new WordDefinition { word = "Lijo", definition = "Sotho word for Food." });
        wordsList.Add(new WordDefinition { word = "Ntate", definition = "Sotho word for Father." });
        wordsList.Add(new WordDefinition { word = "Mme", definition = "Sotho word for Mother." });
        wordsList.Add(new WordDefinition { word = "Thabo", definition = "Sotho word for Happiness." });
        wordsList.Add(new WordDefinition { word = "Moetsi", definition = "Sotho word for Creator or maker." });
        wordsList.Add(new WordDefinition { word = "Morena", definition = "Sotho word for Chief or king." });
        wordsList.Add(new WordDefinition { word = "Motse", definition = "Sotho word for Village." });

        // Afrikaans (continued)
        wordsList.Add(new WordDefinition { word = "Klein", definition = "Afrikaans word for Small." });
        wordsList.Add(new WordDefinition { word = "Vleis", definition = "Afrikaans word for Meat." });
        wordsList.Add(new WordDefinition { word = "Tafel", definition = "Afrikaans word for Table." });
        wordsList.Add(new WordDefinition { word = "Stoel", definition = "Afrikaans word for Chair." });
        wordsList.Add(new WordDefinition { word = "Blou", definition = "Afrikaans word for the colour Blue." });
        wordsList.Add(new WordDefinition { word = "Groen", definition = "Afrikaans word for the colour Green." });
        wordsList.Add(new WordDefinition { word = "Huis", definition = "Afrikaans word for House." });
        wordsList.Add(new WordDefinition { word = "Dorp", definition = "Afrikaans word for Town." });

        // IsiNdebele
        wordsList.Add(new WordDefinition { word = "Siyalemukela", definition = "Ndebele word for the phrase 'We welcome you.'" });
        wordsList.Add(new WordDefinition { word = "Salibonani", definition = "Ndebele general greeting; 'Hello.'" });
        wordsList.Add(new WordDefinition { word = "Ibizo lakho ngubani?", definition = "Ndebele for the question 'What's your name?'" });
        wordsList.Add(new WordDefinition { word = "Uvela ngaphi?", definition = "Ndebele way to ask 'Where are you from?'" });
        wordsList.Add(new WordDefinition { word = "Livukile", definition = "Ndebele word for the greeting 'Good morning.'" });
        wordsList.Add(new WordDefinition { word = "Litshonile", definition = "Ndebele word for 'Good afternoon/evening.'" });
        wordsList.Add(new WordDefinition { word = "Akungitshiye!", definition = "Ndebele word for the phrase 'Leave me alone!'" });

        // Tsonga
        wordsList.Add(new WordDefinition { word = "Avuxeni", definition = "Tsonga word for the phrase 'Good morning.'" });
        wordsList.Add(new WordDefinition { word = "Ndzheko", definition = "tsonga word for Problem or issue." });
        wordsList.Add(new WordDefinition { word = "Khensa", definition = "Tsonga way to say 'Thank you.'" });
        wordsList.Add(new WordDefinition { word = "Vutomi", definition = "Tsonga word for Life." });
        wordsList.Add(new WordDefinition { word = "Rirhandzu", definition = "Tsonga word for Love." });

        // Venda
        wordsList.Add(new WordDefinition { word = "Ndi a livhuwa", definition = "Venda phrase for the phrase 'Thank you.'" });
        wordsList.Add(new WordDefinition { word = "Ndaa", definition = "Venda word used as a greeting; Hello." });
        wordsList.Add(new WordDefinition { word = "Lufu", definition = "Venda word for Death." });
        wordsList.Add(new WordDefinition { word = "Thavha", definition = "Venda word for Mountain." });
        wordsList.Add(new WordDefinition { word = "Muri", definition = "Venda word for Tree." });

        // More informal or colloquial
        wordsList.Add(new WordDefinition { word = "Kasi", definition = "A Township or urban area." });
        wordsList.Add(new WordDefinition { word = "Tjovitjo", definition = "An informal greeting or expression used in townships." });
        wordsList.Add(new WordDefinition { word = "Kota", definition = "A South African sandwhich made with a quarter of baked, uncut bread." });
        wordsList.Add(new WordDefinition { word = "Chommie", definition = "A colloquial word for friend." });
        wordsList.Add(new WordDefinition { word = "Phanda", definition = "A colloquial term which means to hustle"}); 
        wordsList.Add(new WordDefinition { word = "Ayoba", definition = "Cool, awesome (informal)." });
        wordsList.Add(new WordDefinition { word = "Jo", definition = "Hey! (informal)." });
        wordsList.Add(new WordDefinition { word = "Eita", definition = "An informal greeting, similar to 'hi'." });
        wordsList.Add(new WordDefinition { word = "Sharp", definition = "Alright, okay (informal)." });
        wordsList.Add(new WordDefinition { word = "Laduma", definition = "It thunders! Often used during soccer celebrations." });
        wordsList.Add(new WordDefinition { word = "Tsotsi", definition = "Thug or gangster (informal)." });

        //86 more words

        // Zulu words
        wordsList.Add(new WordDefinition { word = "Izinkomo", definition = "Zulu word for Cows." });
        wordsList.Add(new WordDefinition { word = "Isiqhingi", definition = "Zulu word for Island." });
        wordsList.Add(new WordDefinition { word = "Indlu", definition = "Zulu word for House." });
        wordsList.Add(new WordDefinition { word = "Inkosi", definition = "Zulu word for Leader or Chief." });
        wordsList.Add(new WordDefinition { word = "Intaba", definition = "Zulu word for Mountain." });
        wordsList.Add(new WordDefinition { word = "Izinkanyezi", definition = "Zulu word for Stars." });
        wordsList.Add(new WordDefinition { word = "Izulu", definition = "Zulu word for Sky or Heaven." });
        wordsList.Add(new WordDefinition { word = "Izinkomo", definition = "Zulu word for Cattle." });
        wordsList.Add(new WordDefinition { word = "Izandla", definition = "Zulu word for Hands." });

        // Xhosa words
        wordsList.Add(new WordDefinition { word = "Inkosikazi", definition = "Xhosa word for Queen or Lady." });
        wordsList.Add(new WordDefinition { word = "Uhlanga", definition = "Xhosa word for Root or Origin." });
        wordsList.Add(new WordDefinition { word = "Isizwe", definition = "Xhosa word for Nation or Tribe." });
        wordsList.Add(new WordDefinition { word = "Inyoka", definition = "Xhosa word for Snake." });
        wordsList.Add(new WordDefinition { word = "Ilanga", definition = "Xhosa word for Sun." });
        wordsList.Add(new WordDefinition { word = "Ubomi", definition = "Xhosa word for Life." });
        wordsList.Add(new WordDefinition { word = "Amandla", definition = "Xhosa word for Power." });
        wordsList.Add(new WordDefinition { word = "Imvula", definition = "Xhosa word for Rain." });
        wordsList.Add(new WordDefinition { word = "Intloko", definition = "Xhosa word for Head." });

        // Tswana words
        wordsList.Add(new WordDefinition { word = "Moja", definition = "Tswana word for Eat." });
        wordsList.Add(new WordDefinition { word = "Ditau", definition = "Tswana word for Lions." });
        wordsList.Add(new WordDefinition { word = "Matlho", definition = "Tswana word for Eyes." });
        wordsList.Add(new WordDefinition { word = "Thato", definition = "Tswana word for Will or Desire." });
        wordsList.Add(new WordDefinition { word = "Mosebetsi", definition = "Tswana word for Job." });
        wordsList.Add(new WordDefinition { word = "Ntshe", definition = "Tswana word for Blood." });
        wordsList.Add(new WordDefinition { word = "Melemo", definition = "Tswana word for Medicine." });
        wordsList.Add(new WordDefinition { word = "Tswelopele", definition = "Tswana word for Progress." });
        wordsList.Add(new WordDefinition { word = "Lapa", definition = "Tswana word for Home." });

        // Sotho words
        wordsList.Add(new WordDefinition { word = "Khomo", definition = "Sotho word for Cow." });
        wordsList.Add(new WordDefinition { word = "Dikgosi", definition = "Sotho word for Chiefs." });
        wordsList.Add(new WordDefinition { word = "Lefatše", definition = "Sotho word for Earth." });
        wordsList.Add(new WordDefinition { word = "Boroko", definition = "Sotho word for Sleep." });
        wordsList.Add(new WordDefinition { word = "Mpho", definition = "Sotho word for Gift." });
        wordsList.Add(new WordDefinition { word = "Seaparo", definition = "Sotho word for Clothes." });
        wordsList.Add(new WordDefinition { word = "Lerole", definition = "Sotho word for Dust." });
        wordsList.Add(new WordDefinition { word = "Masole", definition = "Sotho word for Soldiers." });
        wordsList.Add(new WordDefinition { word = "Lefu", definition = "Sotho word for Death." });

        // Afrikaans words
        wordsList.Add(new WordDefinition { word = "Boet", definition = "Afrikaans word for Brother." });
        wordsList.Add(new WordDefinition { word = "Tannie", definition = "Afrikaans word for Aunt." });
        wordsList.Add(new WordDefinition { word = "Oom", definition = "Afrikaans word for Uncle." });
        wordsList.Add(new WordDefinition { word = "Kleinboet", definition = "Afrikaans term for Younger Brother." });
        wordsList.Add(new WordDefinition { word = "Gesin", definition = "Afrikaans word for Family." });
        wordsList.Add(new WordDefinition { word = "Vriend", definition = "Afrikaans word for Friend." });
        wordsList.Add(new WordDefinition { word = "Geduld", definition = "Afrikaans word for Patience." });
        wordsList.Add(new WordDefinition { word = "Geluk", definition = "Afrikaans word for Happiness." });
        wordsList.Add(new WordDefinition { word = "Krag", definition = "Afrikaans word for Strength." });

        // Tsonga words
        wordsList.Add(new WordDefinition { word = "Nhluvuko", definition = "Tsonga word for Development." });
        wordsList.Add(new WordDefinition { word = "Vutivi", definition = "Tsonga word for Knowledge." });
        wordsList.Add(new WordDefinition { word = "Swilo", definition = "Tsonga word for Things." });
        wordsList.Add(new WordDefinition { word = "Munhu", definition = "Tsonga word for Person." });
        wordsList.Add(new WordDefinition { word = "Swiendlo", definition = "Tsonga word for Actions." });
        wordsList.Add(new WordDefinition { word = "Nkateko", definition = "Tsonga word for Blessing." });
        wordsList.Add(new WordDefinition { word = "Mufana", definition = "Tsonga word for Boy." });
        wordsList.Add(new WordDefinition { word = "Nwana", definition = "Tsonga word for Child." });
        wordsList.Add(new WordDefinition { word = "Vavasati", definition = "Tsonga word for Women." });

        // Venda words
        wordsList.Add(new WordDefinition { word = "Lufu", definition = "Venda word for Death." });
        wordsList.Add(new WordDefinition { word = "Zwothe", definition = "Venda word for Everything." });
        wordsList.Add(new WordDefinition { word = "Mbilu", definition = "Venda word for Heart." });
        wordsList.Add(new WordDefinition { word = "Dzina", definition = "Venda word for Name." });
        wordsList.Add(new WordDefinition { word = "Munna", definition = "Venda word for Man." });
        wordsList.Add(new WordDefinition { word = "Makhulu", definition = "Venda word for Grandmother." });
        wordsList.Add(new WordDefinition { word = "Tshilidzi", definition = "Venda word for Mercy." });
        wordsList.Add(new WordDefinition { word = "Tshikwama", definition = "Venda word for Bag." });
        wordsList.Add(new WordDefinition { word = "Khotsi", definition = "Venda word for Father." });

        // Colloquial/Informal South African terms
        wordsList.Add(new WordDefinition { word = "Chisa nyama", definition = "Braai or barbecue, typically in a township." });
        wordsList.Add(new WordDefinition { word = "Baba", definition = "A term of respect for a man." });
        wordsList.Add(new WordDefinition { word = "Mzala", definition = "Cousin." });
        wordsList.Add(new WordDefinition { word = "Sbwl", definition = "A slang term for 'want' or 'long for' something." });
        wordsList.Add(new WordDefinition { word = "Zama", definition = "To try." });
        wordsList.Add(new WordDefinition { word = "Bodlela", definition = "Colloquial term for Bottle." });
        wordsList.Add(new WordDefinition { word = "Zol", definition = "Informal term for a cigarette or joint." });
        wordsList.Add(new WordDefinition { word = "Sekwanele", definition = "It is enough or sufficient." });
        wordsList.Add(new WordDefinition { word = "Phoyisa", definition = "Police officer." });
        wordsList.Add(new WordDefinition { word = "AmaGents", definition = "Term for Gentlemen or guys." });



        // Populate the dictionary from the list
        foreach (var wordDef in wordsList)
        {
            if (!wordsDictionary.ContainsKey(wordDef.word))
            {
                wordsDictionary.Add(wordDef.word, wordDef.definition);
            }
        }

        //// Log the contents of the dictionary for debugging
        //foreach (var kvp in wordsDictionary)
        //{
        //    Debug.Log($"Word: {kvp.Key}, Definition: {kvp.Value}");
        //}

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
