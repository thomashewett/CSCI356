using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawPath : MonoBehaviour
{
    Vector3[] plotline3d;
    private LineRenderer myline;
    public GameObject hitLocation;
    public float ballVelocity;
    public bool activated;

    Rigidbody cannon3D;
    RaycastHit hit;

    Vector3 velociiity;
    Vector3[] plotline;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CannonScript cannonScript = this.GetComponent<CannonScript>();

        ballVelocity = cannonScript.ballVelocity;

        myline = this.GetComponent<LineRenderer>();
        cannon3D = this.GetComponent<Rigidbody>();

        if (activated)
        {
            myline.enabled = true;
            velociiity = cannon3D.transform.forward * ballVelocity;

            plotline = Plot(cannon3D, cannon3D.position, velociiity, 400);

            myline.SetPositions(plotline);

            Vector3[] collisionlist = new Vector3[400];



            if (collisionlist.Length > 20)
            {
                for (int i = 0; i < collisionlist.Length - 1; i++)
                {
                    collisionlist[i] = plotline[i];
                    collisionlist[i + 1] = plotline[i + 1];
                    Ray pointRay = new Ray(collisionlist[i], collisionlist[i + 1] - collisionlist[i]);
                    if (Physics.Raycast(pointRay, out hit, 1f))
                    {
                        hitLocation.transform.position = hit.point;
                        break;
                    }
                }

            }
        }
        else
            myline.enabled = false;

    }

    public static Vector3[] Plot(Rigidbody rigidbody, Vector3 pos, Vector3 velocity, int steps)
    {
        Vector3[] results = new Vector3[steps];

        float timestep = Time.fixedDeltaTime / Physics.defaultSolverVelocityIterations;
        Vector3 gravityAccel = Physics.gravity * 1 * timestep * timestep;
        float drag = 1f - timestep * rigidbody.drag;
        Vector3 moveStep = velocity * timestep;

        for (int i = 0; i < steps; ++i)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
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

