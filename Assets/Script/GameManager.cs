/// <summary>
/// This script is responsible of the state of the whole game. It make the link between the main screen and the different levels
/// </summary> 
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
		
	private LevelGenerator _LevelGenerator;
	private int _gameState = 0; // 0 = menu, 1 = game
	private enum _gameStateName {
		Menu,  // 0
		Game,  // 1
	}	
		
	// Current Game State
	public int GameState
	{
		get {return _gameState; }
		set {_gameState = value; StateUpdated(); }
	}
		
	// Use this for initialization
	void Start () {
		_LevelGenerator = GetComponent<LevelGenerator>();
		GameState = 1;
	}
	
	// Called whenever GameState is changed
	void StateUpdated()
	{
		if(_gameState == (int)_gameStateName.Game) 
		{
			_LevelGenerator.CreateLevel (1);			// Create the Level(Put walls, put balls)
			GetComponent<LevelManager>().IniLvlManag();	// Initialize the PadManager(Find the Top and bottom Wall to limit the pad movement)
			GetComponent<AIControl>().IniAI();			// Initialize the AI(Find the ball)
			GetComponent<PadManager>().IniPadManag();	// Initialize the PadManager(Find the Top and bottom Wall to limit the pad movement)
			
			
		}
	}
}
