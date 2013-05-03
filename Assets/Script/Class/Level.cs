using UnityEngine;
using System.Collections;

public class Level {

	private int     _experienceWorth = 5;
	private int     _AILifes       = 3;
	private float   _AIPadSize     = 2.5f;
	private float   _AIPadSpeed    = 5.0f;
	private bool    _isUnlocked    = true;
	private string  _description   = "";
	private float   _ballSize      = 0.5f;
	private Vector2 _ballVel;
	
	public int ExperienceWorth
	{
		get {return _experienceWorth; }
		set {_experienceWorth = value; }
	}
	
	public float AIPadSize
	{
		get {return _AIPadSize; }
		set {_AIPadSize = value; }
	}
	
	public int AILifes
	{
		get {return _AILifes; }
		set {_AILifes = value; }
	}
	
	public float AIPadSpeed
	{
		get {return _AIPadSpeed; }
		set {_AIPadSpeed = value; }
	}
	
	public bool IsUnlocked
	{
		get {return _isUnlocked; }
		set {_isUnlocked = value; }
	}
	
	public string Description
	{
		get {return _description; }
		set {_description = value; }
	}
	
	public float BallSize
	{
		get {return _ballSize; }
		set {_ballSize = value; }
	}
	
	public Vector2 BallVel
	{
		get {return _ballVel; }
		set {_ballVel = value; }
	}
}
