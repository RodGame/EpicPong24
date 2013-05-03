using UnityEngine;
using System.Collections;
using System.Collections.Generic; // For List class;

public class GameGUI : MonoBehaviour {
	
	
	public AudioClip MenuClick1Sound;
	public AudioClip MenuClick2Sound;
	public Texture WhiteTexture;
	
	private GameManager _GameManager;
	private LevelManager _LevelManager;
	private PlayerStats _Player;
	
	private int _gameState = 0;
	private Camera PlayerCam;
	private float width = Screen.width;
	private float height = Screen.height;
	private const float LINE_HEIGHT = 20.0f;	// Line Height
	private const float OFFSET      = LINE_HEIGHT + 5.0f;
	private float leftPos = 20.0f;
	private float topPos  = 20.0f;
	private float _nbrLvl;
	private string _mouseOver;
	private int _curLevelHover;
	
	// Use this for initialization
	void Start () {
		_GameManager = GetComponent<GameManager>();
		_LevelManager = GetComponent<LevelManager>();
		_Player = _GameManager.Player;
		_nbrLvl = _LevelManager.nbrLevel;
		PlayerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		
		leftPos = width*0.05f;
		topPos = height*0.10f;
	}
	
	// Update is called once per frame
	void Update () {
		_gameState = _GameManager.GameState;
		
		_curLevelHover = -1;
		
		for(int i = 0; i < _nbrLvl; i++)
		{
			if(_mouseOver == ("MouseOverOnButton" + i.ToString()))
			{
				_curLevelHover = i;
			}
			
		}
		
	}
	
	void OnGUI()
	{
		topPos = height*0.10f;
		
		// Display Menu GUI
		if(_gameState == 0)
		{
			DisplayStats();
			DisplayLevels();
			DisplayFloatingGUI();
		}
		
		// Display In-Game GUI
		if(_gameState == 1)
		{	
			if(GUI.Button(new Rect(width*0.40f, height*0.03f, width*0.2f, height*0.05f), "Return to menu"))
			{
				_LevelManager.LoseGame();	
			}
			GUI.Label (new Rect(width*0.05f, height*0.05f, width*0.2f, height*0.05f), "Player1's Life : " + _LevelManager.LifePlayer1);
			GUI.Label (new Rect(width*0.80f, height*0.05f, width*0.2f, height*0.1f), "Player2's Life : " + _LevelManager.LifePlayer2);	
		}
	}
	
	// Display the floating GUI when hovering Level Button
	private void DisplayFloatingGUI()
	{
		List<string> levelInfo = new List<string>();
		if(_curLevelHover != -1)
		{
			levelInfo.Add ("LEVEL DESCRIPTION");
			levelInfo.Add ("-----------------");
			levelInfo.Add (_LevelManager.Levels[_curLevelHover].Description);
			levelInfo.Add ("Exp on win : " + _LevelManager.Levels[_curLevelHover].ExperienceWorth);
			levelInfo.Add ("AI's Life  : " + _LevelManager.Levels[_curLevelHover].AILifes);
			levelInfo.Add ("AI's Speed : " + _LevelManager.Levels[_curLevelHover].AIPadSpeed);
			levelInfo.Add ("AI's Size  : " + _LevelManager.Levels[_curLevelHover].AIPadSize);
			levelInfo.Add ("Ball Size  : " + _LevelManager.Levels[_curLevelHover].BallSize);
			levelInfo.Add ("Ball Speed  : " + _LevelManager.Levels[_curLevelHover].BallVel);
			DisplayFloatingLabels(levelInfo) ;
		}
	}
	
	// Display a floating labels at mouse position
	private void DisplayFloatingLabels(List<string> _toDisplay) 
	{
		
		float _posX  = Input.mousePosition.x; float _posY  = Mathf.Abs(Input.mousePosition.y - PlayerCam.pixelHeight) + LINE_HEIGHT;
		float _sizeX = width*0.4f;   float _sizeY = _toDisplay.Count*LINE_HEIGHT;
		float _opacity = 0.75f;
		GUI.color = Color.white;
		
		DisplayTransparentBackground(_posX, _posY, _sizeX, _sizeY, _opacity);
		
		// Display string[] in FloatingLabels
		for(int i = 0; i < _toDisplay.Count; i++)
		{
			GUI.Label (new Rect(_posX, _posY + i*LINE_HEIGHT , _sizeX, LINE_HEIGHT), _toDisplay[i]);
		}
	}
	
	// Display a transparent background for floating labels
	private void DisplayTransparentBackground(float _posX, float _posY, float _sizeX, float _sizeY, float _opacity)
	{
		Rect _objRect= new Rect(_posX, _posY, _sizeX, _sizeY);
		
		// Display semi-transparent background for processes and set color back to white
		GUI.color = new Color(0.3f, 0.3f, 0.3f, _opacity);
		GUI.DrawTexture(_objRect, WhiteTexture);
		GUI.color = Color.white;
	}
	
	// Display Level's button
	void DisplayLevels()
	{
		float levelTopPos = topPos + OFFSET*3;
		
		GUI.Label  (new Rect(leftPos, levelTopPos, width*0.2f , LINE_HEIGHT), "LEVELS : ");
		Debug.Log (_nbrLvl);
			for(int i = 1; i < _nbrLvl; i++)
			{
				if(GUI.Button (new Rect(leftPos + 2*i*OFFSET, levelTopPos + 2f*OFFSET, 2f*LINE_HEIGHT, 2f*LINE_HEIGHT),new GUIContent(i.ToString(),"MouseOverOnButton" + i.ToString())))
				{	
					
					_GameManager.SelectLevel (i);	
					audio.PlayOneShot(MenuClick2Sound);
				}
				_mouseOver = GUI.tooltip;
			}
		
		
		
		
	}
		
	void DisplayStats()
	{
		
		
	// Experience Left
		GUI.Label (new Rect(width*0.05f, height*0.05f, width*0.2f, height*0.1f), "Points Left : " + _Player.ExperienceLeft);
		
		// Pad Size
		GUI.Label  (new Rect(leftPos                        , topPos, width*0.2f , LINE_HEIGHT), "Pad Size : ");
	 if(GUI.Button (new Rect(leftPos + width*0.2f           , topPos, LINE_HEIGHT, LINE_HEIGHT), "-"))		{UpdateStat("Size",-1);}
		GUI.Label  (new Rect(leftPos + width*0.2f + 1*OFFSET, topPos, width*0.2f , LINE_HEIGHT),  _Player.PadSizeLevel.ToString ());
	 if(GUI.Button (new Rect(leftPos + width*0.2f + 2*LINE_HEIGHT, topPos, LINE_HEIGHT, LINE_HEIGHT), "+")) {UpdateStat("Size", 1);}
		GUI.Label  (new Rect(leftPos + width*0.2f + 4*OFFSET, topPos, width*0.2f, LINE_HEIGHT), "Cost : " + (Mathf.Pow (_Player.PadSizeLevel,2)));
		
		topPos = topPos + OFFSET;
		
		// Pad Speed
		GUI.Label  (new Rect(leftPos                        , topPos, width*0.2f, LINE_HEIGHT), "Pad Speed : ");
	 if(GUI.Button (new Rect(leftPos + width*0.2f           , topPos, LINE_HEIGHT, LINE_HEIGHT), "-"))		{UpdateStat("Speed",-1);}
		GUI.Label  (new Rect(leftPos + width*0.2f + 1*OFFSET, topPos, width*0.2f , LINE_HEIGHT),  _Player.PadSpeedLevel.ToString ());
	 if(GUI.Button (new Rect(leftPos + width*0.2f + 2*LINE_HEIGHT, topPos, LINE_HEIGHT, LINE_HEIGHT), "+"))	{UpdateStat("Speed", 1);}
		GUI.Label  (new Rect(leftPos + width*0.2f + 4*OFFSET, topPos, width*0.2f, LINE_HEIGHT), "Cost : " + (Mathf.Pow (_Player.PadSpeedLevel,2)));
		
		topPos = topPos + OFFSET;
		
		// Pad Lives
		GUI.Label  (new Rect(leftPos                        , topPos, width*0.2f, LINE_HEIGHT), "Pad Lives : ");
	 if(GUI.Button (new Rect(leftPos + width*0.2f           , topPos, LINE_HEIGHT, LINE_HEIGHT), "-"))		{UpdateStat("Life",-1);}
		GUI.Label  (new Rect(leftPos + width*0.2f + 1*OFFSET, topPos, width*0.2f , LINE_HEIGHT),  _Player.PadLives.ToString ());
	 if(GUI.Button (new Rect(leftPos + width*0.2f + 2*LINE_HEIGHT, topPos, LINE_HEIGHT, LINE_HEIGHT), "+"))	{UpdateStat("Life", 1);}
		GUI.Label  (new Rect(leftPos + width*0.2f + 4*OFFSET, topPos, width*0.2f, LINE_HEIGHT), "Cost : " + (Mathf.Pow (_Player.PadLives,3)));
	}	
		
	// Update the value of a stat from the GUI
	void UpdateStat(string _stat, int _inc)
	{
		audio.PlayOneShot(MenuClick1Sound);
		switch(_stat)
		{
			case "Size":
				if(_inc == 1 && _Player.ExperienceLeft >=  Mathf.Pow (_Player.PadSizeLevel,2))
				{
					_Player.ExperienceLeft -=  (int)Mathf.Pow (_Player.PadSizeLevel,2);
					_Player.PadSizeLevel++;
				}
				else if(_inc == -1 && _Player.PadSizeLevel > 1)
				{
					_Player.PadSizeLevel--;	
					_Player.ExperienceLeft +=  (int)Mathf.Pow (_Player.PadSizeLevel,2);
				}
				break;
			case "Speed":
				if(_inc == 1 && _Player.ExperienceLeft >=  Mathf.Pow (_Player.PadSpeedLevel,2))
				{
					_Player.ExperienceLeft -=  (int)Mathf.Pow (_Player.PadSpeedLevel,2);
					_Player.PadSpeedLevel++;
				}
				else if(_inc == -1 && _Player.PadSpeedLevel > 1)
				{
					_Player.PadSpeedLevel--;	
					_Player.ExperienceLeft +=  (int)Mathf.Pow (_Player.PadSpeedLevel,2);
				}
				break;
			
			case "Life":
				if(_inc == 1 && _Player.ExperienceLeft >=  Mathf.Pow (_Player.PadLives,3))
				{
					_Player.ExperienceLeft -=  (int)Mathf.Pow (_Player.PadLives,3);
					_Player.PadLives++;
				}
				else if(_inc == -1 && _Player.PadLives > 1)
				{
					_Player.PadLives--;	
					_Player.ExperienceLeft +=  (int)Mathf.Pow (_Player.PadLives,3);
				}
				break;
		}
		
	}
	
	
	
}
