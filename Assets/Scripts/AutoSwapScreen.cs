using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoSwapScreen : MonoBehaviour 
{
    [SerializeField] private int delayInSeconds = 1;

    private float currentCounter = 0f;
    private QuadFlipper flipper = null;
    private Image bar = null;

	// Use this for initialization
	void Start () 
    {
        flipper = GameObject.FindObjectOfType<QuadFlipper>();
        bar = this.GetComponent<Image>();
        currentCounter = delayInSeconds;
	}
	
	// Update is called once per frame
	void Update () 
    {
        currentCounter -= Time.deltaTime;
        bar.fillAmount = currentCounter / delayInSeconds;
        if (currentCounter <= 0)
        {
            EventBroadcaster.broadcastEvent( new FlipBeginEvent() );
            flipper.PerformQuadSwitch();
            currentCounter = delayInSeconds;
        }
	}
}
