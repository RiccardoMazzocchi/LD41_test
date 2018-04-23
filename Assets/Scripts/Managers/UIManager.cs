using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject gameCanvas;
    public GameObject pauseCanvas;
    public GameObject goButton;

    public Text deckCountText;

    bool paused;

    public Sprite goRed;
    public Sprite goGreen;

	// Use this for initialization
	void Start () {
        pauseCanvas.SetActive(false);

        paused = false;

        gameCanvas.SetActive(true);
        GameManager.Instance.tm.CurrentMacroPhase = TurnManager.MacroPhase.Game;
        GameManager.Instance.cm.InitializeDeck();
        GameManager.Instance.cm.FillCards();
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

    public void EndDeck()
    {

    }

    public void DisableGoButton()
    {
        goButton.GetComponent<Button>().enabled = false;
        goButton.GetComponent<Image>().sprite = goRed;
    }

    public void EnableGoButton()
    {
        goButton.GetComponent<Button>().enabled = true;
        goButton.GetComponent<Image>().sprite = goGreen;
    }
}
