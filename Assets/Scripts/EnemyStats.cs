using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float barr;
    public float bull;
    public float maxTBar = 10f;
    public float maxTBul = 15f;

    private float timeBarrier = 5f;
    private float timeBullet = 10f;

    public GameObject barrier;
    public Transform barrierSpawn;

    public GameObject bullet;
    public Transform bulletSpawn;

    public AudioSource Barrier;
    public AudioSource Bullet;
    public AudioSource fire;
    public AudioSource bottle;
    public AudioSource drink;
    public AudioSource vodka;

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
        if (barr != 0 && timeBarrier >= maxTBar)
        {
            if (Input.GetButton("Fire1"))
            {
                bottle.Play();
                Instantiate(barrier, barrierSpawn.position, barrierSpawn.rotation);
                timeBarrier = 0;
                barr--;
            }    
        }
    }

    void GoBullet()
    {
        if (bull != 0 && timeBullet >= maxTBul)
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

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("BarrierPack"))
        {
            barr++;
            Barrier.Play();
        }

        if (col.CompareTag("BulletPack"))
        {
            bull++;
            Bullet.Play();
        }

        if (col.CompareTag("SpeedPack"))
        {
            SpeedBonus sb = GameObject.FindWithTag("SpeedPack").GetComponent<SpeedBonus>();
            sb.run = true;
            drink.Play();
        }

        if (col.CompareTag("RevertThing"))
        {
            RevertMotions rm = GameObject.FindWithTag("RevertThing").GetComponent<RevertMotions>();
            rm.On = true;
            vodka.Play();
        }
    }
}
