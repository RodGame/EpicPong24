using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
		
	private LevelGenerator _LevelGenerator;
	private int _gameState = 0; // 0 = menu, 1 = game
	private enum _gameStateName {
		Menu,  // 0
		Game,  // 1
	}	
		
		
	// Use this for initialization
	void Start () {
		_LevelGenerator = GetComponent<LevelGenerator>(); 
	}
	

	void StateUpdated()
	{
		if(_gameState == (int)_gameStateName.Game) 
		{
			_LevelGenerator.IniLevel (1);
			GetComponent<AIControl>().iniAI();
			
		}
	}
	
	public int GameState
	{
		get {return _gameState; }
		set {_gameState = value; StateUpdated(); }
	}
	
	public void TranslatePad(GameObject _Pad, float _deltaY)
	{
		
		
		
	}
	
}
