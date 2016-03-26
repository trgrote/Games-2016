using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerBehavior), typeof(SpriteRenderer))]
public class PlayerSkin : MonoBehaviour 
{
	[SerializeField] private Sprite PlayerOne;
	[SerializeField] private Sprite PlayerTwo;

	// Use this for initialization
	void Start () 
	{
		var behavior = GetComponent<PlayerBehavior>();
		var sprite = GetComponent<SpriteRenderer>();

		switch ( behavior.player )
		{
			case PlayerSelect.PLAYER1:
				sprite.sprite = PlayerOne;
				break;
			case PlayerSelect.PLAYER2:
				sprite.sprite = PlayerTwo;
				break;
		}
	}
}
