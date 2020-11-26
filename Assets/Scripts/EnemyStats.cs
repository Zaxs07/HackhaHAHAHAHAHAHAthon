using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float barr;
    public float bull;
    private float timeBarrier = 5f;
    private float timeBullet = 10f;

    public GameObject barrier;
    public Transform barrierSpawn;
    public GameObject bullet;
    public Transform bulletSpawn;

    public AudioSource Barrier;
    public AudioSource Bullet;
    public AudioSource fire;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GoBarrier();
        GoBullet();
    }

    private void FixedUpdate()
    {
        timeBarrier += Time.deltaTime;
        timeBullet += Time.deltaTime;

    }

    void GoBarrier()
    {
        if (barr != 0 && timeBarrier >= 10f)
        {
            if (Input.GetButton("Fire1"))
            {
                Instantiate(barrier, barrierSpawn.position, barrierSpawn.rotation);
                timeBarrier = 0;
                barr--;
            }    
        }
    }

    void GoBullet()
    {
        if (bull != 0 && timeBullet >= 15f)
        {
            if (Input.GetButton("Fire2"))
            {
                fire.Play();
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                timeBullet = 0;
                bull--;
            }
        }
    }

    private void OnTriggerEnter(Collider capscol)
    {
        if (capscol.CompareTag("BarrierPack"))
        {
            barr++;
            Barrier.Play();
        }

        if (capscol.CompareTag("BulletPack"))
        {
            bull++;
            Bullet.Play();
        }
    }
}
