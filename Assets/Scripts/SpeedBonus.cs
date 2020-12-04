using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : MonoBehaviour
{
    public float acceleretion = 30f;
    private float time = 0f;
    private float maxSpeed;
    private float upSpeed;
    private moveChairsTrue mct;
    public bool run = false;

    void Start()
    {
        mct = GameObject.FindWithTag("Player").GetComponent<moveChairsTrue>();
        maxSpeed = mct.SpeedMovementMax;
        upSpeed = mct.SpeedMovementUp;
    }

    private void FixedUpdate()
    {
        if (run == true)
        {
            time += Time.deltaTime;

            if (time < 2f)
            {
                mct.SpeedMovementUp = 100f; 
                mct.SpeedMovementMax = 800f;
            }
            else
            {
                mct.SpeedMovementMax = maxSpeed;
                mct.SpeedMovementUp = upSpeed;
                mct.SpeedMovement = maxSpeed;
                run = false;
                time = 0f;
            }
        }
    }
}
