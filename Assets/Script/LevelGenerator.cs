/// <summary>
/// This script is responsible of the creation of the levels.
/// It create Pads, Balls and walls
/// </summary>

using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
	
	// Public Variables
	public GameObject WallPrefab;
	public GameObject PadPrefab;
	public GameObject BallPrefab;
	
	// Private Variables
	private GameObject _PlayerPad;
	private GameObject _AIPad;
	private GameManager _GameManager;
	private LevelManager _LevelManager;
	
	private Vector3 _playerPadPosition = new Vector3(-5,0,0);
	private Vector3 _AIPadPosition     = new Vector3( 5,0,0);
	
	private float _GameZPos  = 0.0f; // The Z position of all object. 
	private float _wallThick  = 0.2f;
	private float _curLevel = 0;
	
	
	// Functions
	
	void Start()
	{
		_GameManager = GetComponent<GameManager>();
		_LevelManager = GetComponent<LevelManager>();
	}
	
	
	public void CreateLevel(int _level)
	{
		_curLevel = _level;
		
		// Spawn Walls and Ball
		SpawnPlayerPad();
		SpawnAIPads();
		SpawnWalls();
		SpawnBalls();
	}

	void SpawnPlayerPad()
	{
		// Initialize Player Pad
		_PlayerPad = Object.Instantiate (PadPrefab, _playerPadPosition, Quaternion.identity) as GameObject; // Create the player pad as a GameObject
		_PlayerPad.tag = "PlayerPad";
		_PlayerPad.transform.localScale = new Vector3(_PlayerPad.transform.localScale.x, _GameManager.Player.PadSize, _PlayerPad.transform.localScale.z);
	}
	
	void SpawnAIPads()
	{
		// Initialize AI Pad
		_AIPad     = Object.Instantiate (PadPrefab, _AIPadPosition, Quaternion.identity) as GameObject; // Create the AI     pad as a GameObject
		_AIPad.tag = "AIPad";
	}
	
	// Create Level1 Environment. Will eventually be changed to a more sophisticated level generator
	void SpawnWalls()
	{
		CreateWall(0, 5 ,10, _wallThick, "TopWall");
		CreateWall(0,-5 ,10, _wallThick, "BotWall");
		
		if(_curLevel == 6)
		{
			CreateWall (0f, 3.5f,0.2f,3f);
			CreateWall (0f,-3.5f,0.2f,3f);
		}
	}
	
	public void SpawnBalls()
	{
		
		Vector2 _balVel  = _LevelManager.curLevel.BallVel;
		float   _balSize = _LevelManager.curLevel.BallSize;
		Debug.Log (_balVel.x);
		CreateBall(0, 0, _balVel.x, _balVel.y, _balSize);
	}
	
	//// TOOLS FUNCTIONS
	void CreateBall(float _posX, float _posY, float _velX, float _velY, float _size)
	{
		GameObject _CurBall;
		_CurBall = Object.Instantiate(BallPrefab, new Vector3(_posX, _posY, _GameZPos), Quaternion.identity) as GameObject;   // Create a wall as a gameobject
		_CurBall.transform.localScale = new Vector3(_size, _size, _size);											  // Rescale the wall to the inputted size
		_CurBall.rigidbody.velocity = new Vector3(_velX, _velY, 0.0f);
		
	}
	
	// Create a Wall of a given size at a given position
	void CreateWall(float _posX, float _posY, float _sizeX, float _sizeY)
	{
		GameObject _CurWall;
		_CurWall = Object.Instantiate(WallPrefab, new Vector3(_posX, _posY, _GameZPos), Quaternion.identity) as GameObject;   // Create a wall as a gameobject
		_CurWall.transform.localScale = new Vector3(_sizeX, _sizeY, _wallThick);											  // Rescale the wall to the inputted size
	}
	
	// Create a Wall of a given size at a given position. Add a tag to it.
	void CreateWall(float _posX, float _posY, float _sizeX, float _sizeY, string _TagString)
	{
		GameObject _CurWall;
		_CurWall = Object.Instantiate(WallPrefab, new Vector3(_posX, _posY, _GameZPos), Quaternion.identity) as GameObject;   // Create a wall as a gameobject
		_CurWall.transform.localScale = new Vector3(_sizeX, _wallThick, _sizeY);											  // Rescale the wall to the inputted size
		_CurWall.tag = _TagString;
	
	}
	
	
	
	
}


