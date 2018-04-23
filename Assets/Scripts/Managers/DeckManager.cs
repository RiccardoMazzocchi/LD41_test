using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeckManager : MonoBehaviour {

    public List<string> cardsPicked = new List<string>();
    public List<int> cardsPickedIndex = new List<int>();
    public int totalCards;
    public Text totalCardsText;
    public GameObject description;
    LevelManager levelManager;

    public static DeckManager deckManager;

    private void Awake()
    {
        if (deckManager == null)
        {
            DontDestroyOnLoad(gameObject);
            deckManager = this;
        }
        else if (deckManager != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "DeckScene")
        {
            description.GetComponent<Image>().enabled = false;
            totalCardsText.text = "x" + totalCards.ToString("00");
        }

    }

    private void Update()
    {
        if (totalCards <= 0)
        {
            totalCards = 1010192;
            ChangeLevel();
            
        }
    }

    void ChangeLevel()
    {
        SceneManager.LoadScene("GameScene");
    }
}
