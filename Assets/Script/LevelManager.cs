/// <summary>
/// Level manager.
/// Responsible for the current level being played.
/// This script give point to player, reinitialize ball and will give Success/Fail to the current level when it'll be implemented
/// </summary>


using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public int pointPlayer1;
	public int pointPlayer2;
	
	private GameObject _Ball;
	private GameManager _GameManager;
	private LevelGenerator _LevelGenerator;
	private GameObject _TopWall;
	private GameObject _BotWall;
	private int _gameState;

	// Use this for initialization
	
	public GameObject Ball
	{
		get {return _Ball; }
		set {_Ball = value;}
	}
	
	void Start () 
	{
		_GameManager    = GetComponent<GameManager>();
		_LevelGenerator = GetComponent<LevelGenerator>();
	}
	
	void Update()
	{
		_gameState = _GameManager.GameState;	
		
		if(_gameState == 1)
		{
			
			// Verify that ball hasn't got out of the limit
			if(_Ball.transform.position.x < _BotWall.transform.position.x - _BotWall.transform.localScale.x/2)
			{
				pointPlayer2++;
				ReinitializeBall();
			}
			else if(_Ball.transform.position.x > _BotWall.transform.position.x + _BotWall.transform.localScale.x/2)
			{
				pointPlayer1++;
				ReinitializeBall();
			}
		}
	}
	
	public void ReinitializeBall()
	{
		_Ball.transform.position = Vector3.zero;
		_Ball.rigidbody.velocity = new Vector3(5.0f, 3.0f, 0.0f);
	}
	
	public void IniLvlManag()
	{
		// Find the Ball
		_Ball = GameObject.FindGameObjectWithTag("Ball"); 
		if(_Ball == null) {Debug.LogError("AIControl E02 - Ball not found");} 
				
		// Find Top Wall, return error if null
		_TopWall = GameObject.FindGameObjectWithTag("TopWall"); 
		if(_TopWall == null) {Debug.LogError("PadManager E01 - Top Wall not found");}
		
		// Find Bottom Wall, return error if null
		_BotWall = GameObject.FindGameObjectWithTag("BotWall"); 
		if(_BotWall == null) {Debug.LogError("PadManager E02 - Bot Wall not found");} 		
				
	}
}
