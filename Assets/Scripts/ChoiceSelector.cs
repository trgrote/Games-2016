using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using InControl;
using System.Collections;

public class ChoiceSelector : MonoBehaviour {

    [SerializeField] private Image selectGame = null;
    [SerializeField] private Image selectExit = null;
    [SerializeField] private AudioClip ding = null;
    [SerializeField] private AudioClip selectDing = null;

	// Use this for initialization
	void Start () {
        selectGame.enabled = true;
        selectExit.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (InputManager.Devices[0].DPadDown.HasChanged)
        {
            var audio = GameObject.FindObjectOfType<SoundPlayer>();
            audio.PlaySound(ding);
            selectGame.enabled = false;
            selectExit.enabled = true;
        }
        if (InputManager.Devices[0].DPadUp.HasChanged)
        {
            var audio = GameObject.FindObjectOfType<SoundPlayer>();
            audio.PlaySound(ding);
            selectGame.enabled = true;
            selectExit.enabled = false;
        }
        if (InputManager.Devices[0].Action1.IsPressed)
        {
            var audio = GameObject.FindObjectOfType<SoundPlayer>();
            audio.PlaySound(selectDing);
            if (selectGame.enabled == true)
            {
                Globals.LoadNextScene();
            }
            if (selectExit.enabled == true)
            {
                Application.Quit();
            }
        }
	}
}
