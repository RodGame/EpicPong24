/// <summary>
/// Pad manager.
/// This script is responsible of preventing the pad from going too high or too low
/// </summary>

using UnityEngine;
using System.Collections;

public class PadManager : MonoBehaviour
{
	private GameObject _TopWall;
	private GameObject _BotWall;
	
	public void IniPadManag()
	{
		FindTopAndBotWall();	
		
	}
			
	// Find the Top and Bottom Wall from their tag. This is used to limit the pad movement
	void FindTopAndBotWall()
	{
		// Find Top Wall, return error if null
		_TopWall = GameObject.FindGameObjectWithTag("TopWall"); 
		if(_TopWall == null) {Debug.LogError("PadManager E01 - Top Wall not found");}
		
		// Find Bottom Wall, return error if null
		_BotWall = GameObject.FindGameObjectWithTag("BotWall"); 
		if(_BotWall == null) {Debug.LogError("PadManager E02 - Bot Wall not found");} 
	}
	
	// Translate a pad and limit it's position with the Top and Bottom Walls
	public void TranslatePad(GameObject _Pad, float _distY) // Input : Pad to be moved, distance in the Y axis to move it
	{
		// Translate the pad
		_Pad.transform.Translate (0.0f, _distY*Time.deltaTime, 0.0f);	
		
		// Limit the pad top position
		if(_Pad.transform.position.y + _Pad.transform.localScale.y/2 > _TopWall.transform.position.y)
		{
			_Pad.transform.position = new Vector3(_Pad.transform.position.x, _TopWall.transform.position.y - _Pad.transform.localScale.y/2, _Pad.transform.position.z);
		}
		
		
		// Limit the pad bottom position
		else if(_Pad.transform.position.y - _Pad.transform.localScale.y/2 < _BotWall.transform.position.y)
		{
			_Pad.transform.position = new Vector3(_Pad.transform.position.x, _BotWall.transform.position.y + _Pad.transform.localScale.y/2, _Pad.transform.position.z);
		}
		
	}
	
	
}
	
