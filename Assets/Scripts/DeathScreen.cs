using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		if ( Globals.State == eGameState.GameOver )
		{
			foreach ( InControl.InputDevice device in InControl.InputManager.Devices )
			{
				if ( device.GetControl( InControl.InputControlType.Start ) )
				{
					Globals.ReloadScene();
					break;
				}
				else if ( device.GetControl( InControl.InputControlType.Back ))
				{
					Globals.ReturnToTitle();
					break;
				}
			}
		}
	}
}
