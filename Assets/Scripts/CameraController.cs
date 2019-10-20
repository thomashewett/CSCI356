using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class CameraController : NetworkBehaviour {
    public bool activated = false;
    public Camera cameraObject;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (activated)
        {
            cameraObject.enabled = true;
        }
        else
            cameraObject.enabled = false;
    }

    public void Activate()
    {
        activated = true;
    }
    public void Deactivate()
    {
        activated = false;
    }
}
