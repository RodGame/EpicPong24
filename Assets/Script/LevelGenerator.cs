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
	
	private Vector3 _playerPadPosition = new Vector3(-5,0,0);
	private Vector3 _AIPadPosition     = new Vector3( 5,0,0);
	
	private float _GameZPos  = 0.0f; // The Z position of all object. 
	private float _wallThick  = 0.2f;
	
	// Functions
	public void IniLevel(int _level)
	{
		// Initialize Player Pad
		_PlayerPad = Object.Instantiate (PadPrefab, _playerPadPosition, Quaternion.identity) as GameObject; // Create the player pad as a GameObject
		_PlayerPad.tag = "PlayerPad";
		// Initialize AI Pad
		_AIPad     = Object.Instantiate (PadPrefab, _AIPadPosition, Quaternion.identity) as GameObject; // Create the AI     pad as a GameObject
		_AIPad.tag = "AIPad";
		CreateLevel1();
	}


	
	// Create Level1 Environment. Will eventually be changed to a more sophisticated level generator
	void CreateLevel1()
	{
		CreateWall(0, 5 ,10, _wallThick);
		CreateWall(0,-5 ,10, _wallThick);
		CreateBall(0, 0, 10.0f, 3.0f, 0.5f);
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
		_CurWall.transform.localScale = new Vector3(_sizeX, _wallThick, _sizeY);											  // Rescale the wall to the inputted size
	}
	
	
	
	
}


