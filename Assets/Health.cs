using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int maxHealth = 1;
    [SyncVar]public int currentHealth = maxHealth;
    private NetworkStartPosition[] spawnPoints;

    public float timer = 0.0f;

    void Start()
    {
        //if (isLocalPlayer)
        //{
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        //}

        //Get the Renderer component from the new cube
        var renderer = this.transform.GetChild(2).gameObject.GetComponent<Renderer>();

        timer += Time.deltaTime;
        if (timer >= 0.0001f)//change the float value here to change how long it takes to switch.
        {
            // pick a random color
            Vector4 color = new Vector4(Random.value, Random.value, Random.value, 1.0f);
            // apply it on current object's material
            renderer.material.SetColor("_Color", color);
            timer = 0;
        }
    }

    public void TakeDamage(int amount)
    {
        if(!isServer)
        {
            return;
        }

        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            currentHealth = maxHealth;
            RpcRespawn();
        }
    }

    [ClientRpc]
    void RpcRespawn()
    {
        //if (isLocalPlayer)
        //{
            Vector3 spawnPoint = Vector3.zero;

            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            transform.position = spawnPoint;
        //}

       /* //Get the Renderer component from the new cube
        var renderer = this.transform.GetChild(2).gameObject.GetComponent<Renderer>();

        timer += Time.deltaTime;
        if (timer >= 0.0001f)//change the float value here to change how long it takes to switch.
        {
            // pick a random color
            Vector4 color = new Vector4(Random.value, Random.value, Random.value, 1.0f);
            // apply it on current object's material
            renderer.material.SetColor("_Color", color);
            timer = 0;
        }*/
    }
}
