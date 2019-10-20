using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public float SPEED = 5.0F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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



    //change player local player colour
    public override void OnStartLocalPlayer()
    {
        //Get the Renderer component from the new cube
        //var renderer = this.transform.GetChild(2).gameObject.GetComponent<Renderer>();

        //Vector4 color = new Vector4(.0f, .5f, .0f, 1f);

        //Call SetColor using the shader property name "_Color" and setting the color to red
        //renderer.material.SetColor("_Color", color);
    }
}
