using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum eGameState
{
	GameMode,     // Default Game Mode, players moving around
	Flipping,     // Paused Gamed Mode, players can't move
	Paused,
	GameOver      // Game Paused for Players because they died, press X to restart
}

public static class Globals
{
	public static eGameState State = eGameState.GameMode;

	public static void ReloadScene()
	{
		int currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentScene);
	}

	public static void LoadNextScene()
	{
		int nextScene = SceneManager.GetActiveScene().buildIndex;
		nextScene = ( nextScene + 1 ) % SceneManager.sceneCount;
		SceneManager.LoadScene(nextScene);
	}

	public static void ReturnToTitle()
	{
		SceneManager.LoadScene(0);
	}
}
