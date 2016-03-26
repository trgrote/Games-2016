using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour 
{
	[SerializeField] private GameObject PlayerPrefab;
	[SerializeField] private PlayerSelect Player;
	[SerializeField] private eLevelSection LevelSection;
	
	// Use this for initialization
	void Start () 
	{
		// Instantiate Player Object with Current Transform	
		GameObject player_obj = Instantiate( PlayerPrefab, transform.position, transform.rotation ) as GameObject;

		// Grab Player Behavior and set index
		var behavior = player_obj.GetComponent<PlayerBehavior>();

		if ( behavior )
		{
			behavior.player = Player;
			behavior.LevelSection = LevelSection;
		}

		// Once Player is created, time to die
		Destroy( gameObject );
	}
}
