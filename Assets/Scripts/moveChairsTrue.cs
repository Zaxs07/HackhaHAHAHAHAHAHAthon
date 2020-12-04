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
    public float SpeedBraking;
    public float SpeedReductionFactor;
    public float StopDrag;
    public bool Lock = false;
    public float moveHorizontal ;

    public float moveVertical ;


    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.drag = 1;
        _rb.angularDrag = 5;
        SpeedMovement = 0f;
        SpeedRotation = 25f;
        SpeedMovementSlow = 5f;
        SpeedMovementMax = 100f;
        SpeedMovementUp = 5;
        SpeedBraking = SpeedMovementMax / 10f;
        SpeedReductionFactor = 0.4f;
        StopDrag = 1.7f;
        
}

    void FixedUpdate()
    {
        MovementLogic();
        Stop();
    }

    private void MovementLogic()
    {
        if (Lock == false)
        {
            moveHorizontal = Input.GetAxis("Horizontal");

            moveVertical = Input.GetAxis("Vertical");
        }

        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);

        if (moveVertical != 0 && SpeedMovement < SpeedMovementMax)
        {
            SpeedMovement += SpeedMovementUp;
        }
        if (moveVertical == 0) {
            if (SpeedMovement >= SpeedMovementSlow)
            {
                SpeedMovement -= SpeedMovementSlow ;
            } else
            {
                SpeedMovement = 0;
            }
        }
        if (moveVertical > 0)
        {
            _rb.AddRelativeForce(movement * SpeedMovement);
        } else if (moveVertical < 0){
            _rb.AddRelativeForce(movement * SpeedMovement * SpeedReductionFactor);
        }
        
        _rb.AddRelativeTorque(Vector3.up * moveHorizontal * SpeedRotation);
    }
    private void Stop()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (SpeedMovement > 0)
            {
                SpeedMovement -= SpeedBraking;
                _rb.drag = StopDrag;
            }
            else
            {
                
                SpeedMovement = 0;
               
            }
        } else
        {
            _rb.drag = 1f;
        }
    }
    

}
