using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MainMenuMusic : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		// Check to see if I'm the only one in existence
		foreach ( MainMenuMusic music in GameObject.FindObjectsOfType<MainMenuMusic>() )
		{
			// If there is already one, kill yourself
			if ( music != this )
			{
				Destroy( this.gameObject );
				break;
			}
		}

		DontDestroyOnLoad(this.gameObject);
	}
}
