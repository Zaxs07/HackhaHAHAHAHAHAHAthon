using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float barr;
    private float timeBarrier = 5f;
    public GameObject barrier;
    public Transform barrierSpawn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoBarrier();
    }

    private void FixedUpdate()
    {
        timeBarrier += Time.deltaTime;
    }

    void GoBarrier()
    {
        if (barr != 0 && timeBarrier >= 10)
        {
            if (Input.GetButton("Fire1"))
            {
                Instantiate(barrier, barrierSpawn.position, barrierSpawn.rotation);
                timeBarrier = 0;
                barr--;
            }    
        }
    }

    private void OnTriggerEnter(Collider capscol)
    {
        if (capscol.CompareTag("BarrierPack"))
        {
            barr++;
        }
    }
}
