using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
	
	
	private GameManager _GameManager;
	private int _gameState = 0;
	private int _menuState = 1;
	private enum _menuStateName {
		None,  // 0
		Main,  // 1
		Skill, // 2
	}
	
	// Use this for initialization
	void Start () {
		_GameManager = GetComponent<GameManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		_gameState = _GameManager.GameState;
	}
	
	void OnGUI()
	{
		float width = Screen.width;
		float height = Screen.height;
		
		// Display the main menu
		if(_menuState == (int)_menuStateName.Main && _gameState == 0)
		{
			
			
			if(GUI.Button(new Rect(width*0.3f, height*0.4f, width*0.4f, height*0.1f ), "START"))
			{
				_GameManager.GameState = 1;
			}
			
			
		}
	}
}
