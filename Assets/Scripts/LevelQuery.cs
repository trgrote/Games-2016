using UnityEngine;
using System.Collections;

public class FlipBeginEvent : IGameEvent
{

}

public enum eLevelSection
{
	One,
	Two
}

public class LevelQuery : MonoBehaviour, IEventHandler
{
	void Start()
	{
		EventBroadcaster.registerHandler<PlayerDeathEvent>(this);
		EventBroadcaster.registerHandler<OnGoal>(this);
	}

	public void handleEvent( IGameEvent evt )
	{
		if ( evt is PlayerDeathEvent )
		{
			// ON Death, switch state
			Globals.State = eGameState.GameOver;
			// display death screen
			DeathScreen.SetActive(true);
		}
		else if ( evt is OnGoal )
		{
			// Check if all players are on goals
			bool allOnGoal = true;
			foreach ( var obj in GameObject.FindObjectsOfType(typeof(PlayerBehavior)) )
			{
				PlayerBehavior player = obj as PlayerBehavior;
				if ( player.onGoal == false )
					allOnGoal = false;
			}
		}
	}

	// Used for determining where to place the players
	[SerializeField] Transform Player1Camera;
	[SerializeField] Transform Player2Camera;
	[SerializeField] QuadFlipper Flipper;
	[SerializeField] GameObject DeathScreen;

	public Vector3 GetSwappedLocation( eLevelSection section, Vector3 position )
	{
		// take absolute location and convert to new location
		Vector3 camPosition = section == eLevelSection.One ? Player1Camera.transform.position : Player2Camera.transform.position;
		Vector3 newCamPosition = section == eLevelSection.Two ? Player1Camera.transform.position : Player2Camera.transform.position;
		Vector3 offset = position - camPosition;

		Vector3 newPosition = newCamPosition + offset;

		return newPosition;
	}
}
