/// <summary>
/// This script is responsible of the state of the whole game. It make the link between the main screen and the different levels
/// </summary> 
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
		
	public PlayerStats Player = new PlayerStats();
	
	private LevelGenerator _LevelGenerator;
	
	private int _gameState = 0; // 0 = menu, 1 = game
		
	// Current Game State
	public int GameState
	{
		get {return _gameState; }
		set {_gameState = value;}
	}
		
	// Use this for initialization
	void Start () {
		_LevelGenerator = GetComponent<LevelGenerator>();
		
		//GameState = 1;
	}
	
	public void SelectLevel(int _lvlSelected)
	{
		
		GetComponent<LevelManager>().SetupCurLevel(_lvlSelected);
		_LevelGenerator.CreateLevel (_lvlSelected);
		GetComponent<LevelManager>().IniLvlManag(_lvlSelected);		// Initialize the PadManager(Find the Top and bottom Wall to limit the pad movement)
		GetComponent<AIControl>().IniAI();				// Initialize the AI(Find the ball)
		GetComponent<PadManager>().IniPadManag();		// Initialize the PadManager(Find the Top and bottom Wall to limit the pad movement)
		GetComponent<PlayerControl>().IniPlayCont();	// Initialize the PlayerControl(Get the player speed)
		GameState = 1;
	}
	
	// Called whenever GameState is changed
}
