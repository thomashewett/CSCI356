using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
