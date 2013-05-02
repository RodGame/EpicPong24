/// <summary>
/// Ball manager.
/// This script is responsible of the specific dynamic that is used by paddle(i.e : Steep angle at the limit of the paddle, close to horizontal on the middle
/// </summary>

using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour {
	
	float limitAngle = 0.5f;

	
	// Change ball direction when it collide with pads.
	void OnTriggerEnter(Collider _Collided)
	{
		GameObject _PadCollided = _Collided.gameObject;
		float _contactDeltaY;
		float _contactRatio;
		float _contactRatioPI;
		float _velMagnitude;
		float _newVelX;
		float _newVelY;
	
		// Calculate the ratio between the size of the paddle and the point being hit on the paddle
		_contactDeltaY  = transform.position.y - _PadCollided.transform.position.y;	// Distance on the Y axis between the pad center and the ball center
		_contactRatio   = _contactDeltaY/_PadCollided.transform.localScale.y*2;		// (-1,1) Ratio between the contactDeltaY and the half-length of the paddle.
		_contactRatioPI = limitAngle*_contactRatio*3.141592654f/2;					// Ratio of PI to use for new velocity calculation

		_velMagnitude = rigidbody.velocity.magnitude;	// Magnitude of the velocity to keep it constant
		
		_newVelX = _velMagnitude*Mathf.Cos (_contactRatioPI);	// New velocity in X axis
		_newVelY = _velMagnitude*Mathf.Sin (_contactRatioPI);	// New velocity in Y axis
		
		// Update the ball velocity
		if(transform.rigidbody.velocity.x < 0.0f)
		{
			rigidbody.velocity = new Vector3(_newVelX, _newVelY, 0.0f);
		}
		else if(transform.rigidbody.velocity.x > 0.0f)
		{
			rigidbody.velocity = new Vector3(-_newVelX, _newVelY, 0.0f);
		}
	}	
}
	
