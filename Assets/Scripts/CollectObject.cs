using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    
    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (gameObject.CompareTag("SpeedPack") || gameObject.CompareTag("RevertThing"))
            {
                Destroy(transform.GetChild(0).gameObject);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                if (gameObject.CompareTag("SpeedPack"))
                    Destroy(gameObject, 3f);
                else
                    Destroy(gameObject, 6f);
            }
            else
                Destroy(gameObject);
        }
    }
}
