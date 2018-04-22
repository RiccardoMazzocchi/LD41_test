using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card", menuName = "Cards")]
public class CardData : ScriptableObject {

    public enum CardType { Action, Movement }
    public CardType cardType;
    public Sprite cardImage;


    public delegate void CardFunctionDelegate();

    CardFunctionDelegate cardMethod;

    public void CardFunction()
    {
        if (this.name == "JumpCard")
        {
            Debug.Log("Jump Card used");
        }
        else if (this.name == "RunCard")
        {
            Debug.Log("Run Card used");
        }
    }

    
}
