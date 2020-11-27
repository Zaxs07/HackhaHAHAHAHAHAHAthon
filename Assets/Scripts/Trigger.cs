using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private float cubeRespawn = 20f;
    private float BPRespawn = 10f;
    private float SPRespawn = 30f;
    private float BotPRespawn = 15f;
    public int count;

    
    private bool spawn = false;

    public GameObject BP;
    public GameObject shmolik;
    public GameObject SP;
    public GameObject BoP;

    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;
    public Transform shmolikSpawn1;
    public Transform shmolikSpawn2;

    void Start()
    {
        if (count == 2)
        {
            Instantiate(BP, Spawn1.position, Spawn1.rotation);
            Instantiate(BP, Spawn2.position, Spawn2.rotation);
            Instantiate(BP, Spawn3.position, Spawn3.rotation);
            BPRespawn = 0f;
        }

        if (count == 3)
        {
            Instantiate(SP, Spawn1.position, Spawn1.rotation);
            Instantiate(SP, Spawn2.position, Spawn2.rotation);
            Instantiate(SP, Spawn3.position, Spawn3.rotation);
            SPRespawn = 0f;
        }

        if (count == 4)
        {
            Instantiate(BoP, Spawn1.position, Spawn1.rotation);
            Instantiate(BoP, Spawn2.position, Spawn2.rotation);
            Instantiate(BoP, Spawn3.position, Spawn3.rotation);
            BotPRespawn = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        cubeRespawn += Time.deltaTime;
        BPRespawn += Time.deltaTime;
        SPRespawn += Time.deltaTime;
        BotPRespawn += Time.deltaTime;

        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") || col.CompareTag("OtherPlayers"))
        {
            if (cubeRespawn > 20f && count == 1)
            {
                Instantiate(shmolik, shmolikSpawn1.position, shmolikSpawn1.rotation);
                Instantiate(shmolik, shmolikSpawn2.position, shmolikSpawn2.rotation);
                cubeRespawn = 0f;
            }

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("OtherPlayers"))
        {
            if (count == 2 && BPRespawn > 10F)
            {
                Instantiate(BP, Spawn1.position, Spawn1.rotation);
                Instantiate(BP, Spawn2.position, Spawn2.rotation);
                Instantiate(BP, Spawn3.position, Spawn3.rotation);
                BPRespawn = 0f;
            }

            if (count == 3 && SPRespawn > 30f)
            {
                Instantiate(SP, Spawn1.position, Spawn1.rotation);
                Instantiate(SP, Spawn2.position, Spawn2.rotation);
                Instantiate(SP, Spawn3.position, Spawn3.rotation);
                SPRespawn = 0f;
            }

            if (count == 4 && BotPRespawn > 15f)
            {
                Instantiate(BoP, Spawn1.position, Spawn1.rotation);
                Instantiate(BoP, Spawn2.position, Spawn2.rotation);
                Instantiate(BoP, Spawn3.position, Spawn3.rotation);
                BotPRespawn = 0f;
            }
        }
    }
}
