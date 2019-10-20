using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonUIScript : MonoBehaviour {

    public RectTransform chargebar;
    public CannonScript cannonscript;
    public float ballSize;

    // Use this for initialization
    void Start ()
    {
        chargebar = GameObject.Find("ChargeMeter/Bar").GetComponent<RectTransform>();
        cannonscript = GameObject.Find("launchlocation").GetComponent<CannonScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        chargebar = GameObject.Find("ChargeMeter/Bar").GetComponent<RectTransform>();
        cannonscript = GameObject.Find("launchlocation").GetComponent<CannonScript>();
        ballSize = cannonscript.ballSize;
        chargebar.localScale = new Vector3(ballSize/100, 1, 1);
    }
}
