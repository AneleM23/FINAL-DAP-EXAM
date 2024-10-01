using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add this to use TextMeshPro

public class CardUI : MonoBehaviour
{
    public Image cardImage;
    public TMP_Text cardName; // Changed to TMP_Text
    public TMP_Text cardPower; // Changed to TMP_Text
    public TMP_Text cardHeal; // Changed to TMP_Text
    private CardData cardData;

    public void SetCard(CardData card)
    {
        cardData = card;
        cardImage.sprite = card.cardImage;
        cardName.text = card.cardName;
        cardPower.text = "Power: " + card.power.ToString();
        cardHeal.text = "Heal: " + card.heal.ToString();

        // Add button listener
        GetComponent<Button>().onClick.AddListener(OnCardClicked);
    }

    void OnCardClicked()
    {
        // Perform the card action (attack, block, etc.)
        BattleManager.Instance.PlayCard(cardData);

        // Inform DeckManager that the card was used
        FindObjectOfType<DeckManager>().OnCardUsed(cardData);

        // Destroy the card UI
        Destroy(gameObject);
    }
}
