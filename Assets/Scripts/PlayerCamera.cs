using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCamera : NetworkBehaviour {
    public GameObject player;
    public GameObject cannon;
    //public GameObject user;
    // Use this for initialization
    void Start ()
    {
        player.BroadcastMessage("Activate");
        cannon.BroadcastMessage("Deactivate");

        //user = GameObject.FindWithTag("Player");
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
            

            if (isLocalPlayer)
            {
                cannon.BroadcastMessage("Activate");
                player.BroadcastMessage("Deactivate");
                //user.gameObject.GetComponent<PlayerController>().enabled = false;

            }
            else
            {
                //this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = false;
                //user.gameObject.GetComponent<PlayerController>().enabled = true;
            }

            if (!isLocalPlayer)
            {
                return;
            }
        }
	}
}
