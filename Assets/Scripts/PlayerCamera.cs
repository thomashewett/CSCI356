using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    public GameObject player;
    public GameObject cannon;
	// Use this for initialization
	void Start ()
    {
        player.BroadcastMessage("Activate");
        cannon.BroadcastMessage("Deactivate");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.C))
        {
            player.BroadcastMessage("Activate");
            cannon.BroadcastMessage("Deactivate");
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            cannon.BroadcastMessage("Activate");
            player.BroadcastMessage("Deactivate");
        }
	}
}
