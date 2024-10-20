using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class CardData : ScriptableObject
{
    public string cardName;
    public enum CardType { Attack, Block, DoubleAttack, Heal, Stun}
    public CardType cardType;
    public int power; // Attack power or block value
    public int heal;
    public Sprite cardImage;
}

