using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private SphereCollider scol;
    private float cubeLife = 0f;
    private float cubeRespawn = 20f;
    public int count;
    public GameObject cube;
    public Transform cubeSpawn;

    public GameObject BP;
    public Transform BPSpawn;
    private float BPRespawn = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        cubeRespawn += Time.deltaTime;
        BPRespawn += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") || col.CompareTag("OtherPlayers"))
        {
            if (cubeRespawn > 20f && count == 1)
            {
                Instantiate(cube, cubeSpawn.position, cubeSpawn.rotation);
                cubeRespawn = 0f;
            }

            if (count == 2 && BPRespawn > 10F)
            {
                Instantiate(BP, BPSpawn.position, BPSpawn.rotation);
                BPRespawn = 0f;
            }
        }
        
        
        
    }
}
