using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPackGet : MonoBehaviour
{
    public float speedBull = 600f;
    public Rigidbody bullet;
    private float lifeTime = 0f;
    public Vector3 movement;
    private bool shoot = true;
    

    void Start()
    {
        bullet.AddRelativeForce(Vector3.forward * speedBull, ForceMode.Impulse);
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {       
        lifeTime += Time.deltaTime;

        if (lifeTime >= 10f)
        {
            Destroy(gameObject);
            lifeTime = 0f;
        }
    }
}
