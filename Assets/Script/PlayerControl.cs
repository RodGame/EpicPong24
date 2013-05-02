using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	
	private GameObject  _PlayerPad;
	private GameManager _GameManager;
	private PadManager  _PadManager;
	private int _gameState;
	
	private float _playerPadSpeed = 10.0f;
	// Use this for initialization
	void Start () {
		_GameManager = GetComponent<GameManager>();
		_PadManager = GetComponent<PadManager>();
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
		
		if(Input.GetKey(KeyCode.W) || Input.GetKey (KeyCode.UpArrow))
		{
			_PadManager.TranslatePad (_PlayerPad, _playerPadSpeed);
		}
		
		if(Input.GetKey(KeyCode.S) || Input.GetKey (KeyCode.DownArrow))
		{
			_PadManager.TranslatePad (_PlayerPad, -_playerPadSpeed);
		}
		
	}
}
