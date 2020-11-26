using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private SphereCollider scol;
    private float cubeLife = 0f;
    private float cubeRespawn = 20f;
    public GameObject cube;
    public Transform cubeSpawn;
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
    }

    private void OnTriggerEnter(Collider col)
    {
        if (cubeRespawn > 20f)
        {
            Instantiate(cube, cubeSpawn.position, cubeSpawn.rotation);
            cubeRespawn = 0f;
        }
        
        
    }
}
