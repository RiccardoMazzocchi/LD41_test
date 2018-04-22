using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject gameCanvas;
    public GameObject deckCanvas;
    public GameObject menuCanvas;

    public Text deckCountText;

	// Use this for initialization
	void Start () {
        menuCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        deckCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartButton()
    {
        menuCanvas.SetActive(false);
        deckCanvas.SetActive(true);
        GameManager.Instance.tm.CurrentMacroPhase = TurnManager.MacroPhase.Deck;
    }

    public void EndDeck()
    {
        deckCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        GameManager.Instance.tm.CurrentMacroPhase = TurnManager.MacroPhase.Game;
        GameManager.Instance.cm.FillCards();
    }
}
