using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public TurnManager tm;
    public CardsManager cm;
    public UIManager uim;
    public LevelManager lm;
    public SlotsManager sm;
    public PlayerScript player;
	// Use this for initialization
	void Start () {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        tm = GetComponent<TurnManager>();
        cm = GetComponent<CardsManager>();
        uim = GetComponent<UIManager>();
        lm = GetComponent<LevelManager>();
        sm = GetComponent<SlotsManager>();
        player = FindObjectOfType<PlayerScript>();
	}
	

}
