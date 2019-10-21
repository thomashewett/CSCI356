using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRun : MonoBehaviour {
    private GameObject target;
    public Transform firstTarget;
    private UnityEngine.AI.NavMeshAgent agent;
    Animator charAnim;
    private bool firstTargetFlag = true;
    


    // Use this for initialization
    void Start () {
        firstTarget.GetComponent<Renderer>().enabled = false;
        charAnim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindWithTag("stump");

        // agent.SetDestination(target.transform.position); //  if static
    }
	
	// Update is called once per frame
	void Update () {
        if(firstTargetFlag)
        {
            agent.SetDestination(firstTarget.position);
            if ((firstTarget.position - this.transform.position).magnitude > 3.0f)
            {
                charAnim.SetTrigger("walk");
            }
            else
            {
                //charAnim.SetTrigger("stop");
                //enemyShoot cannonScript = GameObject.Find("launchlocation").GetComponent<enemyShoot>();
                //cannonScript.Shoot();
                firstTargetFlag = false;
            }
        }
        else
        {
            agent.SetDestination(target.transform.position);
            if ((target.transform.position - this.transform.position).magnitude > 3.0f)
            {
                charAnim.SetTrigger("walk");
            }
            else
            {
                charAnim.SetTrigger("stop");
                //enemyShoot cannonScript = GameObject.Find("launchlocation").GetComponent<enemyShoot>();
                //cannonScript.Shoot();
                //firstTargetFlag = false;
            }
        }
    }
}
