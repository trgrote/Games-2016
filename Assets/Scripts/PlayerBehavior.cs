using UnityEngine;
using System.Collections;
using InControl;

public enum PlayerSelect
{
    PLAYER1,
    PLAYER2
}

public class PlayerBehavior : MonoBehaviour {

    public PlayerSelect player = PlayerSelect.PLAYER2;
    private InputDevice device = null;
    private Vector2 direction = new Vector2(0, 0);
    private Rigidbody2D body;

	// Use this for initialization
	void Start () 
    {
        device = InputManager.Devices[player == PlayerSelect.PLAYER1 ? 0 : 1]; 
        body = GetComponent<Rigidbody2D>();
        Debug.Log(player + " connected to " + device.Name);
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (device.DPad.HasChanged)
        {
            direction = device.DPad.Vector;
        }
        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, 2.0f);
        if (ray.collider == null)
        {
            body.position = new Vector2(body.position.x + direction.x * 0.5f, body.position.y + direction.y * 0.5f);
        }
	}
}
