using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveChairs : MonoBehaviour
{
    public float speed;
    public float rotate;
    public float speedMax;
    private float period = 0.01f;
    private float speedUp = 0.005f;
    private float slowdown = 0.001f;
    private float ActionTime;
    private float moveHorizontal = 0f;
    private float moveVertical = 0f;
    private float currentMov;
    private bool direction;
    private bool rotation;
    private bool access = true;
    // Start is called before the first frame update
    void Start()
    {
        speedMax = 1.35f;
        speed = 0;
        rotate = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementLogic();
    }
    private void MovementLogic()
    {

        if (Input.GetKey(KeyCode.A))
        {
            RotateControl(false);
            if (rotation == false)
            {
                moveHorizontal = -1f;
            }
        } else if (Input.GetKey(KeyCode.D)){
            RotateControl(true);
            if (rotation == true)
            {
                moveHorizontal = 1f;
            }
        } else
        {
            moveHorizontal = 0f;
        }

            if (Input.GetKey(KeyCode.W))
            {
                SpeedControl(true);
                if (direction == true)
                {
                    moveVertical = 1f;
                    currentMov = moveVertical;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                SpeedControl(false);
                if (direction == false)
                {
                    moveVertical = -1f;
                    currentMov = moveVertical;
                }

            }
            else
            {
                moveVertical = 0f;

            }

            Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);

            if (moveVertical == 0f)
            {
                ActionTime = 5f;
                if (ActionTime > 0 && speed > 0)
                {
                    speed -= slowdown;
                    transform.Translate(new Vector3(0.0f, 0.0f, currentMov) * speed);
                    ActionTime -= period;
                }
            }
            else
            {
                ActionTime = 0;
                if (speed < speedMax)
                {
                    speed += speedUp;
                }
                transform.Translate(movement * speed);

            }

        if (Input.GetKey(KeyCode.Space))
        {
            if (speed > 0.01f)
            {
                speed -= 0.01f;
            }
        }
        if (moveHorizontal != 0)
        {
            if (rotate < 1.5f) rotate += 0.1f;
            transform.Rotate(Vector3.up, moveHorizontal * rotate);
        } else
        {
            rotate = 0f;
        }


        }

    private void SpeedControl(bool swap)
    {
        if (speed > 0 && direction != swap) speed -= 0.0045f;
        else if (speed <= 0) direction = swap;
    }

    private void RotateControl(bool swap)
    {
        if (rotate > 0 && rotation != swap) rotate -= 0.5f;
        else if (rotate <= 0) rotation = swap;
           
       
    }
    public void SetMovement(bool permit)
    {
        access = permit;
    }
    public void Back(float backSpeed)
    {
        SpeedControl(false);
        if (direction == false)
        {
            moveVertical = -1f;
            currentMov = moveVertical;
            transform.Translate(new Vector3(0.0f, 0.0f, currentMov) * backSpeed);
        }

    }
}
