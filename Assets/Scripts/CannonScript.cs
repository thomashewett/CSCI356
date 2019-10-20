using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CannonScript : MonoBehaviour
{
    public float SENS_HOR = 3.0F;
    public float SENS_VER = 2.0F;

    public float cannonSpeedVertical = 20;

    public Rigidbody cannonballInstance;

    public float ballVelocity;
    public float ballSize = 1;
    public float initialVelocity = 10f;
    public double fireRate = 0.5;

    public double nextFire = 0.0;
    public float chargeCounter = 0;
    public float chargeRate = 1;

    public bool activated;
    public float initialForce = 15;

    // Start is called before the first frame update
    void Start()
    {
        initialForce = 15;
        chargeRate = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            Shoot();
            var mouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            mouseMove = Vector2.Scale(mouseMove, new Vector2(SENS_HOR, SENS_VER));

            float mvZ = Input.GetAxis("Vertical") * Time.deltaTime * cannonSpeedVertical;

            ballVelocity += mvZ;
            /*
            if (Input.GetButtonDown("Fire1"))
            {
                Rigidbody clone = Instantiate(cannonballInstance, transform.position, transform.rotation);
                clone.AddForce(transform.forward * initialForce, ForceMode.Impulse);
            }
            */
        }


    }

    public void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {       

            if (chargeCounter >= 100)
            {
                Debug.Log("fully charged weapon");

            }

            if(ballSize <= 100)
            {
                chargeCounter++;
                ballSize = 1+chargeCounter*chargeRate;

            }
        }

        if (Input.GetButtonUp("Fire1"))
        {

            if (chargeCounter >= 100)
            {

                Debug.Log("This was a charged attack");

            }
            if (Time.time > nextFire)
            {
                Rigidbody clone = Instantiate(cannonballInstance, transform.position, transform.rotation);
                clone.transform.localScale = new Vector3(0.5f+ballSize/20, 0.5f+ballSize/20, 0.5f+ballSize/20);
                clone.AddForce(transform.forward * ballVelocity, ForceMode.Impulse);
                nextFire = Time.time + fireRate;
            }
            chargeCounter = 0;
            ballSize = 1;
        }
    }

    public void ScaleBall()
    {

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
