using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballController : MonoBehaviour
{
    public float impactDistance = 0;
    public float ballStartVelocity;
    public float ballCurrentVelocity;
    public float ballCollisionVelocity;
    int counter = 0;
    bool initialFlag = false;
    public GameObject cannonObject;
    // Start is called before the first frame update
    void Start()
    {
        ballCurrentVelocity = Time.deltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < 5)
            counter++;
        else if(counter == 5 )
        {
            ballStartVelocity = this.GetComponent<Rigidbody>().velocity.magnitude;
            counter++;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            //Do what you want when it collided with the ground
            if(impactDistance == 0)
            {
                impactDistance = Vector3.Distance(this.transform.position, cannonObject.transform.position);
                ballCollisionVelocity = this.GetComponent<Rigidbody>().velocity.magnitude;
            }
        }     

    }
}
