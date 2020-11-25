using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    private SphereCollider scol;
    private CapsuleCollider capscol;
    private GameObject capsule;
    Vector3 movement = new Vector3(0.0f, 0.21f, 0.0f);

    void Start()
    {
        capscol = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider capscol)
    {
        if (capscol.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
