
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
    public Text playerCardDisplay;
    public Text turnText;


    bool playerBlock;
    bool enemySkipTurn;
    bool playerSkipTurn;
    public bool canPlay;

    public bool missionActive;

    public Slider hpSlider;
    public Slider enemyHpSlider;

    [SerializeField] GameState game;

    [SerializeField] MissionTrigger missionTrigger;

    [SerializeField] SceneManagement scenes;

    [SerializeField] MissionManager missionManager;

    [SerializeField] WaypointManager waypoints;

    [SerializeField] EnergyManager energy;

    private UI_Manager uiManager; // Reference to the UI_Manager script

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        SetHPSlider();
        SetEnemyHPSlider();

        playerCardDisplay.text = "";
        enemyCardDisplay.text = "";

        uiManager = FindObjectOfType<UI_Manager>();
    }

    void Update()
    {
        missionTrigger = GameObject.Find("ZuluChief").GetComponent<MissionTrigger>();

         switch (game)
        {
            case GameState.PlayerTurn:
                enemyCardDisplay.gameObject.SetActive(false);
                playerCardDisplay.gameObject.SetActive(true);
                turnText.text = "Your Turn!";
                break;
            case GameState.EnemyTurn:
                enemyCardDisplay.gameObject.SetActive(true);
                playerCardDisplay.gameObject.SetActive(false);
                turnText.text = "Enemy's Turn!";
                break;
            case GameState.Win:
                if (missionActive)
                {
                      if (missionTrigger!= null)
                    {
                        missionManager.CompleteMission(missionTrigger.missionName);
                        waypoints.waypoints.Remove(missionTrigger.gameObject);
                        scenes.EndBattle();
                    }
                }
                break;
            case GameState.Lose:
                if (missionActive)
                {
                    if (missionTrigger != null)
                    {
                        playerHealth = 100;
                        enemyHealth = 100;
                        canPlay = true;
                        game = GameState.PlayerTurn;

                        if (uiManager != null)
                        {
                            // Start the MissionFailed coroutine
                            StartCoroutine(uiManager.MissionFailed());
                        }

                        energy.SpendEnergy(50);
                        scenes.EndBattle();
                    }
                }
                break;
        }

           UpdateSlider();
        UpdateEnemySlider();
    }

    public void PlayCard(CardData card)
    {
        if (canPlay)
        {
            canPlay = false;

            if (playerSkipTurn)
            {
                StartCoroutine(UpdatePlayerText("Skip Turn!"));

                // After the player plays a card, have the enemy play one
                StartCoroutine(EnemyTurn(card));

                playerSkipTurn = false;
            }

            else
            {
                switch (card.cardType)
                {
                    case CardData.CardType.Attack:
                        playerAnimator.SetTrigger("isAttacking");
                        enemyHealth -= card.power * 2;
                        break;
                    case CardData.CardType.Block:
                        // Block logic here
                        playerBlock = true;
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
                        enemySkipTurn = true;
                        break;
                }

                if (enemyHealth > 0)
                {
                    StartCoroutine(UpdatePlayerText(card.cardName));

                    // After the player plays a card, have the enemy play one
                    StartCoroutine(EnemyTurn(card));
                }   else if (enemyHealth<=0)
                {
                    game = GameState.Win;
                }
                
            }
        }
        
    }

    void PlayEnemyTurn()
    {
        game = GameState.EnemyTurn;

        if (enemySkipTurn)
        {
            enemyCardDisplay.text = "Skip Turn!";
            StartCoroutine(PlayerTurn());
            enemySkipTurn= false;
        }
        else
        {

            // Generate a random enemy card (similar to player's card generation)
            CardData enemyCard = DeckManager.Instance.cardDeck[Random.Range(0, DeckManager.Instance.cardDeck.Count)];

            // Display enemy's card name
            enemyCardDisplay.text = enemyCard.cardName;

            // Handle enemy card action (e.g., attack, block)
            switch (enemyCard.cardType)
            {
                case CardData.CardType.Attack:
                    enemyAnimator.SetTrigger("isAttacking");

                    if (playerBlock)
                    {
                        playerHealth -= enemyCard.power / 2;
                    }
                    else
                    {
                        playerHealth -= enemyCard.power;
                    }

                    playerBlock = false;

                    break;
                case CardData.CardType.Block:
                    // Enemy block logic
                    break;
                case CardData.CardType.DoubleAttack:
                    // Enemy special logic
                    StartCoroutine(EnemyDoubleAttack(enemyCard));
                    break;
                case CardData.CardType.Heal:
                    // Heal logic here
                    enemyHealth += enemyCard.heal;
                    break;
                case CardData.CardType.Stun:
                    // Block logic here
                    playerSkipTurn = true;
                    break;
            }

            if (playerHealth > 0)
                StartCoroutine(PlayerTurn());
            else
                game = GameState.Lose;
        }
    }

    IEnumerator PlayerDoubleAttack(CardData newCard)
    {
        playerAnimator.SetTrigger("isAttacking");
        enemyHealth -= newCard.power;

        yield return new WaitForSeconds(3);

        playerAnimator.SetTrigger("isAttacking");
        enemyHealth -= newCard.power;
    }

    IEnumerator EnemyDoubleAttack(CardData newCard)
    {
        enemyAnimator.SetTrigger("isAttacking");
        playerHealth -= newCard.power;

        yield return new WaitForSeconds(3);

        enemyAnimator.SetTrigger("isAttacking");
        playerHealth -= newCard.power;
    }

    IEnumerator EnemyTurn(CardData card)
    {
        yield return new WaitForSeconds(3);

        PlayEnemyTurn();

        yield return new WaitForSeconds(3);
    }

    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(3);

        game = GameState.PlayerTurn;
        canPlay = true;
    }

    IEnumerator UpdatePlayerText(string text)
    {
        playerCardDisplay.text = text;

        yield return new WaitForSeconds(3);

        playerCardDisplay.text = "";
    }

    void SetHPSlider()
    {
        hpSlider.maxValue = playerHealth;
        hpSlider.value = playerHealth;
    }

    void UpdateSlider()
    {
        hpSlider.value = playerHealth;
    }

    void SetEnemyHPSlider()
    {
        enemyHpSlider.maxValue = enemyHealth;
        enemyHpSlider.value = enemyHealth;
    }

    void UpdateEnemySlider()
    {
        enemyHpSlider.value = enemyHealth;
    }
}
