using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions: MonoBehaviour
{
    private moveChairs chair;
    private float timer = 0;
    private float period = 0.1f;
    void Start()
    {
        chair = gameObject.GetComponent<moveChairs>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("enviroment"))
        {
            chair.Back(chair.speed);
            timer += period; 
        
            
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("enviroment"))
        {
            chair.SetMovement(false);
            chair.speed = 0;
         
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("enviroment"))
        {
            chair.SetMovement(true);
           
        }
    }
}
