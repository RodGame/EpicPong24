/// <summary>
/// This script is responsible of the AI of the paddle
/// </summary>
using UnityEngine;
using System.Collections;

public class AIControl : MonoBehaviour {

	private GameObject  _AIPad;
	private GameObject  _Ball;
	private GameManager _GameManager;
	private PadManager  _PadManager;
	private LevelManager _LevelManager;
	private int _gameState;
	private float _AIPadSpeed = 2.5f;
	
	// Use this for initialization
	void Start () {
		_GameManager  = GetComponent<GameManager>();
		_PadManager   = GetComponent<PadManager>();
		_LevelManager = GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	_gameState = _GameManager.GameState;	
		if(_gameState == 1)
		{
			_AIPad = GameObject.FindGameObjectWithTag("AIPad"); 
			if(_AIPad == null) {Debug.LogError("AIControl E01 - AI's Pad not found");} 
			getAIInput();
		}	
	}
	
	public void IniAI()
	{
		_Ball = GameObject.FindGameObjectWithTag("Ball"); 
		if(_Ball == null) {Debug.LogError("AIControl E02 - Ball not found");} 
	}
	
	void getAIInput()
	{
		float _deltaY = _Ball.transform.position.y - _AIPad.transform.position.y; // Distance on Y axis between ball and AIPad
		
		
		if(_deltaY > 0.1f)
		{
			_PadManager.TranslatePad (_AIPad, _AIPadSpeed);
		}
		
		else if(_deltaY < -0.1f)
		{
			_PadManager.TranslatePad (_AIPad, -_AIPadSpeed);
		}
	}
	
}
