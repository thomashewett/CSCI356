using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class CannonScript : NetworkBehaviour
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
    public float chargeRate = 5;
    public float period;
    public float timeInterval;

    public float speed;

    public bool activated;
    public float initialForce = 15;

    public GameObject Target;
    public GameObject[] TargetObjects;

    // Start is called before the first frame update
    void Start()
    {
        initialForce = 15;
        chargeRate = 0.5f;
        speed = 0;
        period = 0.1f;
        timeInterval = 0.2f;
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
        }
        else
            AIControl();


    }

    public void AIControl()
    {
        if (period > timeInterval)
        {
            ballVelocity = Random.Range(10f, 30f);
            period = 0;
            timeInterval = Random.Range(0.1f, 1f);
            ballVelocity = Random.Range(5f, 30f);
            ballSize = Random.Range(20f, 60f);
            Rigidbody clone = Instantiate(cannonballInstance, transform.position, transform.rotation);
            clone.transform.localScale = new Vector3(0.5f + ballSize / 20, 0.5f + ballSize / 20, 0.5f + ballSize / 20);
            clone.AddForce(transform.forward * ballVelocity, ForceMode.Impulse);
        }
        period += Time.deltaTime;
    }

    //[Command]
    public void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {

            if (chargeCounter >= 100)
            {
                Debug.Log("fully charged weapon");

            }

            if (ballSize <= 100)
            {
                chargeCounter++;
                ballSize = 1 + chargeCounter * chargeRate;

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
                //GameObject clone = (GameObject)Instantiate(cannonballInstance, transform.position, transform.rotation);
                clone.transform.localScale = new Vector3(0.5f + ballSize / 20, 0.5f + ballSize / 20, 0.5f + ballSize / 20);
                clone.AddForce(transform.forward * ballVelocity, ForceMode.Impulse);
                nextFire = Time.time + fireRate;
                //NetworkServer.Spawn(clone);


//                GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

//                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;

//                NetworkServer.Spawn(bullet);

               // Destroy(bullet, 2);
            }
            chargeCounter = 0;
            ballSize = 1;
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
