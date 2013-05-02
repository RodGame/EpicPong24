using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	
	private GameObject  _PlayerPad;
	private GameManager _GameManager;
	private int _gameState;
	
	private float _playerPadSpeed = 0.2f;
	// Use this for initialization
	void Start () {
		_GameManager = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		_gameState = _GameManager.GameState;
		
		if(_gameState == 1)
		{
			_PlayerPad = GameObject.FindGameObjectWithTag("PlayerPad"); 
			if(_PlayerPad == null) {Debug.LogError("PlayerControl E01 - Player's Pad not found");} 
			getKeyboardInputs();

		}	
	}
	
	void getKeyboardInputs()
	{
		
		if(Input.GetKey(KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))
		{
			_PlayerPad.transform.Translate (0.0f, _playerPadSpeed, 0.0f);
		}
		
		if(Input.GetKey(KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow))
		{
			_PlayerPad.transform.Translate (0.0f, -_playerPadSpeed, 0.0f);
		}
		
	}
}
