using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCannonBall : MonoBehaviour {

    public bool invincible = false;
    public GameObject absurbEffect;

	void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();

        if(invincible == false)
        {
            if (health != null)
            {
                health.TakeDamage(1);
            }
        } else
        {
            GameObject absurbed = Instantiate(absurbEffect, gameObject.transform.position, 
                gameObject.transform.rotation);

            Destroy(absurbed, 1.0f);

            Destroy(gameObject);
        }
    }
}
