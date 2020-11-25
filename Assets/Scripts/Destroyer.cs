using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public Rigidbody rb;
    private float lifeTime = 0f;
    void FixedUpdate()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime >= 10f)
        {
            Destroy(gameObject);
        }
    }
}
