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

public class LevelQuery : MonoBehaviour 
{
	// Used for determining where to place the players
	[SerializeField] Transform Player1Camera;
	[SerializeField] Transform Player2Camera;
	[SerializeField] QuadFlipper Flipper;

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
