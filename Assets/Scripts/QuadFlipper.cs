using UnityEngine;
using System.Collections;

public class QuadFlipper : MonoBehaviour 
{
	[SerializeField] private Transform Quad1;
	[SerializeField] private Transform Quad2;

	[SerializeField] private float SwitchTime = 1.0f;
	IEnumerator flipCoroutine;

	private bool currentlyFlipping = false;

	public void PerformQuadSwitch()
	{
		if ( ! currentlyFlipping )
		{
			StartCoroutine( flipCoroutine = Flip() );
			currentlyFlipping = true;
		}
	}

	private IEnumerator Flip()
	{
		// Get Current Transforms of the Quads
		Vector3 quad1_pos = Quad1.transform.position;
		Vector3 quad2_pos = Quad2.transform.position;
		float distance = Mathf.Abs( Vector3.Distance( quad1_pos, quad2_pos ) );
		float speed = distance / SwitchTime;
		// Transition Quad positions until they over X amount of time until they reach their destination
		float elapsed_time = 0.0f;
		while ( elapsed_time < SwitchTime )
		{
			elapsed_time += Time.deltaTime;
			// Move Quads a little bit closer to target
			Quad1.transform.position = Vector3.Lerp( quad1_pos, quad2_pos, elapsed_time * speed / distance ); 
			Quad2.transform.position = Vector3.Lerp( quad2_pos, quad1_pos, elapsed_time * speed / distance ); 
			yield return null;
		}

		// When done, just pop them to their locations
		Quad1.transform.position = quad2_pos;
		Quad2.transform.position = quad1_pos;

		currentlyFlipping = false;
		yield return null;
	}
}
