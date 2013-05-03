using UnityEngine;
using System.Collections;

public class PlayerStats {
	
	
	
	private int _experienceLeft  = 1;
	
	private int   _padSizeLevel  = 1;
	private float _padSizeRatio  = 0.25f;
	private float _padSizeIni    = 0.5f;
	private float _padSize       = 0.75f;
	
	private int   _padSpeedLevel = 1;
	private float _padSpeedRatio = 1.0f;
	private float _padSpeedIni   = 9.0f;
	private float _padSpeed      = 10.0f;
	
	private int _padLives        = 2;
	
	
	public int ExperienceLeft
	{
		get {return _experienceLeft; }
		set {_experienceLeft = value; }
	}
	
	public float PadSize
	{
		get {return _padSize; }
	}
	
	public int PadSizeLevel
	{
		get {return _padSizeLevel; }
		set {_padSizeLevel = value; _padSize = _padSizeIni + _padSizeLevel*_padSizeRatio;}
	}
	
	public float PadSpeed
	{
		get {return _padSpeed; }
	}
	
	public int PadSpeedLevel
	{
		get {return _padSpeedLevel; }
		set {_padSpeedLevel = value; _padSpeed = _padSpeedIni + _padSpeedLevel * _padSpeedRatio;}
	}
	
	public int PadLives
	{
		get {return _padLives; }
		set {_padLives = value; }
	}

}
