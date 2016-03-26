using UnityEngine;
using UnityEngine.UI;
using InControl;
using System.Collections;

public class ChoiceSelector : MonoBehaviour {

    [SerializeField] private Image selectGame = null;
    [SerializeField] private Image selectExit = null;
    [SerializeField] private AudioSource audio = null;
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
            if (!audio.isPlaying)
            {
                audio.clip = ding;
                audio.Play();
            }
            selectGame.enabled = false;
            selectExit.enabled = true;
        }
        if (InputManager.Devices[0].DPadUp.HasChanged)
        {
            if (!audio.isPlaying)
            {
                audio.clip = ding;
                audio.Play();
            }
            selectGame.enabled = true;
            selectExit.enabled = false;
        }
        if (InputManager.Devices[0].Action1.IsPressed)
        {
            audio.Stop();
            audio.clip = selectDing;
            audio.Play();
            if (selectExit.enabled == true)
            {
                Application.Quit();
            }
        }
	}
}
