using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPackGet : MonoBehaviour
{
    public float speedBull = 600f;
    public Rigidbody bullet;
    private float lifeTime = 0f;
    public Vector3 movement;
    private bool shoot;

    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        lifeTime += Time.deltaTime;

        transform.Translate(Vector3.forward * speedBull * Time.deltaTime);

        if (lifeTime >= 10f)
        {
            Destroy(gameObject);
            lifeTime = 0f;
        }
    }
}
