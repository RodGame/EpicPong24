/// <summary>
/// Level manager.
/// Responsible for the current level being played.
/// This script give point to player, reinitialize ball and will give Success/Fail to the current level when it'll be implemented
/// </summary>


using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public int LifePlayer1;
	public int LifePlayer2;
	public Level[] Levels;
	public int nbrLevel = 7;
	public Level curLevel = new Level();
	
	private GameObject _Ball;
	private GameManager _GameManager;
	private LevelGenerator _LevelGenerator;
	private GameObject _TopWall;
	private GameObject _BotWall;
	private int _gameState;
	private int _curLevelNbr;
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
		iniLevels();
	}
	
	//Initialize the value of all Levels
	void iniLevels()
	{
		Levels = new Level[nbrLevel];
		Level dummyLevel = new Level();
		
		// Level 1
		dummyLevel.AILifes    = 2;
		dummyLevel.AIPadSize  = 1.0f;
		dummyLevel.AIPadSpeed = 3.5f;
		dummyLevel.ExperienceWorth = 3;
		dummyLevel.Description = "Hey, this game is pretty easy!";
		dummyLevel.BallSize    = 0.5f;
		dummyLevel.BallVel     = new Vector2(4.0f, 4.0f);
		Levels[1] = dummyLevel;
 		dummyLevel = new Level();
		
		// Level 2
		dummyLevel.AILifes    = 3;
		dummyLevel.AIPadSize  = 3.5f;
		dummyLevel.AIPadSpeed = 2.0f;
		dummyLevel.ExperienceWorth = 4;
		dummyLevel.Description = "That big and slow paddle won't stop me...";
		dummyLevel.BallSize    = 0.5f;
		dummyLevel.BallVel     = new Vector2(-5.0f, 3.0f);
		Levels[2] = dummyLevel;
		dummyLevel = new Level();
		
		// Level 3
		dummyLevel.AILifes    = 3;
		dummyLevel.AIPadSize  = 1.0f;
		dummyLevel.AIPadSpeed = 4.0f;
		dummyLevel.ExperienceWorth = 5;
		dummyLevel.Description = "That small and fast paddle either!!";
		dummyLevel.BallSize    = 0.5f;
		dummyLevel.BallVel     = new Vector2(7.0f, -4.0f);
		Levels[3] = dummyLevel;
		dummyLevel = new Level();
		
		// Level 4
		dummyLevel.AILifes    = 6;
		dummyLevel.AIPadSize  = 1.0f;
		dummyLevel.AIPadSpeed = 4.5f;
		dummyLevel.ExperienceWorth = 10;
		dummyLevel.Description = "I've seen quicker and smaller balls in my young time.";
		dummyLevel.BallSize    = 0.25f;
		dummyLevel.BallVel     = new Vector2(-7.0f, -5.0f);
		Levels[4] = dummyLevel;
		dummyLevel = new Level();
		
		// Level 5
		dummyLevel.AILifes    = 6;
		dummyLevel.AIPadSize  = 1.0f;
		dummyLevel.AIPadSpeed = 4.5f;
		dummyLevel.ExperienceWorth = 10;
		dummyLevel.Description = "What happening in there ?";
		dummyLevel.BallSize    = 0.5f;
		dummyLevel.BallVel     = new Vector2(7.0f, -4.0f);
		Levels[5] = dummyLevel;
		dummyLevel = new Level();
		
		// Level 6
		dummyLevel.AILifes    = 6;
		dummyLevel.AIPadSize  = 2.0f;
		dummyLevel.AIPadSpeed = 3.5f;
		dummyLevel.ExperienceWorth = 10;
		dummyLevel.Description = "This is getting ridiculous.";
		dummyLevel.BallSize    = 0.5f;
		dummyLevel.BallVel     = new Vector2(-7.0f, 2.0f);
		Levels[6] = dummyLevel;
	}
	
	void Update()
	{
		_gameState = _GameManager.GameState;	
		
		if(_gameState == 1)
		{
			if(_curLevelNbr == 5)
			{
				MoveWalls ();	
			}
			
			
			// Verify that ball hasn't got out of the limit
			if(_Ball.transform.position.x < _BotWall.transform.position.x - _BotWall.transform.localScale.x/2)
			{
				LifePlayer1--;
				if(LifePlayer1 == 0)
				{
					LoseGame();
				}
				ReinitializeBall();
			}
			else if(_Ball.transform.position.x > _BotWall.transform.position.x + _BotWall.transform.localScale.x/2)
			{
				LifePlayer2--;
				if(LifePlayer2 == 0)
				{
					WinGame();	
				}
				ReinitializeBall();
			}
		}
	}
	
	void MoveWalls()
	{
		_TopWall.transform.position = new Vector3(_TopWall.transform.position.x,  3.0f - 1.0f*Mathf.Sin (Time.time) ,_TopWall.transform.position.z);
		_BotWall.transform.position = new Vector3(_BotWall.transform.position.x, -3.0f + 1.0f*Mathf.Sin (Time.time) ,_BotWall.transform.position.z);
		
		Debug.Log (0.15f*Mathf.Sin (10*Time.deltaTime));
	}
	
	// Get exp and return to screen
	void WinGame()
	{
		_GameManager.Player.ExperienceLeft += curLevel.ExperienceWorth;
		DestroyAllObjects();
		_GameManager.GameState = 0;	
	}
	
	// Return to screen
	public void LoseGame()
	{
		DestroyAllObjects();
		_GameManager.GameState = 0;	
	}
	
	// Destroy the Walls, Ball and Pads
	void DestroyAllObjects()
	{
		GameObject[] _Walls   = GameObject.FindGameObjectsWithTag("Wall");
		GameObject[] _Balls   = GameObject.FindGameObjectsWithTag("Ball");
		GameObject _TopWall   = GameObject.FindGameObjectWithTag("TopWall");
		GameObject _BotWall   = GameObject.FindGameObjectWithTag("BotWall");
		GameObject _PlayerPad = GameObject.FindGameObjectWithTag("PlayerPad");
		GameObject _AIPad     = GameObject.FindGameObjectWithTag("AIPad");
		
		//Destroy all Walls
		foreach(GameObject _Wall in _Walls)
		{
			Destroy(_Wall);
		}
		
		//Destroy all Balls
		foreach(GameObject _Ball in _Balls)
		{
			Destroy(_Ball);
		}
		
		Destroy (_TopWall);
		Destroy (_BotWall);
		Destroy (_PlayerPad);
		Destroy (_AIPad);
		
	}
	
	//Reinitialize the ball to its initalize position
	public void ReinitializeBall()
	{
		_Ball.transform.position = Vector3.zero;
		_Ball.rigidbody.velocity = new Vector3(5.0f, 3.0f, 0.0f);
	}
	
	//
	public void IniLvlManag(int _lvlToSet)
	{
		_curLevelNbr = _lvlToSet;
		
		// Find the Ball
		_Ball = GameObject.FindGameObjectWithTag("Ball"); 
		if(_Ball == null) {Debug.LogError("AIControl E02 - Ball not found");} 
				
		// Find Top Wall, return error if null
		_TopWall = GameObject.FindGameObjectWithTag("TopWall"); 
		if(_TopWall == null) {Debug.LogError("PadManager E01 - Top Wall not found");}
		
		// Find Bottom Wall, return error if null
		_BotWall = GameObject.FindGameObjectWithTag("BotWall"); 
		if(_BotWall == null) {Debug.LogError("PadManager E02 - Bot Wall not found");} 		
	
		LifePlayer1 = _GameManager.Player.PadLives;
		LifePlayer2	= curLevel.AILifes;
	}
	
	public void SetupCurLevel(int _lvlToSet)
	{
		curLevel = Levels[_lvlToSet];	
	}
}
