using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionCaps : MonoBehaviour
{
    public float speedCaps = 400f;
    public Rigidbody capsule;
    private float lifeTime = 0f;
    public Vector3 movement;

    void Start()
    {
        movement = new Vector3(0.2f, 0.0f, 1f);
        capsule.AddForce(movement * speedCaps, ForceMode.Impulse);
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
