using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotationController : MonoBehaviour
{

    public float SENS_HOR = 3.0F;
    public float SENS_VER = 2.0F;
    public float cannonSpeedHorizontal = 20F;
    public float ballVelocity;
    public float angleTotarget;
    public float mvX;
    public bool activated = false;
    GameObject character; // a parent object the camera is attached to
    public GameObject currentTarget;
    public float period = 0.0f;
    public float timeInterval = 0.0f;
    GameObject[] targetObjects;

    // Start is called before the first frame update
    void Start()
    {
        // disable the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        // assign a parent object of this project
        character = this.transform.parent.gameObject;
        timeInterval = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            CannonScript cannonScript = GameObject.Find("launchlocation").GetComponent<CannonScript>();

            ballVelocity = cannonScript.ballVelocity;

            /*
            var mouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            mouseMove = Vector2.Scale(mouseMove, new Vector2(SENS_HOR, SENS_VER));
            // rotate the character horizontally
            character.transform.Rotate(0, mouseMove.x, 0);
            //transform.Rotate(-mouseMove.y, 0, 0); // rotate the camera vertically
            transform.localRotation = Quaternion.Euler(-ballVelocity, 0, 0);
            */
            mvX = (Input.GetAxis("Horizontal") * Time.deltaTime * cannonSpeedHorizontal);
            character.transform.Rotate(0, mvX, 0);
            transform.localRotation = Quaternion.Euler(-ballVelocity, 0, 0);


            // enable the mouse cursor if Esc pressed
            if (Input.GetKeyDown("escape"))
                Cursor.lockState = CursorLockMode.None;
        }
        else
            AIControl();
    }

    public void AIControl()
    {
        if (period > timeInterval)
        {
            targetObjects = GameObject.FindGameObjectsWithTag("Player");
            if (targetObjects.Length > 0)
            {
                currentTarget = targetObjects[Random.Range(0, targetObjects.Length)];
            }
            period = 0;
            timeInterval = Random.Range(0.5f, 2f);
        }
        period += Time.deltaTime;
        Plane p = new Plane(transform.up, transform.position);
        Ray ray = new Ray(currentTarget.transform.position, transform.up);

        if (p.Raycast(ray, out angleTotarget))
        {
            Vector3 projectedTarget = ray.GetPoint(angleTotarget);
            transform.LookAt(projectedTarget, transform.up);
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
