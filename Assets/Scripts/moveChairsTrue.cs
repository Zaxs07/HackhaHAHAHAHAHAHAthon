using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveChairsTrue : MonoBehaviour
{
    public float SpeedMovement;
    public float SpeedRotation;
    public float SpeedMovementSlow;
    public float SpeedMovementUp;
    public float SpeedMovementMax;

    
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.drag = 1;
        _rb.angularDrag = 5;
        SpeedMovement = 0f;
        SpeedRotation = 1f;
        SpeedMovementSlow = 5f;
        SpeedMovementMax = 100f;
        SpeedMovementUp = 5f;
}

    void FixedUpdate()
    {
        MovementLogic();
        Stop();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
       
        if (moveVertical != 0 && SpeedMovement < SpeedMovementMax)
        {
            SpeedMovement += SpeedMovementUp;
        }
        _rb.AddRelativeForce(movement * SpeedMovement);
        _rb.AddRelativeTorque(Vector3.up * moveHorizontal * SpeedRotation);
    }
    private void Stop()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (SpeedMovement > SpeedMovementSlow)
            {
                SpeedMovement -= SpeedMovementSlow;
            }
        }
    }
    

}
