using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public float SPEED = 5.0F;
    public bool activated = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (isLocalPlayer)
        {
            this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = true;
        } else
        {
            this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = false;
        }

        if (!isLocalPlayer)
        {
            return;
        }

        float mvX = (Input.GetAxis("Horizontal") * Time.deltaTime * SPEED);
        float mvZ = Input.GetAxis("Vertical") * Time.deltaTime * SPEED;

        transform.Translate(mvX, 0, mvZ);
        }
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
