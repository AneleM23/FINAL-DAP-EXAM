
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance { get; private set; } // Singleton instance

    public List<CardData> cardDeck; // List of ScriptableObject Cards
    public Transform handArea; // UI area where cards will appear
    public GameObject cardPrefab; // Prefab to represent a card in the UI
    private List<CardData> playerHand = new List<CardData>();
    private int handSize = 5;

    void Start()
    {
        DrawInitialHand();
    }

    void DrawInitialHand()
    {
        for (int i = 0; i < handSize; i++)
        {
            DrawRandomCard();
        }
    }

    void DrawRandomCard()
    {
        if (cardDeck.Count > 0)
        {
            CardData randomCard = cardDeck[Random.Range(0, cardDeck.Count)];
            playerHand.Add(randomCard);
            SpawnCardUI(randomCard);
        }
    }

    void SpawnCardUI(CardData card)
    {
        GameObject cardObj = Instantiate(cardPrefab, handArea);
        CardUI cardUI = cardObj.GetComponent<CardUI>();
        cardUI.SetCard(card);
    }

    public void OnCardUsed(CardData card)
    {
        playerHand.Remove(card);
        DrawRandomCard(); // Replace used card with a new one
    }
}
