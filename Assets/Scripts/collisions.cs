using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions: MonoBehaviour
{
    private moveChairsTrue chair;
    private float timer = 0;
    private float PrevSpeedMovementMax;
    public float SlowSpeed;
    public float DecelerationTime;
    void Start()
    {
        chair = gameObject.GetComponent<moveChairsTrue>();
        SlowSpeed = 60f;
        DecelerationTime = 5f;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(chair.SpeedMovementMax == SlowSpeed)
        {
            if (DecelerationTime > timer)
            {
                timer += 0.02f;
            } else
            {
                chair.SpeedMovementMax = PrevSpeedMovementMax;
            }
        }

       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("enviroment"))
        {
            
        }

        if (collision.collider.CompareTag("freeze"))
        {
            Destroy(collision.gameObject);
            PrevSpeedMovementMax = chair.SpeedMovementMax;
            chair.SpeedMovementMax = SlowSpeed;
            chair.SpeedMovement = SlowSpeed;
            timer = 0;
          
               
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("enviroment"))
        {
            
            

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("enviroment"))
        {
            
           
        }
    }
}
