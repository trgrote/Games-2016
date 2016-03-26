using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour 
{
	[SerializeField] private GameObject PlayerPrefab;
	[SerializeField] private PlayerSelect Player;
	
	// Use this for initialization
	void Start () 
	{
		// Instantiate Player Object with Current Transform	
		var player_obj = Instantiate( PlayerPrefab, transform.position, transform.rotation );

		// Grab Player Behavior and set index
		var behavior = player_obj.GetComponent<PlayerBehavior>();

		if ( behavior )
		{
			behavior.player = Player;
		}

		// Once Player is created, time to die
		Destroy( gameObject );
	}
}
