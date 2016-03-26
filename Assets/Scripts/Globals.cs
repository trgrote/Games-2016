using UnityEngine;
using System.Collections;

public enum eGameState
{
	GameMode,     // Default Game Mode, players moving around
	Flipping      // Paused Gamed Mode, players can't move
}

public static class Globals
{
	public static eGameState State = eGameState.GameMode;
}
