using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Image cardImage;
    public Text cardName;
    public Text cardPower;
    private CardData cardData;

    public void SetCard(CardData card)
    {
        cardData = card;
        cardImage.sprite = card.cardImage;
        cardName.text = card.cardName;
        cardPower.text = card.power.ToString();

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
