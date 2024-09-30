
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    enum GameState { PlayerTurn, EnemyTurn, Lose, Win}

    public static BattleManager Instance; // Singleton for easy access

    public int playerHealth = 100;
    public int enemyHealth = 100;
    public Animator playerAnimator;
    public Animator enemyAnimator;
    public Text enemyCardDisplay; // Displays enemy card

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayCard(CardData card)
    {
        switch (card.cardType)
        {
            case CardData.CardType.Attack:
                playerAnimator.SetTrigger("Attack");
                enemyHealth -= card.power;
                break;
            case CardData.CardType.Block:
                // Block logic here
                break;
            case CardData.CardType.DoubleAttack:
                // Special logic here
                StartCoroutine(PlayerDoubleAttack(card));
                break;
            case CardData.CardType.Heal:
                // Heal logic here
                playerHealth += card.heal;
                break;
            case CardData.CardType.Stun:
                // Block logic here
                break;
        }

        // After the player plays a card, have the enemy play one
        PlayEnemyTurn();
    }

    void PlayEnemyTurn()
    {
        // Generate a random enemy card (similar to player's card generation)
        CardData enemyCard = DeckManager.Instance.cardDeck[Random.Range(0, DeckManager.Instance.cardDeck.Count)];

        // Display enemy's card name
        enemyCardDisplay.text = enemyCard.cardName;

        // Handle enemy card action (e.g., attack, block)
        switch (enemyCard.cardType)
        {
            case CardData.CardType.Attack:
                enemyAnimator.SetTrigger("Attack");
                playerHealth -= enemyCard.power;
                break;
            case CardData.CardType.Block:
                // Enemy block logic
                break;
            case CardData.CardType.DoubleAttack:
                // Enemy special logic
                break;
        }
    }

    IEnumerator PlayerDoubleAttack(CardData newCard)
    {
        playerAnimator.SetTrigger("Attack");
        enemyHealth -= newCard.power;

        yield return new WaitForSeconds(3);

        playerAnimator.SetTrigger("Attack");
        enemyHealth -= newCard.power;
    }

    IEnumerator EnemyDoubleAttack(CardData newCard)
    {
        enemyAnimator.SetTrigger("Attack");
        playerHealth -= newCard.power;

        yield return new WaitForSeconds(3);

        enemyAnimator.SetTrigger("Attack");
        playerHealth -= newCard.power;
    }
}
