using UnityEngine;
using System.Collections;
using InControl;

public enum PlayerSelect
{
	PLAYER1,
	PLAYER2
}

public enum PlayerStatus
{
	Idle,
	Moving
}

public class PlayerDeathEvent : IGameEvent {}
public class OnGoal : IGameEvent {}

public class PlayerBehavior : MonoBehaviour, IEventHandler
{
	public PlayerSelect player = PlayerSelect.PLAYER2;
	private PlayerStatus status = PlayerStatus.Idle;
	private int movement = 0;
	private InputDevice device = null;
	private Vector2 direction = new Vector2(0, 0);
	private Rigidbody2D body;

	[HideInInspector] public bool onGoal = false;

	[HideInInspector] public eLevelSection LevelSection;

	protected InputDevice getPlayerInputDevice()
	{
		return InputManager.Devices.Count > (int) player ?
			InputManager.Devices[ (int) player ] : null;
	}

	public Collider2D collidingWithAnything()
	{
		// Cast myself in the current position
		Physics2D.queriesHitTriggers = true;
		
		return Physics2D.OverlapPoint( transform.position );
	}

	public void handleColliding()
	{
		// Cast myself in the current position
		Physics2D.queriesHitTriggers = true;
		
		var collider = Physics2D.OverlapPoint( transform.position );

		if ( collider != null )
		{
			if ( collider.tag.Equals( "Death" ) )
			{
				EventBroadcaster.broadcastEvent( new PlayerDeathEvent() );
			}
			else if ( collider.tag.Equals( "Goal" ) )
			{
				// Handling Walking into the goal
				onGoal = true;
				EventBroadcaster.broadcastEvent( new OnGoal() );
			}
			else
			{
				// We probably got a wall?
				EventBroadcaster.broadcastEvent( new PlayerDeathEvent() );
			}
		}
	}

	// Use this for initialization
	void Start () 
	{
		device = getPlayerInputDevice();

		if (device != null)
		{
			Debug.Log(player + " connected to " + device.Name);
		}
		else
		{
			Debug.LogWarning("Failed to find controller for player " + player );
		}
		body = GetComponent<Rigidbody2D>();

		// Register to Flipping the fuck out
		EventBroadcaster.registerHandler<FlipBeginEvent>(this);
	}

	void OnDisable()
	{
		EventBroadcaster.unregsterHandler( this );
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (device == null)
			return;

		if ( Globals.State != eGameState.GameMode )
            return;
		
		if (status == PlayerStatus.Idle)
		{
			direction = device.DPad.Vector;

			if ((direction.x != 0.0f && direction.y == 0.0f) || (direction.x == 0.0f && direction.y != 0.0f))
			{
				Physics2D.queriesHitTriggers = false;
				RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, 0.5f);
				if (ray.collider == null)
				{
					status = PlayerStatus.Moving;
				}
			}
		}
		if (status == PlayerStatus.Moving)
		{
			onGoal = false;
			body.position = new Vector2(body.position.x + direction.x * 0.02f, body.position.y + direction.y * 0.02f);
			movement += 2;
			if (movement == 50)
			{
				movement = 0;
				status = PlayerStatus.Idle;
				// Check if colliding with anything
				handleColliding();
			}
		}
	}

	public void handleEvent( IGameEvent evt )
	{
		if ( evt is FlipBeginEvent )
		{
			// Find my baby
			var query = GameObject.Find("LevelQuery");
			var component = query.GetComponent<LevelQuery>();

			Vector3 newPosition = component.GetSwappedLocation( LevelSection, transform.position );

			this.LevelSection = LevelSection == eLevelSection.One ? eLevelSection.Two : eLevelSection.One;

			body.position = newPosition;

			// IF we're currently moving, then don't check collision yet
			if ( status != PlayerStatus.Moving )
			{
				handleColliding();
			}
		}
	}
}
