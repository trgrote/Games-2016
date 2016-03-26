using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		// Check to see if I'm the only one in existence
		foreach ( SoundPlayer music in GameObject.FindObjectsOfType<SoundPlayer>() )
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

	public void PlaySound( AudioClip clip )
	{
		var audio = GetComponent<AudioSource>();
		audio.clip = clip;

		audio.Play();
	}
}
