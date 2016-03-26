using UnityEngine;
using System.Collections;

public class GameStateHandler : MonoBehaviour, IEventHandler
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
}
