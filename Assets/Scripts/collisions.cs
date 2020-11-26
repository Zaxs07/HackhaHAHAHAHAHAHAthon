using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions: MonoBehaviour
{
    private moveChairs chair;
    private float timer = 0;
    private float period = 1f;
    private bool back = false;
    void Start()
    {
        chair = gameObject.GetComponent<moveChairs>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(chair.speedMax == 0.2f)
        {
            if (5f > timer)
            {
                timer += 0.02f;
            } else
            {
                chair.speedMax = 0.35f;
            }
        }

        if (back)
        {
            transform.Translate(new Vector3(0.0f, 0.0f, -0.1f));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("enviroment"))
        {
            chair.Back(chair.speed);
            chair.speed = 0f;
        }

        if (collision.collider.CompareTag("freeze"))
        { 
            chair.speedMax = 0.2f;
            chair.speed = 0.2f;
            timer = 0;
          
               
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("enviroment"))
        {
            chair.Back(chair.speed);
            chair.speed = 0f;
            back = true;
         
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("enviroment"))
        {

            back = !back;
        }
    }
}
