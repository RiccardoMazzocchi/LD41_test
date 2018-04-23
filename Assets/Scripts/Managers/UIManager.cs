using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject gameCanvas;
    public GameObject deckCanvas;
    public GameObject menuCanvas;
    public GameObject pauseCanvas;
    public GameObject goButton;

    public Text deckCountText;

    bool paused;



	// Use this for initialization
	void Start () {
        menuCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        deckCanvas.SetActive(false);
        pauseCanvas.SetActive(false);

        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            pauseCanvas.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            pauseCanvas.SetActive(false);
            paused = false;
            Time.timeScale = 1f;
        }
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

    public void DisableGoButton()
    {
        goButton.GetComponent<Button>().enabled = false;
    }

    public void EnableGoButton()
    {
        goButton.GetComponent<Button>().enabled = true;
    }
}
