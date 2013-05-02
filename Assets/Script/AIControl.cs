using UnityEngine;
using System.Collections;

public class AIControl : MonoBehaviour {

	private GameObject  _AIPad;
	private GameObject  _Ball;
	private GameManager _GameManager;
	private int _gameState;
	private float _AIPadSpeed = 0.1f;
	
	// Use this for initialization
	void Start () {
		_GameManager = GetComponent<GameManager>();
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
	
	public void iniAI()
	{
		FindBall();
	}
	
	void FindBall()
	{
		_Ball = GameObject.FindGameObjectWithTag("Ball"); 
		if(_Ball == null) {Debug.LogError("AIControl E02 - Ball not found");} 
	}
	
	
	void getAIInput()
	{
		float _deltaY = _Ball.transform.position.y - _AIPad.transform.position.y; // Distance on Y axis between ball and AIPad
		
		
		if(_deltaY > 0.1f)
		{
			_AIPad.transform.Translate (0.0f, _AIPadSpeed, 0.0f);
		}
		
		else if(_deltaY < -0.1f)
		{
			_AIPad.transform.Translate (0.0f, -_AIPadSpeed, 0.0f);
		}
	}
	
}
