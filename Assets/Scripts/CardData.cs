using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card", menuName = "Cards")]
public class CardData : ScriptableObject {

    public enum CardType { Action, Movement }
    public CardType cardType;
    public Sprite cardImage;
}
