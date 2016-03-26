using UnityEngine;
using UnityEngine.UI;
using InControl;
using System.Collections;

public class ChoiceSelector : MonoBehaviour {

    [SerializeField] private Image selectGame = null;
    [SerializeField] private Image selectExit = null;
    [SerializeField] private AudioSource audio = null;

	// Use this for initialization
	void Start () {
        selectGame.enabled = true;
        selectExit.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (InputManager.Devices[0].DPadDown.HasChanged)
        {
            selectGame.enabled = false;
            selectExit.enabled = true;
        }
        if (InputManager.Devices[0].DPadUp.HasChanged)
        {
            selectGame.enabled = true;
            selectExit.enabled = false;
        }
	}
}
