using UnityEngine;
using System.Collections;
using InControl;

public class SuccessScreen : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		foreach ( InControl.InputDevice device in InControl.InputManager.Devices )
			{
				if ( device.GetControl( InControl.InputControlType.Start ))
				{
					Globals.ReturnToTitle();
					break;
				}
			}
	}
}
