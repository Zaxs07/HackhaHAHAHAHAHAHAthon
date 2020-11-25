using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    //private CapsuleCollider capscol;
    //Vector3 movement = new Vector3(0.0f, 0.21f, 0.0f);

    void Start()
    {
        //capscol = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
