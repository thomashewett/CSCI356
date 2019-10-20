using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    Animator charAnim;
    private bool walkState = false;
    public bool activated;

    // Use this for initialization
    void Start () {
        charAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (activated)
        {
            float mvY = Input.GetAxis("Horizontal");
            float mvX = Input.GetAxis("Vertical");

            if (mvX != 0 || mvY != 0)
            {
                if (walkState == false)
                {
                    charAnim.SetTrigger("walk");
                    walkState = true;
                    //Debug.Log("Set to walk");  
                }
            }
            else
            {
                if (walkState == true)
                {
                    charAnim.SetTrigger("stop");
                    walkState = false;
                    //Debug.Log("Set to stop");
                }
            }
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
