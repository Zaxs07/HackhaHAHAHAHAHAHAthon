using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulseForObj : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private float lifeTime = 0f;

    void Start()
    {
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
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
