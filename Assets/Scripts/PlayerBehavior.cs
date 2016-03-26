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

public class PlayerBehavior : MonoBehaviour {

    public PlayerSelect player = PlayerSelect.PLAYER2;
    private PlayerStatus status = PlayerStatus.Idle;
    private int movement = 0;
    private InputDevice device = null;
    private Vector2 direction = new Vector2(0, 0);
    private Rigidbody2D body;

	// Use this for initialization
	void Start () 
    {
        if (InputManager.Devices.Count > 1)
        {
            device = InputManager.Devices[player == PlayerSelect.PLAYER1 ? 0 : 1]; 
            Debug.Log(player + " connected to " + device.Name);
        }
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (device == null)
            return;
        
        if (status == PlayerStatus.Idle)
        {
            direction = device.DPad.Vector;

            if (direction.x != 0.0f || direction.y != 0.0f)
            {
                RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, 0.5f);
                if (ray.collider == null)
                {
                    status = PlayerStatus.Moving;
                }
            }
        }
        if (status == PlayerStatus.Moving)
        {
            body.position = new Vector2(body.position.x + direction.x * 0.02f, body.position.y + direction.y * 0.02f);
            movement += 2;
            if (movement == 50)
            {
                movement = 0;
                status = PlayerStatus.Idle;
            }
        }
	}
}
